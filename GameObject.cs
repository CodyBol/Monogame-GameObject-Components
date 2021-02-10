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
        public Layer layer;
        public string tag;

        /**
         * set required variables
         */
        public GameObject(Rectangle rect, Layer objectLayer, ComponentContainer componentContainer) {
            rectangle = rect;
            layer = objectLayer;
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
            foreach (ScriptComponent component in components.scriptComponents)
            {
                component.initialize(this);
            }
        }

        /**
         * run all update components
         */
        public void Update()
        {
            foreach (ScriptComponent component in components.scriptComponents)
            {
                component.update(this);
            }
            foreach (UpdateComponent component in components.updateComponents) {
                component.Update(this);
            }

            rectangle.X += (int)velocity.X;
            rectangle.Y += (int)velocity.Y;

            foreach (ScriptComponent component in components.scriptComponents)
            {
                component.lateUpdate(this);
            }
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
         * can be added in a extended class
         */
        public void onTriggerEnter(GameObject collision, Vector2 direction) {
            foreach (ScriptComponent component in components.scriptComponents)
            {
                component.triggerEnter(collision, direction);
            }
        }

        /**
         * can be added in a extended class
         */
        public void onHover(Vector2 mousePosition)
        {
            foreach (ScriptComponent component in components.scriptComponents)
            {
                component.onHover(mousePosition);
            }
        }



        /**
         * can be added in a extended class
         */
        public void onPressed(Vector2 mousePosition, int mouseButton)
        {
            foreach (ScriptComponent component in components.scriptComponents)
            {
                component.onPressed(mousePosition, mouseButton);
            }
        }

        /**
         * can be added in a extended class
         */
        public void onCollisionEnter(GameObject collision, Vector2 direction)
        {
            foreach (ScriptComponent component in components.scriptComponents)
            {
                component.collisionEnter(collision, direction);
            }

            if (direction == new Vector2(1, 0)) {
                rectangle.X = collision.rectangle.Left - rectangle.Width;
                velocity.X = 0;
            }

            if (direction == new Vector2(-1, 0))
            {
                rectangle.X = collision.rectangle.Right;
                velocity.X = 0;
            }

            if (direction == new Vector2(0, 1))
            {
                velocity.Y = 0;
                rectangle.Y = collision.rectangle.Top - rectangle.Height;
            }

            if (direction == new Vector2(0, -1))
            {
                velocity.Y = 0;
                rectangle.Y = collision.rectangle.Bottom;
            }

            foreach (ScriptComponent component in components.scriptComponents)
            {
                component.collisionEnterLate(collision, direction);
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
