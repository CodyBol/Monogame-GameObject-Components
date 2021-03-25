using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using GameObjects;
using Microsoft.Xna.Framework;

namespace Component
{
    public class Camera : BaseComponent, IUpdate
    {
        public Matrix Transform;
        public Vector2 Target;

        private Matrix _offset;
        
        public Camera(Vector2 GameSize) 
        {
            _offset = Matrix.CreateTranslation(GameSize.X / 2, GameSize.Y / 2, 0);
        }

        public void Update() {
            Debug.WriteLine(Transform);
            Transform = Matrix.CreateTranslation(-Target.X, -Target.Y, 0) * _offset;
        }
    }
}
