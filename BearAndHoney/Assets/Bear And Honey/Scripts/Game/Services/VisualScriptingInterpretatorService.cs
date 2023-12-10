using System;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game.VisualScripting.ObjectList;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Bear_And_Honey.Scripts.Game.VisualScripting
{
    public class VisualScriptingInterpretatorService
    {
        public void RunFunctionList(List<FunctionListEnum> functionListEnums, GameObject objectCaller)
        {
            foreach (var functionType in functionListEnums)
            {
                switch (functionType)
                {
                    case FunctionListEnum.MoveLeft:
                        objectCaller.transform.Translate(5, 5, 1);
                        break;
                    case FunctionListEnum.MoveRight:

                        objectCaller.transform.Translate(15, 15, 1);
                        break;
                    case FunctionListEnum.DestroyShips:
                    {
                        if (objectCaller.GetComponent<DoorFirstLevel>() != null)
                        {
                            GameObject.Destroy(objectCaller.GetComponent<DoorFirstLevel>().Shipi);
                        }

                        break;
                    }
                    case FunctionListEnum.OpenFirstDoor:
                    {
                        objectCaller.GetComponent<DoorFirstLevel>().FirstDoor.GetComponent<FirstDoor>().Open();
                        break;
                    }
                    case FunctionListEnum.CloseFirstDoor:
                    {
                        objectCaller.GetComponent<DoorFirstLevel>().FirstDoor.GetComponent<FirstDoor>().Close();
                        break;
                    }
                    case FunctionListEnum.UpVent:
                    {
                        objectCaller.GetComponent<AirVent>().AirVentPrefab.GetComponent<Collider2D>().enabled=true;
                        break;
                    }
                    case FunctionListEnum.DownVent:
                    {



                        foreach (var VARIABLE in objectCaller.GetComponent<AirVent>().Enemies)
                        {
                            Game.Destroy(VARIABLE);
                        }
                        objectCaller.GetComponent<AirVent>().AirVentPrefab.GetComponent<Collider2D>().enabled = false;
                        break;
                    }
                    case FunctionListEnum.TurnOnVent:
                    {
                        objectCaller.GetComponent<AirVent>().AirVentPrefab.GetComponent<AirVentBlock>().TurnedOn=true;
                        
                        break;
                    }
                    case FunctionListEnum.GiveEnergy:
                    {
                        objectCaller.GetComponent<ElectricObjectCoding>().ElectricBlock.GetComponent<ElectricObject>().ScriptCorrect =
                            true;
                        break;
                    }
                    case FunctionListEnum.GiveEnergyVNikuda:
                    {
                        break;
                    }
                    case FunctionListEnum.GiveEnergyVNikuda2:
                    {
                        break;
                    }
                    case FunctionListEnum.SendCodeOneFirst:
                    {
                        objectCaller.GetComponent<SecondState>().Code1 = true;
                        break;
                    }
                    case FunctionListEnum.SendCodeTwoFirst:
                    {
                        objectCaller.GetComponent<FirstState>().Code1 = true;
                        break;
                    }
                    case FunctionListEnum.SendCodeOneSecond:
                    {
                        objectCaller.GetComponent<SecondState>().Code2 = true;
                        break;
                    }
                    case FunctionListEnum.SendCodeTwoSecond:
                    {
                        objectCaller.GetComponent<FirstState>().Code2 = true;
                        break;
                    }
                    case FunctionListEnum.TurnOnBlackHole:

                    {
                        objectCaller.GetComponent<SecondState>().ElectricBlock.GetComponent<BlackHole>().FirstRight =
                            true;
                        
                        break;
                    }
                    
                    default:
                        Debug.Log("Такой ENUM не назначен в кейсах, проспитесь");
                        break;
                }
            }
        }
    }
}