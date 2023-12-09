using System;
using System.Collections;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
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
            
            
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("Level",nextScene);
        PlayerPrefs.Save();
        print(gameObject.name);
         Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.LoadScene(nextScene);
        }
    
     
    
    }
}
