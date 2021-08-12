using System.Collections.Generic;
using Engine;
using Engine.Component;
using Engine.Component.Misc;
using Engine.Misc;
using Microsoft.Xna.Framework;
using TestProject.Component;
using BoundingBox = Engine.Misc.BoundingBox;

namespace TestProject.GameStates
{
    public class PlayingState : GameState
    {
        public override void Initialize()
        {
            _useCamera = true;
            
            Layers = new Dictionary<string, Layer>();
            Layers.Add("background", new Layer("background", -1));
            Layers.Add("bottom", new Layer("bottom", 0));
            Layers.Add("top", new Layer("top", 1));
            
            GameCore.AssetLoader.addSpritesToLoader(new List<string>() { "spr_blue_invader", "spr_red_invader", "spr_tile" });
            GameCore.AssetLoader.AddSpriteSheetToLoader("Sheet", new Rectangle(0, 0, 16, 16), new Vector2(1, 1));
            GameCore.AssetLoader.addFontToLoader("Arial");

            GameObjectManager.GameObjects = new List<GameObject>();

            List<BaseComponent> cam = new List<BaseComponent>(); ;

            _camera = new Camera(GameCore.ScreenSize);

            cam.Add(_camera);
            
            //Maak nieuwe ComponentContainer
            List<BaseComponent> comp = new List<BaseComponent>(); ;

            //Voeg sprite drawer toe
            comp.Add(new SpriteRenderer(GameCore.AssetLoader.getSprite("spr_blue_invader")));

            //begin animatie
            AnimationListState states = new AnimationListState();
            states.Sprites = new List<Sprite>() { GameCore.AssetLoader.getSprite("spr_blue_invader"), GameCore.AssetLoader.getSprite("spr_red_invader")};
            states.Loop = true;

            AnimationListState states2 = new AnimationListState();
            states2.Sprites = new List<Sprite>() { GameCore.AssetLoader.getSprite("spr_tile") };
            states2.Loop = false;

            //voeg animatie toe
            comp.Add(new Animate(2f, "animate", new Dictionary<string, AnimationState>() { {"animate", states}, {"default", states2 } }));
            //eind animatie

            //Voeg custom player script toe (bevat nu alleen movement)
            comp.Add(new Player(_camera, Layers["bottom"]));

            comp.Add(new BasicMovement());

            //Voeg Collision toe aan dit object
            comp.Add(new RectCollider(true));


            GameObject player;
            //Voeg gameObject toe aan de manager
            GameObjectManager.GameObjects.Add(player = new GameObject(new BoundingBox(new Vector2(20, 20), new Vector2(2, 2)), Layers["bottom"], comp));

            comp = new List<BaseComponent>();

            //Sprite Sheet = new Sprite() {Texture2D = GameCore.AssetLoader.getSprite("Sheet"), Size = new Rectangle(0, 0, 16, 16)};
            
            //comp.Add(new SpriteRenderer());
            comp.Add(new Animate(10, "idle", GameCore.AssetLoader.getSpriteSheet("Sheet"), true));
            comp.Add(new RectCollider(Layers["bottom"], false));
            GameObjectManager.GameObjects.Add(new GameObject(new BoundingBox(new Vector2(400, 400), new Vector2(6, 6)), Layers["bottom"], comp));

            //grid
            GameObject grid;
            
            comp = new List<BaseComponent>();
            comp.Add(new Grid(new Vector2(4), new Vector2(3)));
            GameObjectManager.GameObjects.Add(grid = new GameObject(new BoundingBox(new Vector2(0), new Vector2(2)), Layers["background"], comp));
            
            //grid items
            GameObject gridItem;
            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.AssetLoader.getSprite("spr_tile")));
            GameObjectManager.GameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), Layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 0, 0);
            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.AssetLoader.getSprite("spr_tile")));
            GameObjectManager.GameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), Layers["bottom"], comp));
            gridItem.SetParent(grid);
            grid.getComponent<Grid>().AddGameObject(gridItem, 1, 0);

            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.AssetLoader.getSprite("spr_tile")));
            //comp.Add(new RectCollider(Layers["bottom"], false));
            GameObjectManager.GameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), Layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 1, 1);
            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.AssetLoader.getSprite("spr_tile")));
            //comp.Add(new RectCollider(Layers["bottom"], false));
            GameObjectManager.GameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), Layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 1, 2);

            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.AssetLoader.getSprite("spr_tile")));
            //comp.Add(new RectCollider(Layers["bottom"], false));
            GameObjectManager.GameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), Layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 2, 1);

            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.AssetLoader.getSprite("spr_tile")));
            //comp.Add(new RectCollider(Layers["bottom"], false));
            GameObjectManager.GameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), Layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 2, 2);

            
            comp = new List<BaseComponent>();
            comp.Add(new SpriteRenderer(GameCore.AssetLoader.getSprite("spr_tile")));
            comp.Add(new RectCollider(Layers["bottom"], false));
            GameObjectManager.GameObjects.Add(gridItem = new GameObject(new BoundingBox(new Vector2(0)), Layers["bottom"], comp));
            grid.AddChild(gridItem);
            grid.getComponent<Grid>().AddGameObject(gridItem, 3, 3);

            
            GameObjectManager.GameObjects.Add(new GameObject(new BoundingBox(), Layers["bottom"], cam));

            base.Initialize();
        }
    }
}