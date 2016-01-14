using System;
using OpenTK;
using ParticleSystems.Particles;

namespace ParticleSystems.ParticleGeneration
{
    class AirFlowParticleGenerator : ParticleGenerator 
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
        public AirFlowParticleGenerator(int width, int height, int maxLifetime, int maxAgingVelocity, double maxVelocity) {
            this.Width = width;
            this.Height = height;
            this.MaxLifetime = maxLifetime;
            this.MaxAgingVelocity = maxAgingVelocity;
            this.MaxVelocity = maxVelocity;
        }

        public Particle GenerateParticle() {
            int lifetime = MaxLifetime;
            int agingVelocity = MaxAgingVelocity;
            double velocity = Random.NextDouble() * MaxVelocity;
            return new Particle(CreateStartingPosition(), MaxLifetime, agingVelocity, velocity);
        }

        private Vector2d CreateStartingPosition() {
            double x = -100;
            double y = Random.NextDouble() * Height;
            return new Vector2d(x, y);
        }
    }
}
