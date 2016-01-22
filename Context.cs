using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace ParticleSystems
{

    class Context
    {
        private IdHolder IdHolder;
        private List<PlaceableObject> placeableObjects;

        public Context()
        {
            placeableObjects = new List<PlaceableObject>();
        }

        public void setIdHolder(IdHolder idHolder)
        {
            IdHolder = idHolder;
        }

        public IdHolder GetIdHolder()
        {
            return IdHolder;
        }

        public void addPlacableObject(PlaceableObject po)
        {
            placeableObjects.Add(po);
        }

        public List<PlaceableObject> getPlacableObjects()
        {
            return placeableObjects;
        }

        public void removePlaceableObject(PlaceableObject placeableObject)
        {
            placeableObjects.Remove(placeableObject);
        }

        public Vector2d[] GetPlaceableObjectVertices()
        {
            Vector2d[] vertices = new Vector2d[placeableObjects.Count * 4];
            for (int i = 0; i < placeableObjects.Count; i++)
            {
                PlaceableObject placeableObject = placeableObjects.ElementAt(i);
                int counter = i * 4;
                //lower left:
                vertices[counter] = new Vector2d(placeableObject.getPosition().X - placeableObject.GetWidth() / 2.0, placeableObject.getPosition().Y - placeableObject.GetHeight() / 2.0);

                //lower right:
                vertices[counter + 1] = new Vector2d(placeableObject.getPosition().X + placeableObject.GetWidth() / 2.0, placeableObject.getPosition().Y - placeableObject.GetHeight() / 2.0);

                //upper right:
                vertices[counter + 2] = new Vector2d(placeableObject.getPosition().X + placeableObject.GetWidth() / 2.0, placeableObject.getPosition().Y + placeableObject.GetHeight() / 2.0);

                //upper left: 

                vertices[counter + 3] = new Vector2d(placeableObject.getPosition().X - placeableObject.GetWidth() / 2.0, placeableObject.getPosition().Y + placeableObject.GetHeight() / 2.0);
            }
            return vertices;
        }
    }
}
