﻿using Microsoft.Xna.Framework;
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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            spriteLoader = new SpriteLoader(Content, new List<string>() { "spr_blue_invader", "spr_red_invader", "spr_tile" });
            GameObjectManager.gameObjects = new List<GameObject>();



            ComponentContainer comp = ComponentBuild.createContainer();
            comp.drawComponents.Add(new SpriteRenderer(spriteLoader.getSprite("spr_blue_invader")));
            comp.updateComponents.Add(new RectCollider("default", true));

            AnimationState states = new AnimationState();
            states.sprites = new List<Texture2D>() { spriteLoader.getSprite("spr_blue_invader"), spriteLoader.getSprite("spr_red_invader")};
            states.loop = true;

            AnimationState states2 = new AnimationState();
            states2.sprites = new List<Texture2D>() { spriteLoader.getSprite("spr_tile") };
            states2.loop = false;

            comp.updateComponents.Add(new Animate(2f, "animate", new Dictionary<string, AnimationState>() { {"animate", states}, {"default", states2 } }));

            comp.scriptComponents = new List<ScriptComponent>();
            comp.scriptComponents.Add(new Player());

            GameObjectManager.gameObjects.Add(new GameObject(new Rectangle(300, 300, 50, 50), comp));



            //walls
            ComponentContainer compWalls = ComponentBuild.createContainer();
            compWalls.drawComponents.Add(new SpriteRenderer(spriteLoader.getSprite("spr_tile")));
            compWalls.updateComponents.Add(new RectCollider("default", false));
            compWalls.updateComponents.Add(new MouseEvent());
            compWalls.scriptComponents = new List<ScriptComponent>();

            GameObjectManager.gameObjects.Add(new GameObject(new Rectangle(100, 100, 100, 300), compWalls));
            GameObjectManager.gameObjects.Add(new GameObject(new Rectangle(200, 100, 200, 100), compWalls));

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

            foreach (GameObject gameObject in GameObjectManager.gameObjects) {
                gameObject.Draw(_spriteBatch);
            }

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
