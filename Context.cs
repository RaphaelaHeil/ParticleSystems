using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace ParticleSystems
{
    
    class Context
    {
        private IdHolder IdHolder;
        private List<PlaceableObject> placableObjectList;

        public Context(IdHolder idHolder)
        {
            IdHolder = idHolder;
            placableObjectList = new List<PlaceableObject>();
        }
        
        //private List<Obstacle>

        public IdHolder GetIdHolder()
        {
            return IdHolder;
        }

        public List<PlaceableObject> getPlacableObjectList() {
            return this.placableObjectList;
        }
    }
}
