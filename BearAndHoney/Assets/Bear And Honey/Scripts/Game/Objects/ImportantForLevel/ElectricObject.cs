using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricObject : MonoBehaviour
{
    public bool Powered;
    public bool ScriptCorrect;
    public bool BeeContact;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScriptCorrect & BeeContact)
        {
            Powered = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Powered & other.tag=="RoboBee")
        {
  
            BeeContact = true;
        }
            
 
    }
}
