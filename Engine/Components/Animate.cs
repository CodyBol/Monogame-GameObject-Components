using System.Collections.Generic;
using Engine.Component.Misc;
using Engine.Misc;

namespace Engine.Component
{
    public class Animate : BaseComponent, IUpdate
    {
        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                _animationState[_state].Index = 0;
                ChangeSprite(false);
            }
        }

        private Dictionary<string, AnimationState> _animationState;

        private float _neededClicks;
        private float _clicks;

        private SpriteRenderer _spriteComponent;

        public Animate(float time, string beginState, Dictionary<string, AnimationState> animationStateDictonary) 
        {
            _neededClicks = time;
            _clicks = _neededClicks;
            _state = beginState;
            _animationState = animationStateDictonary;
        }

        public Animate(float time, string stateName, AnimationState newAnimationState)
        {
            _neededClicks = time;
            _clicks = _neededClicks;
            _state = stateName;
            _animationState = new Dictionary<string, AnimationState>() { {stateName, newAnimationState} };
        }

        public Animate(float time, string stateName, SpriteSheet sheet, bool loop = false, int start = 0)
        {
            _neededClicks = time;
            _clicks = _neededClicks;
            _state = stateName;

            AnimationState newAnimationState = new AnimationSheetState() {Sheet = sheet, Loop = loop, Index = start}; 
            
            _animationState = new Dictionary<string, AnimationState>() { {stateName, newAnimationState} };
        }


        public override void Init(GameObject gameObject)
        {
            base.Init(gameObject);

            if (!GameObject.hasComponent<SpriteRenderer>())
            {
                SpriteRenderer renderer = new SpriteRenderer();
                renderer.Init(GameObject);
                GameObject.Components.Add(renderer);
            }

            _spriteComponent = GameObject.getComponent<SpriteRenderer>();
            if (_spriteComponent.sprite == null)
            {
                ChangeSprite(false);
            }
        }

        private void ChangeSprite(bool update)
        {
            if (_animationState[_state].getSprite() is SpriteSheet)
            {
                if (update)
                {
                    _animationState[_state].Index = _animationState[_state].Index + 1 < (_animationState[_state] as AnimationSheetState).Sheet.Sprites.Count ? _animationState[_state].Index + 1 : (!_animationState[_state].Loop ? _animationState[_state].Index : 0);

                }
                
                _spriteComponent.SheetIndex = _animationState[_state].Index;
                _spriteComponent.sprite = _animationState[_state].getSprite();
            }
            else
            {
                if (update)
                {
                    _animationState[_state].Index = _animationState[_state].Index + 1 < (_animationState[_state] as AnimationListState).Sprites.Count ? _animationState[_state].Index + 1 : (!_animationState[_state].Loop ? _animationState[_state].Index : 0);

                }
                
                _spriteComponent.sprite = _animationState[_state].getSprite();
            }
        }

        public void Update() {
            if (_clicks <= 0)
            {
                _clicks = _neededClicks;
                ChangeSprite(true);
            }
            else {
                _clicks -= 0.1f;
            }
        }

        public void ChangeState(string newState, bool reset)
        {
            _state = newState;
            if (reset)
            {
                _animationState[_state].Index = 0;
            }
            ChangeSprite(false);
        }
    }


}
