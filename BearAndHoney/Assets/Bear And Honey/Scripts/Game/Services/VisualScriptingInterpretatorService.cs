using System;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game.VisualScripting.ObjectList;
using Unity.Mathematics;
using UnityEngine;

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
                        objectCaller.transform.Translate(5,5,1);
                        break;
                    case FunctionListEnum.MoveRight:
                       
                        objectCaller.transform.Translate(15,15,1);
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
                { objectCaller.GetComponent<DoorFirstLevel>().FirstDoor.GetComponent<FirstDoor>().Open();
                    break; 
                }
                case FunctionListEnum.CloseFirstDoor:
                {
                    objectCaller.GetComponent<DoorFirstLevel>().FirstDoor.GetComponent<FirstDoor>().Close();
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