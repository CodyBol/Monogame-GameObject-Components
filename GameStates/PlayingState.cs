using System;
using System.Collections.Generic;
using Component;
using Engine;
using Engine.GameStates;
using Engine.Misc;
using GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BoundingBox = Engine.Misc.BoundingBox;

namespace TestProject.GameStates
{
    public class PlayingState : GameState
    {
        public override void Initialize()
        {
            layers = new Dictionary<string, Layer>();
            layers.Add("bottom", new Layer("bottom", 0));
            layers.Add("top", new Layer("top", 1));
            
            GameCore.assetLoader.addSpritesToLoader(new List<string>() { "spr_blue_invader", "spr_red_invader", "spr_tile" });
            GameCore.assetLoader.AddSpriteSheetToLoader("Sheet", new Rectangle(0, 0, 16, 16), new Vector2(1, 1));
            GameCore.assetLoader.addFontToLoader("Arial");

            GameObjectManager.gameObjects = new List<GameObject>();

            List<BaseComponent> cam = new List<BaseComponent>(); ;

            _camera = new Camera(GameCore.ScreenSize);

            cam.Add(_camera);
            
            //Maak nieuwe ComponentContainer
            List<BaseComponent> comp = new List<BaseComponent>(); ;

            //Voeg sprite drawer toe
            comp.Add(new SpriteRenderer(GameCore.assetLoader.getSprite("spr_blue_invader")));

            //begin animatie
            AnimationListState states = new AnimationListState();
            states.Sprites = new List<Sprite>() { GameCore.assetLoader.getSprite("spr_blue_invader"), GameCore.assetLoader.getSprite("spr_red_invader")};
            states.Loop = true;

            AnimationListState states2 = new AnimationListState();
            states2.Sprites = new List<Sprite>() { GameCore.assetLoader.getSprite("spr_tile") };
            states2.Loop = false;

            //voeg animatie toe
            comp.Add(new Animate(2f, "animate", new Dictionary<string, AnimationState>() { {"animate", states}, {"default", states2 } }));
            //eind animatie

            //Voeg custom player script toe (bevat nu alleen movement)
            comp.Add(new Player(_camera, layers["bottom"]));

            //Voeg Collision toe aan dit object
            comp.Add(new RectCollider(layers["bottom"], true));


            //Voeg gameObject toe aan de manager
            GameObjectManager.gameObjects.Add(new GameObject(new BoundingBox(new Vector2(0, 0), new Vector2(2, 2), new Vector2(GameCore.assetLoader.getSprite("spr_blue_invader").Size.Width, GameCore.assetLoader.getSprite("spr_blue_invader").Size.Height)), layers["bottom"], comp));


            comp = new List<BaseComponent>();

            //Sprite Sheet = new Sprite() {Texture2D = GameCore.assetLoader.getSprite("Sheet"), Size = new Rectangle(0, 0, 16, 16)};
            
            comp.Add(new SpriteRenderer());
            comp.Add(new Animate(10, "idle", GameCore.assetLoader.getSpriteSheet("Sheet"), true));
            comp.Add(new RectCollider(layers["bottom"], false));
            GameObjectManager.gameObjects.Add(new GameObject(new BoundingBox(new Vector2(300, 300), new Vector2(6, 6), new Vector2(GameCore.assetLoader.getSpriteSheet("Sheet").SpriteDimensions.Width, GameCore.assetLoader.getSpriteSheet("Sheet").SpriteDimensions.Height)), layers["bottom"], comp));

            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.assetLoader.getSprite("spr_tile")));

            //Voeg custom player script toe (bevat nu alleen movement)
            comp.Add(new Player2(_camera, layers["bottom"]));

            //Voeg Collision toe aan dit object
            comp.Add(new RectCollider(layers["bottom"], true));
            GameObjectManager.gameObjects.Add(new GameObject(new BoundingBox(new Vector2(500, 300), new Vector2(3, 3), new Vector2(GameCore.assetLoader.getSprite("spr_tile").Size.Width, GameCore.assetLoader.getSprite("spr_tile").Size.Height)), layers["bottom"], comp));

            
            GameObjectManager.gameObjects.Add(new GameObject(new BoundingBox(), layers["bottom"], cam));

            base.Initialize();
        }
    }
}