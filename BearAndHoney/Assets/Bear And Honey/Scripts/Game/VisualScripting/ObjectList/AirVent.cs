using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.VisualScripting.ObjectList
{
    public class AirVent : VisualScriptingObject
    {
        private GameObject _bear;

        public override void BeforeStart()
        {
            _bear = GameObject.FindWithTag("Player");
            _statemensAndItNames.Add("Рычаг нажат");
            _statemensAndItNames.Add("Рычаг отжат");
            _statemensAndItNames.Add("Прошло 5 секунд с момента нажатия");
        }

        [SerializeField]private float ComeTime = 0;
        [SerializeField] private GameObject Stick;
 
        [SerializeField] private GameObject Electric;
        public GameObject AirVentPrefab;
        public List<GameObject> Enemies = new List<GameObject>();

        public override void Statements()
        {
            if (_started)
            {
                StatementsAdder();
                if (_started & Electric.GetComponent<ElectricObject>().Powered==true)
                {
                 
                    if (Stick.GetComponent<StickScript>().Downed &
                        !_statementBlockerArray[0]) // всегда  !_statementBlockerArray[0] вместо номер условия 0=>100
                    {
                        StatementBlockerAndRunner(0);
                    }

                    if (!Stick.GetComponent<StickScript>().Downed  & _statementBlockerArray[0] & !_statementBlockerArray[1])
                    {
                        StatementBlockerAndRunner(1);
                    }

                    if (ComeTime >= 5 & !_statementBlockerArray[2])
                    {
                        StatementBlockerAndRunner(2);
                        print(123);
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