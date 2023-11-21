using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.Services
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);

    }
}