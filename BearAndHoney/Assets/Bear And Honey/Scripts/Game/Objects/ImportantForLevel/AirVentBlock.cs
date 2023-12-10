using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVentBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public bool TurnedOn;
    [SerializeField] private List<Animator> _animator;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnedOn)
        {
            foreach (var VARIABLE in _animator)
            {
            VARIABLE.enabled = true;
                
            }
        }
    }
}
