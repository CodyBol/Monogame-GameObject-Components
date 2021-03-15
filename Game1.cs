using Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameObjects;
using System.Diagnostics;

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

            //Maak nieuwe ComponentContainer
            List<BaseComponent> comp = new List<BaseComponent>(); ;

            //Voeg sprite drawer toe
            comp.Add(new SpriteRenderer(assetLoader.getSprite("spr_blue_invader")));

            //Voeg Collision toe aan dit object
            comp.Add(new RectCollider(layers["bottom"], true));

            //begin animatie
            AnimationState states = new AnimationState();
            states.sprites = new List<Texture2D>() { assetLoader.getSprite("spr_blue_invader"), assetLoader.getSprite("spr_red_invader")};
            states.loop = true;

            AnimationState states2 = new AnimationState();
            states2.sprites = new List<Texture2D>() { assetLoader.getSprite("spr_tile") };
            states2.loop = false;

            //voeg animatie toe
            comp.Add(new Animate(2f, "animate", new Dictionary<string, AnimationState>() { {"animate", states}, {"default", states2 } }));
            //eind animatie

            //Voeg custom player script toe (bevat nu alleen movement)
            comp.Add(new Player());

            //Voeg gameObject toe aan de manager
            GameObjectManager.gameObjects.Add(new GameObject(new Vector2(300, 100), new Vector2(1, 1), layers["bottom"], comp));

            comp = new List<BaseComponent>(); ;

            comp.Add(new SpriteRenderer(assetLoader.getSprite("spr_tile")));
            comp.Add(new RectCollider(layers["bottom"], false));
            GameObjectManager.gameObjects.Add(new GameObject(new Vector2(100, 100), new Vector2(2, 2), layers["bottom"], comp));

            GameObjectManager.initGameObjects();

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


            GameObjectManager.UpdateGameObjects();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            GameObjectManager.RenderGameObjects(_spriteBatch, layers);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
