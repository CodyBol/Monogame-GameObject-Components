using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TestProject.Component
{
    static class ComponentBuild
    {
        private static ComponentContainer createContainer() {
            ComponentContainer container = new ComponentContainer();
            container.updateComponents = new List<UpdateComponent>();
            container.drawComponents = new List<DrawComponent>();
            container.scriptComponents = new List<ScriptComponent>();

            return container;
        }

        public static ComponentContainer Animation(float animationSpeed, List<Texture2D> sprites) {
            ComponentContainer container = ComponentBuild.createContainer();
            container.updateComponents.Add(new Animate(animationSpeed, sprites));
            container.drawComponents.Add(new SpriteRenderer(sprites[0]));

            return container;
        }
    }
}
