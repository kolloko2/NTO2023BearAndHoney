using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public bool FirstRight;

  
    public GameObject BeeEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstRight)
        {
            Destroy(BeeEnemy);
        }
    }
}
