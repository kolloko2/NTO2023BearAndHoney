using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Bear_And_Honey.Scripts.Game.Services
{
    public class SceneSwapService
    {

        private readonly ICoroutineRunner _coroutineRunner;

        public SceneSwapService()
        {
            _coroutineRunner = Game.GameInst; // присваиваем корутин ранеру класс Game тк он наследник этого интерфейса
        }

        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded)); // при вызове лоада вызываем корутины для ассинх операции
        
        
        
        
        
        public IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            
      
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name); // Вызываем AsyncОперацию которая является загрузкой сцены по имени


            while (!waitNextScene.isDone) // пока сцена не загруженна входим в бескоч цикл
            {
                yield return null;
            }
            
            
            
   
            
        }
        
        
    
    
    }
}

