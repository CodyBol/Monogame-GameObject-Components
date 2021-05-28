using Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Engine.Misc;
using BoundingBox = Engine.Misc.BoundingBox;

namespace GameObjects
{
    public class GameObject
    {
        private BoundingBox _boundingBox;
        public HitBox _hitbox;

        /**
         * rectangle is one of the only variables that is not in a component,
         * because it is needed in most of the components
         * 
         * The components contains the components needed for this gameobject
         * This way the gameobject is highly customizable
         */
        //public Rectangle rectangle;
        public BoundingBox BoundingBox
        {
            get
            {
                if (Parent != null)
                {
                    BoundingBox box = new BoundingBox();
                    box.Position = _boundingBox.Position + Parent.BoundingBox.Position;
                    box.Scale = _boundingBox.Scale + Parent.BoundingBox.Scale;
                    box.Size = _boundingBox.Size;

                    return box;
                }

                return _boundingBox;
            }

            set { _boundingBox = value; }
        }

        public BoundingBox HitBox
        {
            get
            {
                BoundingBox box = BoundingBox.Copy();

                if (_hitbox != null)
                {
                    box.Scale = _hitbox.Scale;
                    box.Size = _hitbox.Size;
                }

                return box;
            }
            
            set { _hitbox = new HitBox(value.Scale, value.Size); }

        }
        
        public Vector2 velocity;
        public List<BaseComponent> components;
        public GameObject Parent;
        public List<GameObject> Children { private set; get; }
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
            Children = new List<GameObject>();
        }

        /**
         * initialize all components.
         * This can be used to communicate between the components and the gameobject
         */
        public void initialize()
        {
            foreach (BaseComponent component in components.ToArray())
            {
                component.Init(this);
            }

            foreach (GameObject child in Children)
            {
                child.initialize();
            }

            foreach (BaseComponent component in components.ToArray())
            {
                (component as ILateInit)?.LateInit();
            }
        }

        /**
         * run all update components
         */
        public void Update()
        {
            foreach (BaseComponent component in components.ToArray())
            {
                (component as IUpdate)?.Update();
            }

            BoundingBox.Position.X += (int) velocity.X;
            BoundingBox.Position.Y += (int) velocity.Y;

            foreach (BaseComponent component in components.ToArray())
            {
                (component as ILateUpdate)?.LateUpdate();
            }

            foreach (GameObject child in Children)
            {
                child.Update();
            }
        }

        /**
         * run all draw components
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseComponent component in components.ToArray())
            {
                (component as IDraw)?.Draw(spriteBatch);
            }

            foreach (GameObject child in Children)
            {
                child.Draw(spriteBatch);
            }
        }

        /**
         * can be added in a extended class
         */
        public void onTriggerEnter(GameObject collision)
        {
            foreach (BaseComponent component in components.ToArray())
            {
                (component as ITrigger)?.triggerEnter(collision);
            }
        }

        /**
         * can be added in a extended class
         */
        public void onHover(Vector2 mousePosition)
        {
            foreach (BaseComponent component in components.ToArray())
            {
                (component as IMouse)?.onHover(mousePosition);
            }
        }


        /**
         * can be added in a extended class
         */
        public void onPressed(Vector2 mousePosition, int mouseButton)
        {
            foreach (BaseComponent component in components.ToArray())
            {
                (component as IMouse)?.onPressed(mousePosition, mouseButton);
            }
        }

        /**
         * can be added in a extended class
         */
        public void onCollisionEnter(GameObject collision, Vector2 direction)
        {
            foreach (BaseComponent component in components.ToArray())
            {
                (component as ICollision)?.collisionEnter(collision, direction);
            }

            if (direction == new Vector2(-1, 0))
            {
                BoundingBox.Position.X = collision.HitBox.Left().X - HitBox.Width() / 2;
                velocity.X = 0;
            }

            if (direction == new Vector2(1, 0))
            {
                BoundingBox.Position.X = collision.HitBox.Right().X + HitBox.Width() / 2;
                velocity.X = 0;
            }

            if (direction == new Vector2(0, -1))
            {
                velocity.Y = 0;
                BoundingBox.Position.Y = collision.HitBox.Top().Y - HitBox.Height() / 2;
            }

            if (direction == new Vector2(0, 1))
            {
                velocity.Y = 0;
                BoundingBox.Position.Y = collision.HitBox.Bottom().Y + HitBox.Height() / 2;
            }
        }

        /**
         * find components in this gameobject
         */
        public ComponentType getComponent<ComponentType>()
        {
            foreach (BaseComponent component in components.ToArray())
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
            foreach (BaseComponent component in components.ToArray())
            {
                if (component is ComponentType)
                {
                    return true;
                }
            }

            return false;
        }

        public void AddChild(GameObject child)
        {
            Children.Add(child);
            child.Parent = this;
        }
    }
}