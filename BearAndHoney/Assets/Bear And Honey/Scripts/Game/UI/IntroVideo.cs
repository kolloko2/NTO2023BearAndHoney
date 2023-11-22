using System;
using System.Collections;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game;
using UnityEngine;
using UnityEngine.Video;

public class IntroVideo : MonoBehaviour
{
    // Start is called before the first frame update
   
    
    private void OnEnable()
    {
         gameObject.GetComponent<VideoPlayer>().loopPointReached += LoadNextScene ;
    }

    private void OnDisable()
    {
        
    }

    void LoadNextScene(VideoPlayer videoPlayer)
    {
        Debug.Log("123");
        Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.Load(Constants.FIRTQUESTLEVELSCENE);
    }
 
}
