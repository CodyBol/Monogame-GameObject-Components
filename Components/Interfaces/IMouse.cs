﻿using GameObjects;
using Microsoft.Xna.Framework;

namespace Component
{
    interface IMouse
    {
        public void onHover(Vector2 mousePosition);

        public void onPressed(Vector2 mousePosition, int mouseButton);
    }
}