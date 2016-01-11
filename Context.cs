using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace ParticleSystems
{
    
    class Context
    {
        private IdHolder IdHolder;

        public Context(IdHolder idHolder)
        {
            IdHolder = idHolder;
        }
        
        //private List<Obstacle>

        public IdHolder GetIdHolder()
        {
            return IdHolder;
        }
    }
}
