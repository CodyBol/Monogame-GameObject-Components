using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TestProject.Component;

namespace TestProject
{
   
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteLoader spriteLoader;

        private List<GameObject> gameObjects;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            spriteLoader = new SpriteLoader(Content, new List<string>() { "spr_blue_invader", "spr_red_invader" });

            gameObjects = new List<GameObject>();
            gameObjects.Add(new GameObject(new Rectangle(100, 100, 50, 50), ComponentBuild.Animation(2, new List<Texture2D>() { spriteLoader.getSprite("spr_blue_invader"), spriteLoader.getSprite("spr_red_invader") })));

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.initialize();
            }

            //Debug.WriteLine(gameObjects[0].getComponent<SpriteBatch>());


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            // Draw the background (and clear the screen)

            foreach (GameObject gameObject in gameObjects) {
                gameObject.Draw(_spriteBatch);
            }

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
