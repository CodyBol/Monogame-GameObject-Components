using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Engine.Misc;
using GameObjects;

namespace Component
{
    public class Animate : BaseComponent, IUpdate
    {
        private string state;

        private Dictionary<string, AnimationState> animationState;

        private float neededClicks;
        private float clicks;

        private SpriteRenderer spriteComponent;

        public Animate(float time, string beginState, Dictionary<string, AnimationState> animationStateDictonary) 
        {
            neededClicks = time;
            clicks = neededClicks;
            state = beginState;
            animationState = animationStateDictonary;
        }

        public Animate(float time, string stateName, AnimationState newAnimationState)
        {
            neededClicks = time;
            clicks = neededClicks;
            state = stateName;
            animationState = new Dictionary<string, AnimationState>() { {stateName, newAnimationState} };
        }

        public Animate(float time, string stateName, SpriteSheet sheet, bool loop = false, int start = 0)
        {
            neededClicks = time;
            clicks = neededClicks;
            state = stateName;

            AnimationState newAnimationState = new AnimationSheetState() {Sheet = sheet, Loop = loop, Index = start}; 
            
            animationState = new Dictionary<string, AnimationState>() { {stateName, newAnimationState} };
        }


        public override void Init(GameObject gameObject)
        {
            base.Init(gameObject);

            if (!GameObject.hasComponent<SpriteRenderer>())
            {
                SpriteRenderer renderer = new SpriteRenderer();
                renderer.Init(GameObject);
                GameObject.components.Add(renderer);
            }

            spriteComponent = GameObject.getComponent<SpriteRenderer>();
            if (spriteComponent.sprite == null)
            {
                ChangeSprite(false);
            }
        }

        private void ChangeSprite(bool update)
        {
            if (animationState[state].getSprite() is SpriteSheet)
            {
                if (update)
                {
                    animationState[state].Index = animationState[state].Index + 1 < (animationState[state] as AnimationSheetState).Sheet.Sprites.Count ? animationState[state].Index + 1 : (!animationState[state].Loop ? animationState[state].Index : 0);

                }
                
                spriteComponent.SheetIndex = animationState[state].Index;
                spriteComponent.sprite = animationState[state].getSprite();
            }
            else
            {
                if (update)
                {
                    animationState[state].Index = animationState[state].Index + 1 < (animationState[state] as AnimationListState).Sprites.Count ? animationState[state].Index + 1 : (!animationState[state].Loop ? animationState[state].Index : 0);

                }
                
                spriteComponent.sprite = animationState[state].getSprite();
            }
        }

        public void Update() {
            if (clicks <= 0)
            {
                clicks = neededClicks;
                ChangeSprite(true);
            }
            else {
                clicks -= 0.1f;
            }
        }

        public void changeState(string newState)
        {
            state = newState;
            animationState[state].Index = 0;
            ChangeSprite(false);
        }

        public void changeState(string newState, bool reset)
        {
            state = newState;
            if (reset)
            {
                animationState[state].Index = 0;
            }
            ChangeSprite(false);
        }

        public string getState()
        {
            return state;
        }
    }

    public abstract class AnimationState {
        public bool Loop;
        public int Index;

        public virtual Sprite getSprite()
        {
            return null;
        }
    }

    public class AnimationListState : AnimationState {
        public List<Sprite> Sprites;
        
        public override Sprite getSprite()
        {
            return Sprites[Index];
        }
    }

    public class AnimationSheetState : AnimationState {
        public SpriteSheet Sheet;
        
        public override Sprite getSprite()
        {
            return Sheet;
        }
    }
}
