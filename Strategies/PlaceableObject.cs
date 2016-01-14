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
        private int positionX;
        private int positionY;
        private int sizeHeight;
        private int sizeWidth;

        public PlaceableObject(string objectShape, int positionX, int positionY, int sizeHeight, int sizeWidth)
        {
            this.objectShape = objectShape;
            this.positionX = positionX;
            this.positionY = positionY;
            this.sizeHeight = sizeHeight;
            this.sizeWidth = sizeWidth;
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
        public void setPositionX(int positionX)
        {
            this.positionX = positionX;
        }
        public int getPositionX()
        {
            return this.positionX;
        }
        public void setPositionY(int positionY)
        {
            this.positionY = positionY;
        }
        public int getPositionY()
        {
            return this.positionY;
        }
        public void setSizeHeight(int sizeHeight)
        {
            this.sizeHeight = sizeHeight;
        }
        public int getSizeHeight()
        {
            return this.sizeHeight;
        }
        public void setSizeWidth(int sizeWidth)
        {
            this.sizeWidth = sizeWidth;
        }

        public int getSizeWidth()
        {
            return this.sizeWidth;
        }
    }
}
