using System.Linq;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.VisualScripting.ObjectList
{
    public class DoorFirstLevel : VisualScriptingObject
    {

        float a = 0;

        public override void BeforeStart()
        {

            _statemensAndItNames.Add("Если ты 0 кордах");
            _statemensAndItNames.Add("Прошло 5 секунд со старта");
            
        }

        
    public override void Statements()
    {
              StatementsAdder();
            if (transform.position==new Vector3(0,0,0) & !_statementBlockerArray[0]) // всегда  !_statementBlockerArray[0] вместо номер условия 0=>100
            {
                StatementBlockerAndRunner(0); // опять номер условия
            }
            if (a>5 & !_statementBlockerArray[1]) 
            {
                StatementBlockerAndRunner(1); // опять номер условия
            }


        }
    public void StatementsAdder()
    {
        if (_statementBlockerArray[0])
            
        {
        a += Time.deltaTime;
            
        }
    }
    
    
    
    }
  
}