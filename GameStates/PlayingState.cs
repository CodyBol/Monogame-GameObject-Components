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
            _useCamera = true;
            
            layers = new Dictionary<string, Layer>();
            layers.Add("background", new Layer("background", -1));
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


            GameObject player;
            //Voeg gameObject toe aan de manager
            GameObjectManager.gameObjects.Add(player = new GameObject(new BoundingBox(new Vector2(0, 0), new Vector2(2, 2)), layers["bottom"], comp));

            comp = new List<BaseComponent>();

            //Sprite Sheet = new Sprite() {Texture2D = GameCore.assetLoader.getSprite("Sheet"), Size = new Rectangle(0, 0, 16, 16)};
            
            //comp.Add(new SpriteRenderer());
            comp.Add(new Animate(10, "idle", GameCore.assetLoader.getSpriteSheet("Sheet"), true));
            comp.Add(new RectCollider(layers["bottom"], false));
            GameObjectManager.gameObjects.Add(new GameObject(new BoundingBox(new Vector2(400, 400), new Vector2(6, 6)), layers["bottom"], comp));

            //grid
            GameObject grid;
            
            comp = new List<BaseComponent>();
            comp.Add(new Grid(new Vector2(4), new Vector2(3)));
            GameObjectManager.gameObjects.Add(grid = new GameObject(new BoundingBox(new Vector2(0), new Vector2(2)), layers["background"], comp));
            
            //grid items
            GameObject gridItem;
            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.assetLoader.getSprite("spr_tile")));
            GameObjectManager.gameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 0, 0);
            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.assetLoader.getSprite("spr_tile")));
            GameObjectManager.gameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), layers["bottom"], comp));
            gridItem.SetParent(grid);
            grid.getComponent<Grid>().AddGameObject(gridItem, 1, 0);

            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.assetLoader.getSprite("spr_tile")));
            //comp.Add(new RectCollider(layers["bottom"], false));
            GameObjectManager.gameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 1, 1);
            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.assetLoader.getSprite("spr_tile")));
            //comp.Add(new RectCollider(layers["bottom"], false));
            GameObjectManager.gameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 1, 2);

            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.assetLoader.getSprite("spr_tile")));
            //comp.Add(new RectCollider(layers["bottom"], false));
            GameObjectManager.gameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 2, 1);

            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.assetLoader.getSprite("spr_tile")));
            //comp.Add(new RectCollider(layers["bottom"], false));
            GameObjectManager.gameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 2, 2);

            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.assetLoader.getSprite("spr_tile")));
            comp.Add(new RectCollider(layers["bottom"], false));
            GameObjectManager.gameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 3, 3);

            
            GameObjectManager.gameObjects.Add(new GameObject(new BoundingBox(), layers["bottom"], cam));

            base.Initialize();
        }
    }
}