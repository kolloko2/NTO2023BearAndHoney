using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bear_And_Honey.Scripts.Game;
using Bear_And_Honey.Scripts.Game.Player.Bear;
using UnityEngine;

public class ShootingBeeTrapBolt : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D _gameObjectRigidbody2D;
    [InspectorName("Скорость снаряда")]
    [SerializeField] private float _boltSpeed;

    public GameObject ParentBee;
    void Start()
    {
        _gameObjectRigidbody2D = GetComponent<Rigidbody2D>();
        _gameObjectRigidbody2D.velocity = transform.right * _boltSpeed;
        StartCoroutine("DestroyAfterTime");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyAfterTime()
    {
        
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BearController>())
        {
            Game.GameInst.ServiceLocatorInst.ActionServiceInst.BearDeathActionCaller(ParentBee);
           
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
