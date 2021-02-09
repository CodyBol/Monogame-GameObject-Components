using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Component
{
    struct ComponentContainer
    {
        public List<UpdateComponent> updateComponents;
        public List<DrawComponent> drawComponents;
        public List<ScriptComponent> scriptComponents;
    }
}
