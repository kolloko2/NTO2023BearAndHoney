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
        protected List<List<GameObject>> _currentStatementGameobjectList = new List<List<GameObject>>();

        protected List<GameObject> _statementsGameObject = new List<GameObject>();
        protected List<GameObject> _lastFunctions = new List<GameObject>();

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
        protected List<GameObject> _functionsGameObject = new List<GameObject>();
        private static Action<GameObject> VisualSCriptingWindowShow;
        [SerializeField] GameObject _functionInHands;
        protected bool _started;
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
        private void OnDisable()
        {
            VisualSCriptingWindowShow -= ShowOrHide;
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


            foreach (FunctionListEnum enumOfFunction in _whatCanBeFunctionList)
            {
                GameObject a = Instantiate(_function as GameObject,
                    _visualScriptingWindowGameObject.GetComponentInChildren<FunctionListLayoutMarker>().gameObject
                        .transform);

                a.GetComponent<TextMeshProUGUI>().SetText(Constants.FUNCTIONTRANSLATIONDICTIONARY[enumOfFunction]);
                a.name = enumOfFunction.ToString();

                _functionsGameObject.Add(a);
            }

            foreach (string statementStatemensAndItName in _statemensAndItNames)
            {
    
                GameObject a = Instantiate(_statement as GameObject,
                    _visualScriptingWindowGameObject.GetComponentInChildren<StatementListMarker>().gameObject
                        .transform);
               

                a.GetComponent<TextMeshProUGUI>().SetText(statementStatemensAndItName);
                _statementsGameObject.Add(a);
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
                _currentStatementGameobjectList.Add(new List<GameObject>());
            }
        }

        public virtual void BeforeStart()
        {
        }


        public void Update()
        {
            Statements();
print(_functionInHands);

            if (_visualScriptingWindowGameObject.GetComponent<StartVisualButton>().Started)
            {
                _started = true;
                _visualScriptingWindowGameObject.SetActive(false);
            }
            if (Input.GetMouseButtonDown(0) & _visualScriptingWindowGameObject.activeSelf)
            {



                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                if (hit.collider != null)
                {
               
                    if ((hit.collider.gameObject.GetComponent<FunctionMarker>() != null) & !_functionInHands)
                    {
                        _convertedEnum = Enum.Parse<FunctionListEnum>(hit.collider.gameObject.name, true);
                        _functionInHands = hit.collider.gameObject;
                        _functionInHands.GetComponent<TextMeshProUGUI>().color = Color.green;

                    }

                    if (hit.collider.gameObject.GetComponent<StatementMarker>() != null & _functionInHands != null) 
                    {
                        if (!_functionInHands.GetComponent<FunctionMarker>().Busy)
                        {
                            _currentStatementFunctionList[_statementsGameObject.IndexOf(hit.collider.gameObject)].Add(_convertedEnum);
                            _currentStatementGameobjectList[_statementsGameObject.IndexOf(hit.collider.gameObject)].Add(_functionInHands);
                            _functionInHands.GetComponent<FunctionMarker>().Busy = true;

                            _functionInHands.transform.SetParent(hit.collider.gameObject.transform);
                            _functionInHands.GetComponent<FunctionMarker>().CurrentStatement = _statementsGameObject.IndexOf(hit.collider.gameObject);
                            _functionInHands.GetComponent<TextMeshProUGUI>().color = Color.white;

                            _functionInHands = null;
                        }

                    }
                    
                    if (hit.collider.gameObject.tag == "FunctionList" & _functionInHands != null)
                    {
                        if(_functionInHands.GetComponent<FunctionMarker>().Busy)
                        {

                            int index = _currentStatementGameobjectList[_functionInHands.GetComponent<FunctionMarker>().CurrentStatement].IndexOf(_functionInHands);
                            print(index);
                            print(_currentStatementGameobjectList[
                                _functionInHands.GetComponent<FunctionMarker>().CurrentStatement].Count);
                        _currentStatementGameobjectList[_functionInHands.GetComponent<FunctionMarker>().CurrentStatement].RemoveAt(index);
                   
                        _currentStatementFunctionList[_functionInHands.GetComponent<FunctionMarker>().CurrentStatement].RemoveAt(index);

                        
                        _functionInHands.GetComponent<FunctionMarker>().CurrentStatement =  -1;
                        _functionInHands.GetComponent<FunctionMarker>().Busy = false;
                        _functionInHands.transform.SetParent(hit.collider.gameObject.transform.GetComponentInChildren<FunctionListLayoutMarker>().gameObject.transform);
                        _functionInHands.GetComponent<TextMeshProUGUI>().color = Color.white;

                        _functionInHands = null;
                        }
                        else
                        {
                            _functionInHands.GetComponent<TextMeshProUGUI>().color = Color.white;

                            _functionInHands = null;

                        }
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