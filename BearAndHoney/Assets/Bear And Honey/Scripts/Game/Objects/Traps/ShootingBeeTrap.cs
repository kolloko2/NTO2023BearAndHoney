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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        TimeBetweenShots += Time.deltaTime;
        if (TimeBetweenShots > 1)
        {
        Instantiate(_beeBolt,gameObject.transform.position,gameObject.transform.rotation).GetComponent<ShootingBeeTrapBolt>().ParentBee=gameObject;
        TimeBetweenShots = 0;
        }
    }
    
    
}
