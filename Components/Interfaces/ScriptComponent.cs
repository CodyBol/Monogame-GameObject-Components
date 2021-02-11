using Microsoft.Xna.Framework;
using GameObjects;

namespace Component
{
    interface ScriptComponent : BaseComponent
    {
        public void update(GameObject gameObject) { }

        public void lateUpdate(GameObject gameObject) { }

        public void draw(GameObject gameObject) { }

        public void lateDraw(GameObject gameObject) { }

        public void collisionEnter(GameObject collision, Vector2 direction) { }

        public void collisionEnterLate(GameObject collision, Vector2 direction) { }

        public void triggerEnter(GameObject collision, Vector2 direction) { }

        public void onHover(Vector2 mousePosition) { }

        public void onPressed(Vector2 mousePosition, int mouseButton) { }
    }
}
