using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game.VisualScripting
{
    public class VisualScriptingInterpretatorService
    {
     

      
    public void RunFunctionList(List<FunctionListEnum> functionListEnums, GameObject objectCaller)
        {


            foreach (FunctionListEnum functionType in functionListEnums)
            {
                switch (functionType)
                {
                
                    case FunctionListEnum.MoveLeft:
                        objectCaller.transform.position += new Vector3(5, 5, 5);
                        break;
                    case FunctionListEnum.MoveRight:
                        objectCaller.transform.position += new Vector3(-5, -5, -5);
                        break;
                    default:
                        Debug.Log("Такой ENUM не назначен в кейсах, проспитесь");
                        break;
                    
                }

            }
         
            
            
            
            
            
        }




    }
}