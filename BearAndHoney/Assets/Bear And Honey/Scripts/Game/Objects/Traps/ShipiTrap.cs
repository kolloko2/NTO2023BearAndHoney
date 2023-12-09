using Bear_And_Honey.Scripts.Game.Player.Bear;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.Objects.Traps
{
    public class ShipiTrap : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<BearController>())
            {
                Game.GameInst.ServiceLocatorInst.ActionServiceInst.BearDeathActionCaller(gameObject);
           
               
            }
        }
    }
}