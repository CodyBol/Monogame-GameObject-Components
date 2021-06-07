using Engine.Misc;

namespace Engine.Component.Misc
{
    public class AnimationSheetState : AnimationState {
        public SpriteSheet Sheet;
        
        public override Sprite getSprite()
        {
            return Sheet;
        }
    }
}