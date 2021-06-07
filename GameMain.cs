using Engine;
using TestProject.GameStates;

namespace TestProject
{
   
    public class GameMain : GameCore
    {
        protected override void LoadContent()
        {
            base.LoadContent();
            DevMode = true;

            GameStateManager.AddState("Playing", new PlayingState());
            GameStateManager.ChangeState("Playing");
            
        }
    }
}
