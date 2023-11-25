using Bear_And_Honey.Scripts.Game.VisualScripting;

namespace Bear_And_Honey.Scripts.Game.Services
{
    public class ServicesLocator
    {
        public SceneLoaderService SceneLoaderServiceInst;
        public ComputerInputService ComputerInputServiceInst;
        public VisualScriptingInterpretatorService VisualScriptingInterpretatorServiceInst;
      


        public ServicesLocator()
        {
            
            
            SceneLoaderServiceInst = new SceneLoaderService(); // создаем сервер для смены сцен
            VisualScriptingInterpretatorServiceInst = new VisualScriptingInterpretatorService();
        }
    }
}