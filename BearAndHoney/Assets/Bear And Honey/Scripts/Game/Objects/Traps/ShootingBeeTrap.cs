using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ShootingBeeTrap : MonoBehaviour
{

    [SerializeField] private GameObject _beeBolt;
    [SerializeField] private GameObject _shootPoint;
    [InspectorName("Время между выстрелами")]
    [SerializeField] private float TimeBetweenShots; 
    [SerializeField]private bool _needToShot;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        ShootBolt();
    }

    // Update is called once per frame
    /*   void Update()

    {
        TimeBetweenShots += Time.deltaTime;
        if (TimeBetweenShots > 1)
        {
        Instantiate(_beeBolt,gameObject.transform.position,gameObject.transform.rotation).GetComponent<ShootingBeeTrapBolt>().ParentBee=gameObject;
        TimeBetweenShots = 0;
        }
    }
    */
    public void ShootBolt()
    {
        if (_needToShot)
        {
            _needToShot = false;

        Instantiate(_beeBolt, _shootPoint.transform.position, _shootPoint.transform.rotation).GetComponent<ShootingBeeTrapBolt>().ParentBee = gameObject;
    }
}
    
    
}
