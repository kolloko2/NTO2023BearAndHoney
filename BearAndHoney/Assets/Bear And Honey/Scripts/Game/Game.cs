using Bear_And_Honey.Scripts.Game.Services;
using Unity.VisualScripting;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game
{
    public  class Game : MonoBehaviour, ICoroutineRunner
    {

        public static Game GameInst; // Создаем едиснтвенный экземпляр класса тк.статика
        public ServicesLocator ServiceLocatorInst; 

        private void Start() // при спавне
        {
            if (GameInst == null) // если нет на сцене
            {
                GameInst = this; // записываем
                //Дальше записываем начальные действия, а именнно инициализацию дальше по иерархии >
                ServiceLocatorInst = new ServicesLocator(); // Создаем сервис локатор


                ServiceLocatorInst.SceneSwapServiceInst.Load("SampleScene");

            }
            else 
            {
                Destroy(this.gameObject); // если как-то создалось 2 гейма (КАК ?????) то убираем лишний
                
            }
            DontDestroyOnLoad(gameObject); // записываем геймобджект к которому прилеплен монобех в пулл объектов которые не удаляются при изменении сцены
            
            
            
            
        }



    }
    
    
 

    
    
    
}