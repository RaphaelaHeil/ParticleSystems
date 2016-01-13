using ParticleSystems.Particles;
using System.Collections.Generic;

namespace ParticleSystems
{
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
