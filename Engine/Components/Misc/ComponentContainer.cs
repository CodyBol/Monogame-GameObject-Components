using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Component
{
    struct ComponentContainer
    {
        public List<IUpdate> updateComponents;
        public List<IDraw> drawComponents;
    }
}
