using System.Collections.Generic;
using OpenTK;
using ParticleSystems.Particles;

namespace ParticleSystems.PositionUpdate
{

    /// <summary>
    /// Linearily translates particle positions.
    /// </summary>
    class LinearPositionUpdater : PositionUpdater
    {

        private const int DEFAULT_DELTA = 1;
        private Vector2d Translation;

        /// <summary>
        /// Default constructor, sets x and y updates to 1 each.
        /// </summary>
        public LinearPositionUpdater()
        {
            Translation = new Vector2d(DEFAULT_DELTA, DEFAULT_DELTA);
        }

        /// <summary>
        /// Constructs a LinearPositionUpdater that translates the positions by the given values.
        /// </summary>
        /// <param name="deltaX">Translation to be applied to the x coordinate</param>
        /// <param name="deltaY">Translation to be applied to the y coordinate</param>
        public LinearPositionUpdater(double deltaX, double deltaY)
        {
            Translation = new Vector2d(deltaX, deltaY);
        }

        /// <see cref="PositionUpdater.UpdatePositions(List{Particle})"/>
        public void UpdatePositions(List<Particle> particles)
        {
            foreach (var particle in particles)
            {
                particle.updatePosition(Translation);
            }
        }
    }
}
