using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ParticleSystems
{
    class PositionGenerator
    {
        private const double MAX_POSITION = 400.0;
        private Random rand = new Random();

        public Vector2d generateRandomPosition()
        {
            double x = rand.NextDouble() * MAX_POSITION;
            double y = rand.NextDouble() * MAX_POSITION;

            return new Vector2d(x, y);
        }

        public void updatePositionRandomly(Particle particle)
        {
            double x = (rand.NextDouble()-0.5) * rand.Next(10);
            double y = (rand.NextDouble()-0.5) * rand.Next(10);
            particle.updatePosition(new Vector2d(x, y));
        }

        public void updatePositionByOne(Particle particle)
        {
            particle.updatePosition(new Vector2d(1.0, 1.0));
        }
    }
}
