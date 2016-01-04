using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ParticleSystems
{
    class RandomParticleGenerator : ParticleGenerator
    {
        private int maxX;
        private int maxY;
        private int maxLifetime;
        private int maxAgingVelocity;
        private double maxVelocity;

        private Random random = new Random();

        public RandomParticleGenerator(int maxX, int maxY, int maxLifetime, int maxAgingVelocity, double maxVelocity)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            this.maxLifetime = maxLifetime;
            this.maxAgingVelocity = maxAgingVelocity;
            this.maxVelocity = maxVelocity;
        }

        public Particle GenerateParticle()
        {
            int lifetime = random.Next(1,maxLifetime); 
            int agingVelocity = random.Next(1,maxAgingVelocity);
            double velocity = random.NextDouble() * maxVelocity;
            return new Particle(CreateRandomPosition(), maxLifetime, agingVelocity, velocity);
        }

        private Vector2d CreateRandomPosition()
        {
            double x = random.NextDouble() * maxX;
            double y = random.NextDouble() * maxY;
            return new Vector2d(x, y);
        }
    }
}
