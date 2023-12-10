using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor : MonoBehaviour
{
    [SerializeField] private GameObject _secondDoor;

    [SerializeField] private Sprite _openDoor;

    [SerializeField] private Sprite _closeDoor;
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
        gameObject.GetComponent<SpriteRenderer>().sprite = _openDoor;
        _secondDoor.GetComponent<Collider2D>().enabled = true;
        _secondDoor.GetComponent<SpriteRenderer>().sprite = _closeDoor;
    }



    public void Close()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite =  _closeDoor;
        _secondDoor.GetComponent<Collider2D>().enabled = false;
        _secondDoor.GetComponent<SpriteRenderer>().sprite = _openDoor;
        
    }
}
