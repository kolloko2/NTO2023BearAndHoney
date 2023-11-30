using System;
using System.Collections.Generic;
using System.Linq;
using Bear_And_Honey.Scripts.Game.Markers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;

namespace Bear_And_Honey.Scripts.Game.VisualScripting.ObjectList
{
    public abstract class VisualScriptingObject : MonoBehaviour
    {
        protected List<List<FunctionListEnum>> _currentStatementFunctionList = new List<List<FunctionListEnum>>();


        [SerializeField] FunctionListEnum[] _whatCanBeFunctionList;
        protected VisualScriptingInterpretatorService _visualScriptingInterpretator;
        protected bool[] _statementBlockerArray = new bool[1000];

        protected List<String>
            _statemensAndItNames =
                new List<string>(); // Индитификатор листа = индификатору используемого условия тоесть условие 1 должно быть в StatemensAndInNames[0]=названию первого условия (видно игркоу)

        protected Object _visualScriptingWindow;
        protected Object _statement;
        protected Object _function;

        protected GameObject _visualScriptingWindowGameObject;
        protected List<GameObject> _statementsGameObject = new List<GameObject>();
        protected List<GameObject> _functionsGameObject = new List<GameObject>();
        private static Action<GameObject> VisualSCriptingWindowShow;
        [SerializeField] GameObject _functionInHands;

        RaycastHit2D _raycastHit2D;
        Ray _raycast2D;
        private GameObject _functionList;
        private FunctionListEnum _convertedEnum;

        public virtual void Awake()
        {
        }

        private void OnEnable()
        {
            VisualSCriptingWindowShow += ShowOrHide;
        }

        public void FixedUpdate()
        {
        }


        public void ShowOrHide(GameObject callerGameObject)
        {
            if (callerGameObject != gameObject | _visualScriptingWindowGameObject.activeSelf == true)
            {
                _visualScriptingWindowGameObject.SetActive(false);
            }
            else

            {
                _visualScriptingWindowGameObject.SetActive(true);
            }
        }

        public void OnMouseDown()
        {
            VisualSCriptingWindowShow(gameObject);
        }


        public void Start()
        {
            InitializeBase();
            BeforeStart();


            foreach (Enum enumOfFunction in _whatCanBeFunctionList)
            {
                GameObject a = Instantiate(_function as GameObject,
                    _visualScriptingWindowGameObject.GetComponentInChildren<FunctuionListLayoutMarker>().gameObject
                        .transform);

                a.GetComponent<TextMeshProUGUI>().SetText(enumOfFunction.ToString());
                a.name = enumOfFunction.ToString();

                _functionsGameObject.Add(a);
            }

            foreach (string statementStatemensAndItName in _statemensAndItNames)
            {
                print(0);
                GameObject a = Instantiate(_statement as GameObject,
                    _visualScriptingWindowGameObject.GetComponentInChildren<StatementListMarker>().gameObject
                        .transform);
                print(a);

                a.GetComponent<TextMeshProUGUI>().SetText(statementStatemensAndItName);
            }

            _visualScriptingWindowGameObject.SetActive(false);
        }

        private void InitializeBase()
        {
            _visualScriptingWindow = Resources.Load(Constants.VISUALSCRIPTINGWINDOWRESOURCEPATH);
            _statement = Resources.Load(Constants.STATEMENTRESOURCEPATH);
            _function = Resources.Load(Constants.FUNCTIONRESOURCEPATH);


            _visualScriptingInterpretator = Game.GameInst.ServiceLocatorInst.VisualScriptingInterpretatorServiceInst;
            _visualScriptingWindowGameObject = Instantiate(_visualScriptingWindow as GameObject,
                GameObject.FindWithTag(Constants.MAINLEVELCANVASTAG).gameObject.transform);
            for (int i = 0; i < 100; i++)
            {
                _currentStatementFunctionList.Add(new List<FunctionListEnum>());
            }
        }

        public virtual void BeforeStart()
        {
        }


        public void Update()
        {
            Statements();
            if (Input.GetMouseButtonDown(0))
            {
            


                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetComponent<FunctionMarker>() != null)
                    {
                        _convertedEnum = Enum.Parse<FunctionListEnum>(hit.collider.gameObject.name, true);
                        _functionInHands = hit.collider.gameObject;
                    }

                    if (hit.collider.gameObject.GetComponent<StatementMarker>() != null & _functionInHands != null)
                    {
                        _currentStatementFunctionList[_functionsGameObject.IndexOf(_functionInHands)]
                            .Add(_convertedEnum);


                        _functionInHands.transform.SetParent(hit.collider.gameObject.transform);
                        _functionInHands = null;
                    }
                }
            }
        }


        public virtual void Statements()
        {
        }

        public virtual void StatementBlockerAndRunner(int statementNumber)
        {
            _statementBlockerArray[statementNumber] = true;

            _visualScriptingInterpretator.RunFunctionList(_currentStatementFunctionList[statementNumber], gameObject);
        }
    }
}