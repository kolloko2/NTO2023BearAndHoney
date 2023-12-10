using System;
using System.Collections;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game;
using Bear_And_Honey.Scripts.Game.Player.Bear;
using UnityEngine;

public class BeeSwarmTrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Player")
        {
            Game.GameInst.ServiceLocatorInst.ActionServiceInst.BearDeathActionCaller(gameObject);
        }
        
    }
}
