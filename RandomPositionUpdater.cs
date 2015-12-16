using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ParticleSystems
{
    class RandomPositionUpdater : PositionUpdater
    {
        private int upperX = 5;
        private int upperY = 5;
        private Random random = new Random();

        public void UpdatePosition(Particle particle)
        {
            double x = (random.NextDouble() - 0.5) * upperX;
            double y = (random.NextDouble() - 0.5) * upperY;
            particle.updatePosition(new Vector2d(x, y));

        }

        public void UpdatePositions(List<Particle> particles)
        {
            foreach(var particle in particles)
            {
                UpdatePosition(particle);
            }
        }
    }
}
