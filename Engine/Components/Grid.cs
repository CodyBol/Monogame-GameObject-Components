using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Engine.Misc;
using GameObjects;
using Microsoft.Xna.Framework;
using BoundingBox = Engine.Misc.BoundingBox;

namespace Component
{
    public class Grid : BaseComponent
    {
        public Vector2 GridSize;
        public Vector2 TileMargin;

        private GameObject[,] gridItems;

        public Grid(Vector2 gridSize)
        {
            GridSize = gridSize;
            gridItems = new GameObject[(int) gridSize.Y, (int) gridSize.X];
            TileMargin = Vector2.Zero;
        }

        public Grid(Vector2 gridSize, Vector2 tileMargin)
        {
            GridSize = gridSize;
            gridItems = new GameObject[(int) gridSize.X + 1, (int) gridSize.Y + 1];
            TileMargin = tileMargin;
        }

        public override void Init(GameObject gameObject)
        {
            base.Init(gameObject);

            if (GameObject.BoundingBox.Size == Vector2.Zero)
            {
                GameObject.BoundingBox.Size = new Vector2(32);
            }

            BoundingBox mainBox = GameObject.BoundingBox.Copy();
            mainBox.Position -= (((GridSize - Vector2.One) * mainBox.Size * mainBox.Scale) + ((GridSize - Vector2.One) * mainBox.Scale * TileMargin)) / 2;

            
            GameObject.BoundingBox = mainBox;
            
            for (int x = 0; x < GridSize.X; x++)
            {
                for (int y = 0; y < GridSize.Y; y++)
                {
                    if (gridItems[x, y] != null)
                    {
                        gridItems[x, y].UseParent = false;
                        
                        BoundingBox box = gridItems[x, y].BoundingBox;
                        box.Position.X = GameObject.BoundingBox.Position.X + x * ((GameObject.BoundingBox.Size.X + TileMargin.X) * GameObject.BoundingBox.Scale.X);
                        box.Position.Y = GameObject.BoundingBox.Position.Y + y * ((GameObject.BoundingBox.Size.Y + TileMargin.Y) * GameObject.BoundingBox.Scale.Y);
                        box.Size = GameObject.BoundingBox.Size;
                        box.Scale = GameObject.BoundingBox.Scale;

                        gridItems[x, y].BoundingBox = box;
                    }
                }
            }
        }

        public void AddGameObject(GameObject gameObject, int x, int y)
        {
            if (x >= GridSize.X || y >= GridSize.Y)
            {
                throw new Exception("Given grid position exceeds the grid size");
            }

            gridItems[x, y] = gameObject;
        }
    }
}