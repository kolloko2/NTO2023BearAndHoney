using System.Collections;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game;
using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadSceneWithName(string name)
    {
        
        {
            Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.LoadScene(name);
        }
        
    }
    public void LoadSceneWithIndex(int index)
    {
        
        {
            Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.LoadScene(index);
        }
        
    }
    public void LoadSavedLevel()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEINGAME",0)==0)
        {
            print(123);
            Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.LoadScene(Constants.VIDEOINTROSCENE);
            PlayerPrefs.SetInt("FIRSTTIMEINGAME",1);

            
            
            
        }
            
        else if  (PlayerPrefs.GetInt("Level",0)==0)
        {
            Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.LoadScene(Constants.FIRTQUESTLEVELSCENE);

            
            
            
        }
        
        else
        {
            Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.LoadScene(PlayerPrefs.GetInt("Level"));
        }
        
    }
}