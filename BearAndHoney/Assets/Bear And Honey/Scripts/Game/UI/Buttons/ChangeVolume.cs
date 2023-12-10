using System.Collections;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game;
using UnityEngine;

public class ChangeVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValueChanged(float Value)
    {
        Game.GameInst._audioSource.volume = Value;
        PlayerPrefs.SetFloat("MusicVolume",Value);
        PlayerPrefs.Save();
    }
}
