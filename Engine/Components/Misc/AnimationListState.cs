using System.Collections.Generic;
using Engine.Misc;

namespace Engine.Component.Misc
{
    public class AnimationListState : AnimationState {
        public List<Sprite> Sprites;
        
        public override Sprite getSprite()
        {
            return Sprites[Index];
        }
    }
}