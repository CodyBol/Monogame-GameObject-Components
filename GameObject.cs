using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using TestProject.Component;

namespace TestProject
{
    class GameObject
    {
        /**
         * rectangle is one of the only variables that is not in a component,
         * because it is needed in most of the components
         * 
         * The components contains the components needed for this gameobject
         * This way the gameobject is highly customizable
         */
        public Rectangle rectangle;
        public Vector2 velocity;
        public ComponentContainer components;

        /**
         * set required variables
         */
        public GameObject(Rectangle rect, ComponentContainer componentContainer) {
            rectangle = rect;
            components = componentContainer;
        }

        /**
         * initialize all components.
         * This can be used to communicate between the components and the gameobject
         */
        public void initialize() {
            foreach (UpdateComponent component in components.updateComponents)
            {
                component.initialize(this);
            }
            foreach (DrawComponent component in components.drawComponents)
            {
                component.initialize(this);
            }
        }

        /**
         * run all update components
         */
        public void Update()
        {
            foreach (UpdateComponent component in components.updateComponents) {
                component.Update(this);
            }
            //Debug.WriteLine("left : " + rectangle.Left + "right: " + rectangle.Right);
        }

        /**
         * run all draw components
         */
        public void Draw(SpriteBatch spriteBatch) 
        {
            foreach (DrawComponent component in components.drawComponents)
            {
                component.Draw(this, spriteBatch);
            }
        }

        /**
         * find components in this gameobject
         */
        public ComponentType getComponent<ComponentType>() {

            foreach (UpdateComponent component in components.updateComponents)
            {
                if (component.GetType().Equals(typeof(ComponentType))) {
                    return (ComponentType)component;
                }
            }
            foreach (DrawComponent component in components.drawComponents)
            {
                if (component.GetType().Equals(typeof(ComponentType)))
                {
                    return (ComponentType)component;
                }
            }

            //TODO add stacktrace
            throw new ArgumentException("Type: [" + typeof(ComponentType) + "] does not exists");
        }

        /**
         * checks if component exists in gameobject
         */
        public bool hasComponent<ComponentType>()
        {

            foreach (UpdateComponent component in components.updateComponents)
            {
                if (component.GetType().Equals(typeof(ComponentType)))
                {
                    return true;
                }
            }
            foreach (DrawComponent component in components.drawComponents)
            {
                if (component.GetType().Equals(typeof(ComponentType)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
