﻿using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using GameObjects;

namespace Component
{
    static class ComponentBuild
    {
        public static ComponentContainer createContainer() {
            ComponentContainer container = new ComponentContainer();
            container.updateComponents = new List<IUpdate>();
            container.drawComponents = new List<IDraw>();
            container.scriptComponents = new List<ScriptComponent>();

            return container;
        }

        /*public static ComponentContainer Animation(float animationSpeed, Dictionary<string, AnimationState> animationState) {
            ComponentContainer container = ComponentBuild.createContainer();
            container.updateComponents.Add(new Animate(animationSpeed, animationState));

            //get first
            foreach (KeyValuePair<string, AnimationState> anState in animationState) {
                container.drawComponents.Add(new SpriteRenderer(anState.Value.sprites[0]));
            }
            

            return container;
        }*/
    }
}