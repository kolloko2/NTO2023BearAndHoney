using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.VisualScripting.ObjectList
{
    public class ElectricObjectCoding : VisualScriptingObject
    {
        private GameObject _bear;
        public GameObject ElectricBlock;

        public override void BeforeStart()
        {
            _bear = GameObject.FindWithTag("Player");
            _statemensAndItNames.Add("Пока игрок рядом");
            _statemensAndItNames.Add("Пока пчела рядом");
            _statemensAndItNames.Add("Пока игрока нет рядом");
        }

    
        public override void Statements()
        {
            if (_started)
            {
                StatementsAdder();
                if (_started)
                {
                 
                    if (
                        !_statementBlockerArray[0]) // всегда  !_statementBlockerArray[0] вместо номер условия 0=>100
                    {
                        StatementBlockerAndRunner(0);
                    }

                    if ( !_statementBlockerArray[1])
                    {
                        StatementBlockerAndRunner(1);
                    }

                    if (!_statementBlockerArray[2])
                    {
                        StatementBlockerAndRunner(2);
                    
                    }
                }
            }
        }

        public void StatementsAdder()
        {
           
        }
    }
}