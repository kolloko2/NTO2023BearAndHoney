using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressClearButton : MonoBehaviour
{
    public void ClearAllProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
