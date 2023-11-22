using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.Player.Bear
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayerMask = 10;
        [SerializeField] private float _playerSpeed = 5;
        [SerializeField] private float _jumpForce = 5;
        [SerializeField] private float _timeFromGroundToAir = 0.2f;
        [SerializeField] private float _timeFromAirToGround = 0.2f;
        [SerializeField] private bool _isOnGround;
        [SerializeField] private bool _isDashing;
        [SerializeField] private float _dashSpeed = 10;
        [SerializeField] private GameObject _groundCheckerPoint;
        [SerializeField] private float _groundCheckRadius = 0.4f;
        private Rigidbody2D _playerRigidbody2D;
        [SerializeField] private float currentTimeAirToGround;

        private void Start()
        {
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isOnGround)
                {
                    Jump();
                }
                else

                {
                    StartCoroutine("AirToGroundTimer");
                }
            }

            if (currentTimeAirToGround == 1)
            {
                JumpWithCheck();
            }

            IsOnGround();
        }

        private void FixedUpdate()
        {
            _playerRigidbody2D.velocity =
                new Vector2(Input.GetAxis("Horizontal") * _playerSpeed, _playerRigidbody2D.velocity.y);
        }


        private void SwapSides()
        {
        }

        private void JumpWithCheck()
        {
            if (_isOnGround)
            {
                Jump();
                currentTimeAirToGround = 0;
            }
        }

        private void Jump()
        {
            _isOnGround = false;

            _playerRigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

        private void IsOnGround()
        {
            if (Physics2D.OverlapCircle(_groundCheckerPoint.transform.position, _groundCheckRadius, _groundLayerMask) &
                !_isDashing)
            {
                _isOnGround = true;
                StopCoroutine("GroundToAirTimer");
            }
            else
            {
                StartCoroutine("GroundToAirTimer");
            }
        }

        private void CanDash()
        {
        }

        private void Dash()
        {
            _playerRigidbody2D.AddForce(new Vector2(_dashSpeed, 0));
        }

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