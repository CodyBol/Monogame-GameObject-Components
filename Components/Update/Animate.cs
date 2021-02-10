using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TestProject.Component
{
    class Animate : UpdateComponent
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

        public void initialize(GameObject gameObject) {
            spriteComponent = gameObject.getComponent<SpriteRenderer>();
        }

        public void Update(GameObject gameObject) {
            if (clicks <= 0)
            {
                animationState[state].index = animationState[state].index + 1 < animationState[state].sprites.Count ? animationState[state].index + 1 : (!animationState[state].loop ? animationState[state].index : 0);

                clicks = neededClicks;
                spriteComponent.sprite = animationState[state].sprites[animationState[state].index];
            }
            else {
                clicks -= 0.1f;
            }
        }

        public void changeState(string newState)
        {
            state = newState;
            animationState[state].index = 0;
            spriteComponent.sprite = animationState[state].sprites[animationState[state].index];
        }

        public void changeState(string newState, bool reset)
        {
            state = newState;
            if (reset)
            {
                animationState[state].index = 0;
            }
            spriteComponent.sprite = animationState[state].sprites[animationState[state].index];
        }

        public string getState()
        {
            return state;
        }
    }

    class AnimationState {
        public List<Texture2D> sprites;
        public bool loop;
        public int index;
    }
}
