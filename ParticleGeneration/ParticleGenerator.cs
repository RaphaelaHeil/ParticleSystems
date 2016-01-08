namespace ParticleSystems
{
    /// <summary>
    /// Interface to group classes generating particles. 
    /// </summary>
    interface ParticleGenerator
    {
        /// <summary>
        /// Generates a new particle.
        /// </summary>
        /// <returns>Newly generated particle</returns>
        Particle GenerateParticle();
    }
}
