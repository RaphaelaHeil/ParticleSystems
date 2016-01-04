using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ParticleSystems
{
    class LinearPositionUpdater : PositionUpdater
    {

        private int deltaX = 1;
        private int deltaY = 1;
        private Vector2d translation;

        public LinearPositionUpdater()
        {
            translation = new Vector2d(deltaX, deltaY);
        }

        public LinearPositionUpdater(int DeltaX, int DeltaY)
        {
            translation = new Vector2d(DeltaX, DeltaY);
        }

        public void UpdatePosition(Particle particle)
        {
            particle.updatePosition(translation);
        }

        public void UpdatePositions(List<Particle> particles)
        {
            foreach (var particle in particles)
            {
                UpdatePosition(particle);
            }
        }
    }
}
