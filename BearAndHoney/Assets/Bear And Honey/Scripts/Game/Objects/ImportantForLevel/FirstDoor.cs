using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor : MonoBehaviour
{
    [SerializeField] private GameObject _secondDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        _secondDoor.GetComponent<Collider2D>().enabled = true;
    }



    public void Close()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
        _secondDoor.GetComponent<Collider2D>().enabled = false;
        
    }
}
