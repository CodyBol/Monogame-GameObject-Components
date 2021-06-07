using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Engine.Component
{
    public class Camera : BaseComponent, ILateUpdate
    {
        public Matrix Transform;
        public Vector2 Target;

        private Matrix _offset;
        
        public Camera(Vector2 GameSize) 
        {
            _offset = Matrix.CreateTranslation(GameSize.X / 2, GameSize.Y / 2, 0);
        }

        public void LateUpdate() {
            Debug.WriteLine(Transform);
            Transform = Matrix.CreateTranslation(-Target.X, -Target.Y, 0) * _offset;
        }
    }
}
