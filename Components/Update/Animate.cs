using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TestProject.Component
{
    class Animate : UpdateComponent
    {
        private List<Texture2D> sprites = new List<Texture2D>();
        private int index;

        private float neededClicks;
        private float clicks;

        private SpriteRenderer spriteComponent;

        public Animate(float time, List<Texture2D> textures) 
        {
            neededClicks = time;
            clicks = neededClicks;
            sprites = textures;
        }

        public void initialize(GameObject gameObject) {
            spriteComponent = gameObject.getComponent<SpriteRenderer>();
        }

        public void Update(GameObject gameObject) {
            if (clicks <= 0)
            {
                index = index + 1 < sprites.Count ? index + 1 : 0;

                clicks = neededClicks;
                spriteComponent.sprite = sprites[index];
            }
            else {
                clicks -= 0.1f;
            }
        }
    }
}
