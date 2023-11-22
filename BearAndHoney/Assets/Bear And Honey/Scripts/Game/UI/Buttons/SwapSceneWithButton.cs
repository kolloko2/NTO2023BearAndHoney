using System.Collections;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game;
using UnityEngine;

public class SwapSceneWithButton : MonoBehaviour
{
    public void LoadSceneWithName(string name)
    {
        if (name == Constants.VIDEOINTROSCENE)
        {
            if (PlayerPrefs.GetInt("FIRSTTIMENETER", 0) == 0)
            {
                
                PlayerPrefs.SetInt("FIRSTTIMENETER",1);
                Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.Load(name);
            }
            else
            {
                Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.Load(Constants.FIRTQUESTLEVELSCENE);
            }
        }
        else
        {
            Game.GameInst.ServiceLocatorInst.SceneLoaderServiceInst.Load(name);
        }
    }
}