using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems.Strategies
{
    class SwarmOptimum
    {
        private Vector2d Position = new Vector2d(0.0);
        private int Weight = 1;


        public SwarmOptimum(Vector2d position, int weight)
        {
            Position = position;
            Weight = weight;
        }

        public SwarmOptimum(Vector2d position)
        {
            Position.Yx = position;
        }

        public Vector2d GetPosition()
        {
            return Position;
        }

        public int GetWeight()
        {
            return Weight;
        }

        public void SetWeight(int weight)
        {
            Weight = weight;
        }

        public override string ToString()
        {
            return Position.ToString() + " - Weight: " + Weight;
        }
    }
}
