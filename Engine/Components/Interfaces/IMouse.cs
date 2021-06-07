using Microsoft.Xna.Framework;

namespace Engine.Component
{
    public interface IMouse
    {
        public void OnHover(Vector2 mousePosition);

        public void OnPressed(Vector2 mousePosition, int mouseButton);
    }
}
