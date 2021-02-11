using System;
using System.Collections.Generic;
using System.Text;

namespace Component
{
    class Layer
    {
        public string name;
        public int zIndex;

        public Layer(string layerName, int zPos) {
            name = layerName;
            zIndex = zPos;
        }
    }
}
