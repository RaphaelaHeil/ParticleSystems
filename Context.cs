using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace ParticleSystems
{
    
    class Context
    {
        private IdHolder IdHolder;
        private List<PlaceableObject> placableObjectList;

        public Context()
        {
            placableObjectList = new List<PlaceableObject>();
        }
  
        public void setIdHolder(IdHolder idHolder) {
            IdHolder = idHolder;
        }

        public IdHolder GetIdHolder()
        {
            return IdHolder;
        }

        public void addPlacableObjectToList(PlaceableObject po) {
            placableObjectList.Add(po);
        }

        public List<PlaceableObject> getPlacableObjectList() {
            return this.placableObjectList;
        }
    }
}
