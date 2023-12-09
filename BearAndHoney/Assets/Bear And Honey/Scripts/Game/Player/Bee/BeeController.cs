using System;
using System.Collections;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Bear_And_Honey.Scripts.Game.Player.Bee
{
    public class BeeController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Rigidbody2D _beeRigidbody;
        [SerializeField] private float _pickUpRadius;
        [SerializeField] private GameObject _inHands;
        [SerializeField] private GameObject _signalLoseTextPrefab;
        [SerializeField]
        private float _pickUpOffset;

        private bool _signalLosed;
        private GameObject _signalLoseText;
        private Vector2 _startPos;

        private void Start()
        {
            _beeRigidbody = gameObject.GetComponent<Rigidbody2D>();
            _startPos = gameObject.transform.position;
            _signalLoseText=Instantiate(_signalLoseTextPrefab, GameObject.FindWithTag(Constants.MAINLEVELCANVASTAG).transform);
             _signalLoseText.SetActive(false);
        }

        private void OnDestroy()
        {
            Destroy(_signalLoseText);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                PickUp();
            }

            SwapSides();
        }

        private void FixedUpdate()
        {
            if (Vector2.Distance(gameObject.transform.position, _startPos) <= 5)
            {
                if (!_signalLosed)
                {
                    print(Vector2.Distance(gameObject.transform.position,_startPos));
                    gameObject.transform.Translate(new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed));
                }

        
           
            
                
            }
            else
            {            
                gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, _startPos, 0.25f);
                StartCoroutine("SignalLoseText");

            }
        }

        IEnumerator SignalLoseText()
        {
            _signalLosed = true;

_signalLoseText.SetActive(true);
yield return new WaitForSeconds(1f);
_signalLoseText.SetActive(false);
_signalLosed = false;
        }

        private void Electric()
        {
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(new Vector2(gameObject.transform.position.x,gameObject.transform.position.y-_pickUpOffset), _pickUpRadius);
        }
        private void PickUp()
        {
            if (_inHands != null)
            {
                _inHands.transform.parent = null;
                _inHands = null;
                print("null");
            }
            else if (Physics2D.OverlapCircle(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - _pickUpOffset), _pickUpRadius) != null)
            {
                if (Physics2D.OverlapCircle(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - _pickUpOffset), _pickUpRadius).gameObject.tag=="Item")
                {
                print("взял");
                _inHands = Physics2D.OverlapCircle(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - _pickUpOffset), _pickUpRadius).gameObject ; 
                _inHands.transform.parent = gameObject.transform;
                
                }
            }
          
          

        
        }
        private void SwapSides()
        {
           
                if (Input.GetAxis("Horizontal") > 0)
                {
                    gameObject.transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);
        


                }

                if (Input.GetAxis("Horizontal") < 0)
                {
                    gameObject.transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
              

                }
            
        }
    }
}