using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Component
{
    public class Layer
    {
        public string Name;
        public int ZIndex;

        public Layer(string layerName, int zPos) {
            Name = layerName;
            ZIndex = zPos;
        }
    }
}
