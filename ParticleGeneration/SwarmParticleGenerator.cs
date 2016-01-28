using OpenTK;
using ParticleSystems.Particles;
using ParticleSystems.Strategies;
using ParticleSystems.Systems;
using System;

namespace ParticleSystems.ParticleGeneration
{

    /// <summary>
    /// Generates swarm particles.
    /// </summary>
    class SwarmParticleGenerator
    {
        private int XMin;
        private int XMax;
        private int YMin;
        private int YMax;
        private int MaxLifetime = 1;
        private int MaxAgingVelocity = 0;
        private double MaxVelocity = 0.02;
      
        private static Random Random = new Random();

        public SwarmParticleGenerator(ParticleSettings particleSettings, int xMin = 0, int xMax = 600, int yMin = 0, int yMax = 0)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
          
            MaxLifetime = particleSettings.GetLifetime();
            MaxAgingVelocity = particleSettings.GetAgingVelocity();
            MaxVelocity = particleSettings.GetVelocity();
        }

        /// <summary>
        /// Generates a new swarm particle.
        /// </summary>
        /// <returns>Newly generated swarm particle</returns>
        public SwarmParticle GenerateParticle()
        {
            return new SwarmParticle(CreateRandomPosition(), MaxLifetime, MaxAgingVelocity, MaxVelocity);
        }

        private Vector2d CreateRandomPosition()
        {
            int x = Random.Next(XMin, XMax);
            int y = Random.Next(YMin, YMax);
            return new Vector2d(x, y);
        }
    }
}
