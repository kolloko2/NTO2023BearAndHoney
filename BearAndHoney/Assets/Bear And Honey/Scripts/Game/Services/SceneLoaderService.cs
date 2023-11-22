using System;
using System.Collections;
using System.Collections.Generic;
using Bear_And_Honey.Scripts.Game.UI;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Bear_And_Honey.Scripts.Game.Services
{
    public class SceneLoaderService
    {

        private readonly ICoroutineRunner _coroutineRunner;
        private readonly LoadingScreen _loadingCurtains;
   

        public SceneLoaderService()
        {
            _coroutineRunner = Game.GameInst; // присваиваем корутин ранеру класс Game тк он наследник этого интерфейса
            _loadingCurtains = Game.GameInst.LoadingCurtains;




        }

        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadSceneCoroutine(name, onLoaded)); // при вызове лоада вызываем корутины для ассинх операции
        
        
        
        
        
        public IEnumerator LoadSceneCoroutine(string name, Action onLoaded = null)
        {
            
            _loadingCurtains.Show();

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name); // Вызываем AsyncОперацию которая является загрузкой сцены по имени


            while (!waitNextScene.isDone) // пока сцена не загруженна входим в бескоч цикл
            {

                yield return null;
            }
            _loadingCurtains.Hide();
            



        }
        
        
    
    
    }
}

