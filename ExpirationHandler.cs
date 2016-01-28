using ParticleSystems.Particles;
using System.Collections.Generic;

namespace ParticleSystems
{
    /// <summary>
    /// Handles the particle expiration, i.e. removing expired particles from the system.
    /// </summary>
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
