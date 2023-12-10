using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickScript : MonoBehaviour
{
    public bool Downed;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Downed)
        {
            _animator.SetTrigger("Upped");
            Downed = false;
        }
        else


        {
            _animator.SetTrigger("Downed");
            Downed = true;
        }
    }
}
