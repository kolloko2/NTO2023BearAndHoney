using System.Linq;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.VisualScripting.ObjectList
{
    public class DoorFirstLevel : VisualScriptingObject
    {



        public override void BeforeStart()
        {

            _statemensAndItNames.Add("Если ты Русский");
            
        }

        
    public override void Statements()
        {
            print(transform.position);
            if (transform.position==new Vector3(0,0,0) & !_statementBlockerArray[0])
            {
                StatementBlockerAndRunner(0);
            }
            


        }
    }
}