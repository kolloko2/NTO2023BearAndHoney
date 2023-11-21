namespace Bear_And_Honey.Scripts.Game.Services
{
    public class ServicesLocator
    {
        public SceneSwapService SceneSwapServiceInst;
        
      


        public ServicesLocator()
        {
            
            
            SceneSwapServiceInst = new SceneSwapService(); // создаем сервер для смены сцен
            
        }
    }
}