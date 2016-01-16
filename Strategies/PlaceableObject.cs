using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{
    class PlaceableObject
    {
        private string objectShape;
        private Vector2d position;
        private Vector2d size;

        public PlaceableObject(string objectShape, int positionX, int positionY, int sizeHeight, int sizeWidth)
        {
            this.objectShape = objectShape;
            position = new Vector2d(positionX, positionY);
            size = new Vector2d(sizeHeight, sizeWidth);
        }

        //------------------- getter, setter ------------------------
        public void setObjectShape(string objectShape)
        {
            this.objectShape = objectShape;
        }
        public string getObjectShape()
        {
            return this.objectShape;
        }
        public void setPositionX(Vector2d position)
        {
            this.position = position;
        }
        public Vector2d getPosition()
        {
            return this.position;
        }
        public void setSize(Vector2d size)
        {
            this.size = size;
        }
        public Vector2d getSize()
        {
            return this.size;
        }
    }
}
