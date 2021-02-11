using System;
using System.Collections.Generic;
using System.Text;
using GameObjects;

namespace Component
{
    struct ComponentContainer
    {
        public List<UpdateComponent> updateComponents;
        public List<DrawComponent> drawComponents;
        public List<ScriptComponent> scriptComponents;
    }
}
