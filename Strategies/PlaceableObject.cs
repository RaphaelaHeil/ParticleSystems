﻿using OpenTK;

namespace ParticleSystems
{
    /// <summary>
    /// Placable Object class.
    /// Contains the necessary values for an object to be placed on the graphic plane. 
    /// </summary>
    class PlaceableObject
    {
        public enum Shape { Square, Rectangle };

        private Shape objectShape;
        private Vector2d position;
        private Vector2d size;

        /// <summary>
        /// Constructor for the placable Object. 
        /// Shape, position and size has to be given to create an object.
        /// </summary>
        /// <param name="objectShape"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="sizeWidth"></param>
        /// <param name="sizeHeight"></param>
        public PlaceableObject(Shape objectShape, int positionX, int positionY, int sizeWidth, int sizeHeight)
        {
            this.objectShape = objectShape;
            position = new Vector2d(positionX, positionY);
            size = new Vector2d(sizeWidth, sizeHeight);
        }

        //------------------- getter, setter ------------------------
        public void setObjectShape(Shape objectShape)
        {
            this.objectShape = objectShape;
        }
        public Shape getObjectShape()
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

        public double GetHeight()
        {
            return size.Y;
        }

        public double GetWidth()
        {
            return size.X;
        }

        public override string ToString()
        {
            return objectShape + " - Position: " + position.X + ", " + position.Y + " - Size: " + size.X + ", " + size.Y;
        }
    }
}
