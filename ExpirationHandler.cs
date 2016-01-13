using ParticleSystems.Particles;
using System.Collections.Generic;

namespace ParticleSystems
{
    //TODO
    class ExpirationHandler
    {
        /// <summary>
        /// Removes all expired particles from the given collection of particles.
        /// </summary>
        /// <param name="particles">Particles to check for expiration</param>
        /// <returns>Number of removed particles</returns>
        public int handleExpiration(List<Particle> particles)
        {
            return particles.RemoveAll(particle => particle.IsExpired());
        }
    }
}
