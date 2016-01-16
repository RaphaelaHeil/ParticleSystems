using OpenTK;
using ParticleSystems.Particles;
using ParticleSystems.Strategies;
using System;
using System.Collections.Generic;

namespace ParticleSystems.PositionUpdate
{
    class SwarmPositionUpdater : PositionUpdater
    {
        private Vector2d GlobalBestLocation = new Vector2d(0.0);
        private double GlobalBestFitness =double.MaxValue;
        private bool changed = false;

        public void UpdateSwarmPositions(List<SwarmParticle> particles)
        {
            Vector2d globalBestCache = new Vector2d();
            double fitnessCache = GlobalBestFitness;
            foreach (var particle in particles)
            {
                particle.updatePosition(GlobalBestLocation);

                if (particle.GetBestFitness() < fitnessCache)
                {
                    globalBestCache = particle.GetBestLocation();
                    fitnessCache = particle.GetBestFitness();
                    changed = true;
                }
            }
            if (changed)
            {
                GlobalBestLocation = globalBestCache;
                GlobalBestFitness = fitnessCache;
            }
            changed = false;
        }

        public void UpdatePositions(List<Particle> particles)
        {
            // substituted by custom method signature to avoid casting :) 
            throw new NotImplementedException("Not implemented. Use custom implementation with explicit List of SwarmParticles!");
        }

        public void SetContext(Context context) {
            throw new NotImplementedException();
        }
    }
}
