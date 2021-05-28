using Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameObjects;
using System.Diagnostics;
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
