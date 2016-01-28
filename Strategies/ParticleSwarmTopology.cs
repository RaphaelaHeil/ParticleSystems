using OpenTK;
using ParticleSystems.Particles;
using System;

namespace ParticleSystems.Strategies
{
    /// <summary>
    /// Abstract super class for swarm topologies.
    /// </summary>
    abstract class ParticleSwarmTopology
    {
        protected Vector3d GetColour(SwarmParticle particle)
        {
            double fitness = particle.GetCurrentFitness();
           
            return new Vector3d(0.0, fitness/70.0, 0.6);
        }

        public abstract void Initialise(int initialNumberOfParticles);

        public abstract void UpdateParticlePositions();

        public abstract Tuple<Vector2d[], Vector3d[]> GetVBOs();

        public abstract void DecrementLifetime();

        public abstract void GenerateNewParticles();

        public abstract void RemoveExpiredParticles();
    }
}
