using Engine.Misc;

namespace Engine.Component.Misc
{
    public abstract class AnimationState {
        public bool Loop;
        public int Index;

        public virtual Sprite getSprite()
        {
            return null;
        }
    }
}