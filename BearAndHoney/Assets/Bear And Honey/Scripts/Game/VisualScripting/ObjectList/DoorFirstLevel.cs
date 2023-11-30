using System.Linq;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.VisualScripting.ObjectList
{
    public class DoorFirstLevel : VisualScriptingObject
    {



        public override void BeforeStart()
        {

            _statemensAndItNames.Add("Если ты 0 кордах");
            
            
        }

        
    public override void Statements()
        {
            if (transform.position==new Vector3(0,0,0) & !_statementBlockerArray[0]) // всегда  !_statementBlockerArray[0] вместо номер условия 0=>100
            {
                StatementBlockerAndRunner(0); // опять номер условия
            }
            


        }
    }
}