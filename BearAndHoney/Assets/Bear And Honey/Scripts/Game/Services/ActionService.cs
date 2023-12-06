using System;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.Services
{
    public class ActionService
    {

        public  Action<GameObject> BearDeathAction;
        public ActionService()
        {
            
            
        }

        public void BearDeathActionCaller(GameObject gameObject)
        {
            BearDeathAction?.Invoke(gameObject);
        }
    }
}   