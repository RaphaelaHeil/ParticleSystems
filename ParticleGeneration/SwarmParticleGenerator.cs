using OpenTK;
using ParticleSystems.Particles;
using ParticleSystems.Strategies;
using System;

namespace ParticleSystems.ParticleGeneration
{
    class SwarmParticleGenerator
    {
        private ParticleSwarmFitnessStrategy FitnessStrategy;
        private int Width;
        private int Height;
        private int MaxLifetime = 1;
        private int MaxAgingVelocity = 0;
        private double MaxVelocity = 1.0;

        private static Random Random = new Random();

        public SwarmParticleGenerator(ParticleSwarmFitnessStrategy fitnessStrategy, int width, int height)
        {
            FitnessStrategy = fitnessStrategy;
            Width = width;
            Height = height;
        }


        public SwarmParticleGenerator(ParticleSwarmFitnessStrategy fitnessStrategy, int width, int height, int maxLifetime, int maxAgingVelocity, double maxVelocity)
        {
            FitnessStrategy = fitnessStrategy;
            Width = width;
            Height = height;
            MaxLifetime = maxLifetime;
            MaxAgingVelocity = maxAgingVelocity;
            MaxVelocity = maxVelocity;
        }


        public SwarmParticle GenerateParticle()
        {
            return new SwarmParticle(CreateRandomPosition(), FitnessStrategy);
        }

        private Vector2d CreateRandomPosition()
        {
            double x = Random.NextDouble() * Width;
            double y = Random.NextDouble() * Height;
            return new Vector2d(x, y);
        }
    }
}
