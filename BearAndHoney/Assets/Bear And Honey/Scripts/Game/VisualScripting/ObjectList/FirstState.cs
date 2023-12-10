using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.VisualScripting.ObjectList
{
    public class FirstState : VisualScriptingObject
    {
    
        public GameObject ElectricBlock;
        public bool Code1;
        public bool Code2;
        public GameObject SecondStatePrfab;
        public override void BeforeStart()
        {
    
            _statemensAndItNames.Add("Начало");
            _statemensAndItNames.Add("Пришел  код 2");
            _statemensAndItNames.Add("Рядом боченок");
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

                    if (Code2 & !_statementBlockerArray[1])
                    {
                        StatementBlockerAndRunner(1);
                    }

                    if (false)
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