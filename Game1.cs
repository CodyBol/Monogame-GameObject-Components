using Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameObjects;

namespace TestProject
{
   
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AssetLoader assetLoader;
        private Dictionary<string, Layer> layers;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            layers = new Dictionary<string, Layer>();
            layers.Add("bottom", new Layer("bottom", 0));
            layers.Add("top", new Layer("top", 1));


            assetLoader = new AssetLoader(Content);
            assetLoader.addSpritesToLoader(new List<string>() { "spr_blue_invader", "spr_red_invader", "spr_tile" });
            assetLoader.addFontToLoader("Arial");

            GameObjectManager.gameObjects = new List<GameObject>();

            ComponentContainer comp = ComponentBuild.createContainer();
            comp.drawComponents.Add(new SpriteRenderer(assetLoader.getSprite("spr_blue_invader")));
            comp.updateComponents.Add(new RectCollider(layers["bottom"], true));

            AnimationState states = new AnimationState();
            states.sprites = new List<Texture2D>() { assetLoader.getSprite("spr_blue_invader"), assetLoader.getSprite("spr_red_invader")};
            states.loop = true;

            AnimationState states2 = new AnimationState();
            states2.sprites = new List<Texture2D>() { assetLoader.getSprite("spr_tile") };
            states2.loop = false;

            comp.updateComponents.Add(new Animate(2f, "animate", new Dictionary<string, AnimationState>() { {"animate", states}, {"default", states2 } }));

            comp.scriptComponents = new List<ScriptComponent>();
            comp.scriptComponents.Add(new Player());

            GameObjectManager.gameObjects.Add(new GameObject(new Rectangle(300, 300, 50, 50), layers["bottom"], comp));


            //text
            comp = ComponentBuild.createContainer();
            comp.drawComponents.Add(new TextRenderer(assetLoader.getFont("Arial"), "deep deep deep", Color.HotPink));

            GameObjectManager.gameObjects.Add(new GameObject(new Rectangle(100, 100, 0, 0), layers["top"], comp));


            //walls
            ComponentContainer compWalls = ComponentBuild.createContainer();
            compWalls.drawComponents.Add(new SpriteRenderer(assetLoader.getSprite("spr_tile")));
            compWalls.updateComponents.Add(new RectCollider(layers["bottom"], false));
            compWalls.updateComponents.Add(new MouseEvent());
            compWalls.scriptComponents = new List<ScriptComponent>();

            GameObjectManager.gameObjects.Add(new GameObject(new Rectangle(100, 100, 100, 300), layers["bottom"], compWalls));
            GameObjectManager.gameObjects.Add(new GameObject(new Rectangle(200, 100, 200, 100), layers["bottom"], compWalls));

            foreach (GameObject gameObject in GameObjectManager.gameObjects)
            {
                gameObject.initialize();
            }

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


            float speed = 5;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                GameObjectManager.gameObjects[0].velocity.Y = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                GameObjectManager.gameObjects[0].velocity.Y = speed;
            }
            else 
            {
                GameObjectManager.gameObjects[0].velocity.Y = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                GameObjectManager.gameObjects[0].velocity.X = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                GameObjectManager.gameObjects[0].velocity.X = speed;
            }
            else 
            {
                GameObjectManager.gameObjects[0].velocity.X = 0;
            }

            foreach (GameObject gameObject in GameObjectManager.gameObjects)
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

            foreach (KeyValuePair<string, Layer> stringLayer in layers)
            {
                foreach (GameObject gameObject in GameObjectManager.gameObjects) {
                
                    if (stringLayer.Value == gameObject.layer)
                    {
                        gameObject.Draw(_spriteBatch);
                    }
                }
            }

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
