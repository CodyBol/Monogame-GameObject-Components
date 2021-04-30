using Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using BoundingBox = Engine.Misc.BoundingBox;

namespace GameObjects
{
    public class GameObject
    {
        /**
         * rectangle is one of the only variables that is not in a component,
         * because it is needed in most of the components
         * 
         * The components contains the components needed for this gameobject
         * This way the gameobject is highly customizable
         */
        //public Rectangle rectangle;
        public BoundingBox BoundingBox;

        public Vector2 velocity;
        public List<BaseComponent> components;
        public Layer layer;
        public string tag;

        /**
         * set required variables
         */
        public GameObject(BoundingBox boundingBox, Layer objectLayer, List<BaseComponent> componentsList)
        {
            BoundingBox = boundingBox;
            layer = objectLayer;
            components = componentsList;
        }

        /**
         * initialize all components.
         * This can be used to communicate between the components and the gameobject
         */
        public void initialize()
        {
            foreach (BaseComponent component in components)
            {
                component.Init(this);
            }
        }

        /**
         * run all update components
         */
        public void Update()
        {
            foreach (BaseComponent component in components)
            {
                (component as IUpdate)?.Update();
            }

            BoundingBox.Position.X += (int) velocity.X;
            BoundingBox.Position.Y += (int) velocity.Y;

            foreach (BaseComponent component in components)
            {
                (component as ILateUpdate)?.LateUpdate();
            }
        }

        /**
         * run all draw components
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseComponent component in components)
            {
                (component as IDraw)?.Draw(spriteBatch);
            }
        }

        /**
         * can be added in a extended class
         */
        public void onTriggerEnter(GameObject collision)
        {
            foreach (BaseComponent component in components)
            {
                (component as ITrigger)?.triggerEnter(collision);
            }
        }

        /**
         * can be added in a extended class
         */
        public void onHover(Vector2 mousePosition)
        {
            foreach (BaseComponent component in components)
            {
                (component as IMouse)?.onHover(mousePosition);
            }
        }


        /**
         * can be added in a extended class
         */
        public void onPressed(Vector2 mousePosition, int mouseButton)
        {
            foreach (BaseComponent component in components)
            {
                (component as IMouse)?.onPressed(mousePosition, mouseButton);
            }
        }

        /**
         * can be added in a extended class
         */
        public void onCollisionEnter(GameObject collision, Vector2 direction)
        {
            foreach (BaseComponent component in components)
            {
                (component as ICollision)?.collisionEnter(collision, direction);
            }

            if (direction == new Vector2(-1, 0))
            {
                BoundingBox.Position.X = collision.BoundingBox.Left().X - BoundingBox.Width() / 2;
                velocity.X = 0;
            }

            if (direction == new Vector2(1, 0))
            {
                BoundingBox.Position.X = collision.BoundingBox.Right().X + BoundingBox.Width() / 2;
                velocity.X = 0;
            }

            if (direction == new Vector2(0, -1))
            {
                velocity.Y = 0;
                BoundingBox.Position.Y = collision.BoundingBox.Top().Y - BoundingBox.Height() / 2;
            }

            if (direction == new Vector2(0, 1))
            {
                velocity.Y = 0;
                BoundingBox.Position.Y = collision.BoundingBox.Bottom().Y + BoundingBox.Height() / 2;
            }
        }

        /**
         * find components in this gameobject
         */
        public ComponentType getComponent<ComponentType>()
        {
            foreach (BaseComponent component in components)
            {
                if (component is ComponentType)
                {
                    return (ComponentType) (object) component;
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
            foreach (BaseComponent component in components)
            {
                if (component is ComponentType)
                {
                    return true;
                }
            }

            return false;
        }
    }
}