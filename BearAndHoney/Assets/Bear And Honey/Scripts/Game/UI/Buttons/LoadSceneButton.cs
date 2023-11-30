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
        if (PlayerPrefs.GetInt("FIRSTTIMEINGAME")==1)
        {
            Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.LoadScene(Constants.FIRTQUESTLEVELSCENE);
            

            
            
            
        }
            
        else
        {
            Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.LoadScene(PlayerPrefs.GetInt("Level"));
        }
        
    }
}