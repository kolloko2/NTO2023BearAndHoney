using System.Collections;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game;
using Bear_And_Honey.Scripts.Game.Player.Bear;
using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed = 5;

    [SerializeField]
    private Transform _target;
    [SerializeField]   private Transform _targetStop;
    [SerializeField]  private Transform _targetStart;

    private float _timeFlying;
    
    
    private float _timeForFly;
    void Start()
    {
     
}

    // Update is called once per frame
    void Update()
    {
        var step =  _speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, _target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, _target.position) < 0.01f)
        {
            if (_target.position==_targetStop.position)
            {
                gameObject.transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);  

                _target = _targetStart;
            }
            else
            {
                gameObject.transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);  
                _target = _targetStop;

            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BearController>())
        {
            Game.GameInst.ServiceLocatorInst.ActionServiceInst.BearDeathActionCaller(gameObject);
           
        
        }
    }
}
