using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Bear_And_Honey.Scripts.Game.Player.Bear
{
    public class BearController : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayerMask = 10;
        [SerializeField] private float _playerSpeed = 5;
        [SerializeField] private float _playerSpeedBase = 5;
        [SerializeField] private float _jumpForce = 5;
        [SerializeField] private float _timeFromGroundToAir = 0.2f;
        [SerializeField] private float _timeFromAirToGround = 0.2f;
        [SerializeField] private bool _isOnGround;
        [SerializeField] private bool _isDashing;
        [SerializeField] private float _dashSpeed = 10;
        [SerializeField] private GameObject _groundCheckerPoint;
        [SerializeField] private float _groundCheckRadius = 0.4f;
        [SerializeField] private bool _isJumping;
        private Rigidbody2D _playerRigidbody2D;
        [SerializeField] private float currentTimeAirToGround;
        [SerializeField] private bool _inPhone;
        [SerializeField] private GameObject _beePrefab;
        [SerializeField] private float _timeForSpeedLose = 25f;
        [SerializeField] private bool _isEating;
        [SerializeField] private GameObject _beeCircle;
        private Animator _bearAnimator;
        private GameObject _bee;
        [SerializeField] private float _currentEatPause;
        [SerializeField] private GameObject _bearDeathScreen;

        private void Start()
        {
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
            _bearAnimator = GetComponent<Animator>();
            
        }

        private void OnEnable()
        {
            Game.GameInst.ServiceLocatorInst.ActionServiceInst.BearDeathAction += BearDeath;
        }

        private void OnDisable()
        {
            Game.GameInst.ServiceLocatorInst.ActionServiceInst.BearDeathAction -= BearDeath;
        }

        private void Update()
        {
            JumpUpdate(); // Проверка на прыжок

            JumpWithCheckUpdate(); // Проверка на прыжок до платформы
            IsOnGround(); // проверка нахождениян а земле
            SwapSides();
            BeeCheck();
            EatNeed();
            LeaveToMenu();
        }

        private void EatNeed()
        {
            _currentEatPause += Time.deltaTime;
            if (_timeForSpeedLose <= _currentEatPause)
            {
                _playerSpeed = _playerSpeedBase / 2;
            }
            else
            {
                _playerSpeed = _playerSpeedBase;
            }

            if (Input.GetKeyDown(KeyCode.O) & _playerRigidbody2D.velocity.x <= 0.1f &
                _playerRigidbody2D.velocity.y <= 0.1f & !_inPhone & !_isEating)
            {
                _bearAnimator.SetTrigger("Eating");
                _currentEatPause = 0;
            }
        }

        private void BeeCheck()
        {
            if (Input.GetKeyDown(KeyCode.Q) & _playerRigidbody2D.velocity.x <= 0.1f &
                _playerRigidbody2D.velocity.y <= 0.1f & !_inPhone & !_isEating)
            {
                _inPhone = true;
                _bee = Instantiate(_beePrefab, gameObject.transform.position, gameObject.transform.rotation);
                _beeCircle.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Q) & _inPhone)
            {
                _bee.transform.DetachChildren();
                _inPhone = false;
                _beeCircle.SetActive(false);
                Destroy(_bee);
            }
        }


        private void JumpWithCheckUpdate()
        {
            if (currentTimeAirToGround == 1)
            {
                JumpWithCheck();
            }
        }


        private void JumpUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isOnGround & !_isEating & !_inPhone)
                {
                    Jump();
                }
                else if (_isOnGround == false)

                {
                    StartCoroutine("AirToGroundTimer");
                }
            }
        }


        private void FixedUpdate()
        {
            if (Input.GetAxis("Horizontal") != 0 & !_inPhone & !_isEating)
            {
                _playerRigidbody2D.velocity =
                    new Vector2(Input.GetAxis("Horizontal") * _playerSpeed, _playerRigidbody2D.velocity.y);
                _bearAnimator.SetBool("Runing", true);
            }
            else
            {
                _bearAnimator.SetBool("Runing", false);
            }
        }


        private void SwapSides()
        {
            if (!_inPhone)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    gameObject.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                }

                if (Input.GetAxis("Horizontal") < 0)
                {
                    gameObject.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }
            }
        }

        private void JumpWithCheck()
        {
            if (_isOnGround)
            {
                _isOnGround = false;

                Jump();
                currentTimeAirToGround = 0;
            }
        }

        private void Jump()
        {
            _bearAnimator.SetTrigger("Jumping");
            _isOnGround = false;
            StartCoroutine("JumpCooldown");
            _playerRigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

        IEnumerator JumpCooldown()
        {
            _isJumping = true;
            yield return new WaitForSeconds(0.1f);
            _isJumping = false;
        }


        private void BearDeath()
        {
            Destroy(gameObject);
            if (_bee != null)
            {
                Destroy(_bee);
            }

            Instantiate(_bearDeathScreen, GameObject.FindWithTag(Constants.MAINLEVELCANVASTAG).transform);
        }

        private void LeaveToMenu()
        {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.LoadScene(1);
        }
        }
        private void IsOnGround()
        {
            if (Physics2D.OverlapCircle(_groundCheckerPoint.transform.position, _groundCheckRadius, _groundLayerMask) &
                !_isDashing & !_isJumping)
            {
                _isOnGround = true;
                StopCoroutine("GroundToAirTimer");
            }
            else
            {
                StartCoroutine("GroundToAirTimer");
            }
        }
        /*
        private void CanDash()
        {
        }

        private void Dash()
        {
            _playerRigidbody2D.AddForce(new Vector2(_dashSpeed, 0));
        }
        */
      


        IEnumerator GroundToAirTimer()
        {
            yield return new WaitForSeconds(_timeFromGroundToAir);
            _isOnGround = false;
        }

        IEnumerator AirToGroundTimer()
        {
            currentTimeAirToGround = 1;
            yield return new WaitForSeconds(_timeFromAirToGround);

            currentTimeAirToGround = 0;
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_groundCheckerPoint.transform.position, _groundCheckRadius);
        }
    }
}