using System;
using OpenTK;
using ParticleSystems.Particles;

namespace ParticleSystems.ParticleGeneration
{
    /// <summary>
    /// Generates regular particles with random values.
    /// </summary>
    class RandomParticleGenerator : ParticleGenerator
    {
        private int Width;
        private int Height;
        private int MaxLifetime;
        private int MaxAgingVelocity;
        private double MaxVelocity;

        private Random Random = new Random();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="width">Width of the space in which to generate particles; generally equals the glControl width</param>
        /// <param name="height">Height of the space in which to generate particles; generally equals the glControl height</param>
        /// <param name="maxLifetime">Maximum lifetime of newly generated particles</param>
        /// <param name="maxAgingVelocity">Maximum velocity at which particles age</param>
        /// <param name="maxVelocity">Maximum velocity</param>
        public RandomParticleGenerator(int width, int height, int maxLifetime, int maxAgingVelocity, double maxVelocity)
        {
            this.Width = width;
            this.Height = height;
            this.MaxLifetime = maxLifetime;
            this.MaxAgingVelocity = maxAgingVelocity;
            this.MaxVelocity = maxVelocity;
        }

        /// <summary>
        /// Generates a new particle.
        /// </summary>
        /// <returns>Newly generated particle</returns>
        public Particle GenerateParticle()
        {
            int lifetime = Random.Next(1,MaxLifetime); 
            int agingVelocity = Random.Next(1,MaxAgingVelocity);
            double velocity = Random.NextDouble() * MaxVelocity;
            return new Particle(CreateRandomPosition(), MaxLifetime, agingVelocity, velocity);
        }

        private Vector2d CreateRandomPosition()
        {
            double x = Random.NextDouble() * Width;
            double y = Random.NextDouble() * Height;
            return new Vector2d(x, y);
        }
    }
}
