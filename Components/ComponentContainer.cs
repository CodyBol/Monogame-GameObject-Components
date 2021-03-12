using System;
using System.Collections.Generic;
using System.Text;
using GameObjects;

namespace Component
{
    struct ComponentContainer
    {
        public List<IUpdate> updateComponents;
        public List<IDraw> drawComponents;
        public List<ScriptComponent> scriptComponents;
    }
}
