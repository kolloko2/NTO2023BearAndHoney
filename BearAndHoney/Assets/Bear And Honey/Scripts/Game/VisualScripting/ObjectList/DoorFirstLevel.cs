using System.Linq;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.VisualScripting.ObjectList
{
    public class DoorFirstLevel : VisualScriptingObject
    {
        private GameObject _bear;

        public override void BeforeStart()
        {
            _bear = GameObject.FindWithTag("Player");
            _statemensAndItNames.Add("Игрок рядом");
            _statemensAndItNames.Add("Игрок отошел");
            _statemensAndItNames.Add("Игрок пришел 5 секунд назад");
        }

        private bool _bearNear;

        private bool _bearRuned;
        private float ComeTime = 0;
        public GameObject FirstDoor;
        public GameObject Shipi;


        public override void Statements()
        {
            if (_started)
            {
                StatementsAdder();
                if (_started)
                {
                    if (Vector2.Distance(gameObject.transform.position, _bear.transform.position) <= 2)
                    {
                        _bearNear = true;
                    }
                    else if (_bearNear = true)
                    {
                        _bearRuned = true;
                    }

                    if (_bearNear &
                        !_statementBlockerArray[0]) // всегда  !_statementBlockerArray[0] вместо номер условия 0=>100
                    {
                        StatementBlockerAndRunner(0);
                    }

                    if (_bearRuned & !_statementBlockerArray[1])
                    {
                        StatementBlockerAndRunner(1);
                    }

                    if (ComeTime >= 5 & !_statementBlockerArray[2])
                    {
                        StatementBlockerAndRunner(2);
                    }
                }
            }
        }

        public void StatementsAdder()
        {
            if (_statementBlockerArray[0])

            {
                ComeTime += Time.deltaTime;
            }
        }
    }
}