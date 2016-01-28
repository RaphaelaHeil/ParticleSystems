using ParticleSystems.Particles;
using System.Collections.Generic;

namespace ParticleSystems
{
    /// <summary>
    /// Handles particle aging.
    /// </summary>
    class LifetimeHandler
    {
        /// <summary>
        /// Applies aging to every particle in the given collection.
        /// </summary>
        /// <param name="particles">Particles to apply aging to</param>
        public void DecrementLifetime(List<Particle> particles)
        {
            foreach (Particle particle in particles)
            {
                particle.applyAging();
            }
        }
    }
}
