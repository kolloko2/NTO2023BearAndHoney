using System;
using System.Collections.Generic;
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
                       
                            objectCaller.transform.position = Vector3.Lerp(objectCaller.transform.position,
                                new Vector3(10, 10, 5), 1f);
                     

                        break;
                    default:
                        Debug.Log("Такой ENUM не назначен в кейсах, проспитесь");
                        break;
                    
                }

            }
         
            
            
            
            
            
        }




    }
}