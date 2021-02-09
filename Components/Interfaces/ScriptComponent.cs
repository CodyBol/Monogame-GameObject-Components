using Microsoft.Xna.Framework;

namespace TestProject.Component
{
    interface ScriptComponent : BaseComponent
    {
        public void initialize(GameObject gameObject) { }

        public void update(GameObject gameObject) { }

        public void lateUpdate(GameObject gameObject) { }

        public void draw(GameObject gameObject) { }

        public void lateDraw(GameObject gameObject) { }

        public void collisionEnter(GameObject collision, Vector2 direction) { }

        public void collisionEnterLate(GameObject collision, Vector2 direction) { }

        public void triggerEnter(GameObject collision, Vector2 direction) { }
    }
}
