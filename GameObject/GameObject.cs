﻿using Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameObjects
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
        public List<BaseComponent> components;
        public Layer layer;
        public string tag;

        /**
         * set required variables
         */
        public GameObject(Rectangle rect, Layer objectLayer, List<BaseComponent> componentsList) {
            rectangle = rect;
            layer = objectLayer;
            components = componentsList;
        }

        /**
         * initialize all components.
         * This can be used to communicate between the components and the gameobject
         */
        public void initialize() {
            foreach (BaseComponent component in components)
            {
                component.Init(this);
            }

            foreach (BaseComponent component in components)
            {
                (component as IStart)?.Start();
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

            rectangle.X += (int)velocity.X;
            rectangle.Y += (int)velocity.Y;

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
        public void onTriggerEnter(GameObject collision, Rectangle collideRect, Vector2 direction) {
            foreach (BaseComponent component in components)
            {
                (component as ITrigger)?.triggerEnter(collision, collideRect, direction);
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
        public void onCollisionEnter(GameObject collision, Rectangle collideRect, Vector2 direction)
        {
            foreach (BaseComponent component in components)
            {
                (component as ICollision)?.collisionEnter(collision, collideRect, direction);
            }

            if (direction == new Vector2(1, 0)) {
                rectangle.X = collideRect.Left - rectangle.Width / 2;
                velocity.X = 0;
            }

            if (direction == new Vector2(-1, 0))
            {
                rectangle.X = collideRect.Right + rectangle.Width / 2;
                velocity.X = 0;
            }

            if (direction == new Vector2(0, 1))
            {
                velocity.Y = 0;
                rectangle.Y = collideRect.Top - rectangle.Height / 2;
            }

            if (direction == new Vector2(0, -1))
            {
                velocity.Y = 0;
                rectangle.Y = collideRect.Bottom + rectangle.Height / 2;
            }
        }

        /**
         * find components in this gameobject
         */
        public ComponentType getComponent<ComponentType>() {

            foreach (BaseComponent component in components)
            {
                if (component is ComponentType) {
                    return (ComponentType)(object)component;
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

            foreach (IUpdate component in components)
            {
                if (component is ComponentType)
                {
                    return true;
                }
            }

            return false;
        }

        public Rectangle getRealRect()
        {
            return new Rectangle(rectangle.X - rectangle.Width / 2,
                            rectangle.Y - rectangle.Height / 2,
                            rectangle.Width, rectangle.Height);
        }
    }
}
