using Bear_And_Honey.Scripts.Game.Services;
using Bear_And_Honey.Scripts.Game.UI;
using Unity.VisualScripting;
using UnityEngine;

namespace Bear_And_Honey.Scripts.Game
{
    public class Game : MonoBehaviour, ICoroutineRunner
    {

        public static Game GameInst; // Создаем едиснтвенный экземпляр класса тк.статика
        public LoadingScreen LoadingCurtains;
        public ServicesLocator ServiceLocatorInst;
        public AudioSource _audioSource;

        private void Start() // при спавне
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = PlayerPrefs.GetFloat("MusicVolume",1f);
            if (GameInst == null) // если нет на сцене
            {
                GameInst = this; // записываем
                //Дальше записываем начальные действия, а именнно инициализацию дальше по иерархии >
                ServiceLocatorInst = new ServicesLocator(); // Создаем сервис локатор


                ServiceLocatorInst.SceneLoaderServiceInst.LoadScene(Constants.MAINMENUSCENE);

            }
            else
            {
                Destroy(this.gameObject); // если как-то создалось 2 гейма (КАК ?????) то убираем лишний

            }

            DontDestroyOnLoad(
                gameObject); // записываем геймобджект к которому прилеплен монобех в пулл объектов которые не удаляются при изменении сцены
            DontDestroyOnLoad(LoadingCurtains); // тоже самое с loadingcurtains



        }

        private void Update()
        {
         
        }



}
    
    
 

    
    
    
}