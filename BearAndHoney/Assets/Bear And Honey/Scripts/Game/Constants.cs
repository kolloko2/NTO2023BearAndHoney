using System;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game.VisualScripting;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game
{
    public static class Constants 
    {
       // Лоадим сцены через имя чтобы мы не меняли везде название сцены если вдруг сменили его в уньке
       public static string MAINMENUSCENE = "MainMenuScene"; 
       public static string VIDEOINTROSCENE = "VideoIntroScene";
       public static string FIRTQUESTLEVELSCENE = "FirstQuestLevelScene";
       public static string VISUALSCRIPTINGWINDOWRESOURCEPATH = "Prefabs/VisualScriptingWindow";
       public static string STATEMENTRESOURCEPATH = "Prefabs/Statement";
       public static string FUNCTIONRESOURCEPATH = "Prefabs/Function";
       public static string MAINLEVELCANVASTAG = "MainLevelCanvas";
       public static Dictionary<FunctionListEnum, string> FUNCTIONTRANSLATIONDICTIONARY = new Dictionary<FunctionListEnum, string>()
           
       {
           {FunctionListEnum.MoveLeft, "Подвинуться налево"},
           { FunctionListEnum.MoveRight, "Подвинуться направо"},
           { FunctionListEnum.DestroyShips, "Уничтожить шипы" },
           { FunctionListEnum.OpenFirstDoor, "Открыть первую дверь"},
           { FunctionListEnum.CloseFirstDoor, "Закрыть первую дверь"},
           { FunctionListEnum.TurnOnVent, "Включить вентиляторы" },
       { FunctionListEnum.UpVent, "Режим работы вверх"},
       { FunctionListEnum.DownVent, "Режим работы вниз"},
       { FunctionListEnum.GiveEnergy, "Подать энергию на вентилятор"},
       { FunctionListEnum.GiveEnergyVNikuda, "Подать энергию на двери"},
       { FunctionListEnum.GiveEnergyVNikuda2, "Подать энергию на рычаг"},
       { FunctionListEnum.SendCodeOneFirst, "Подать сигнал один"},
       { FunctionListEnum.SendCodeOneSecond, "Подать сигнал два"},
       { FunctionListEnum.SendCodeTwoFirst, "Подать сигнал один"},
       { FunctionListEnum.SendCodeTwoSecond, "Подать сигнал два"},
       { FunctionListEnum.TurnOnBlackHole, "Включить кротовую нору"}
       };

    }
}