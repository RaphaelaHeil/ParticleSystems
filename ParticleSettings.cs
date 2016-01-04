using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{
    class ParticleSettings
    {
        private int initialNumberOfParticles = 20;
        private int newParticlesPerFrame = 10;
        private int lifetime = 5;
        private int agingVelocity = 1;
        private double velocity = 1;
        private bool numberOfNewParticlesRandomlyGenerated = false;
        private bool lifetimeRandomlyGenerated = false;
        private bool agingVelocityRandomlyGenerated = false;
        private bool velocityRandomlyGenerated = false;

        public void SetInitialNumberOfParticles(int InitialNumberOfParticles)
        {
            initialNumberOfParticles = InitialNumberOfParticles;
        }

        public void SetNewParticlesPerFrame(int NewParticlesPerFrame)
        {
            newParticlesPerFrame = NewParticlesPerFrame;
        }

        public void SetLifetime(int Lifetime)
        {
            lifetime = Lifetime;
        }

        public void SetAgingVelocity(int AgingVelocity)
        {
            agingVelocity = AgingVelocity;
        }

        public void SetVelocity(double Velocity)
        {
            velocity = Velocity;
        }

        public void SetNumberOfNewParticlesIsRandomlyGenerated(bool randomly)
        {
            numberOfNewParticlesRandomlyGenerated = randomly;
        }

        public void SetLifetimeIsRandomlyGenerated(bool randomly)
        {
            lifetimeRandomlyGenerated = randomly;
        }

        public void SetAgingVelocityIsRandomlyGenerated(bool randomly)
        {
            agingVelocityRandomlyGenerated = randomly;
        }

        public void SetVelocityIsRandomlyGenerated(bool randomly)
        {
            velocityRandomlyGenerated = randomly;
        }

        public int GetInitialNumberOfParticles()
        {
            return initialNumberOfParticles;
        }

        public int GetNumberOfNewParticlesPerFrame()
        {
            return newParticlesPerFrame;
        }

        public int GetLifetime()
        {
            return lifetime;
        }

        public int GetAgingVelocity()
        {
            return agingVelocity;
        }

        public double GetVelocity()
        {
            return velocity;
        }

        public bool IsNumberOfNewParticlesRandomlyGenerated()
        {
            return numberOfNewParticlesRandomlyGenerated;
        }

        public bool IsLifetimeRandomlyGenerated()
        {
            return lifetimeRandomlyGenerated;
        }

        public bool IsAgingVelocityRandomlyGenerated()
        {
            return agingVelocityRandomlyGenerated;
        }

        public bool IsVelocityRandomlyGenerated()
        {
            return velocityRandomlyGenerated;
        }
    }
}
