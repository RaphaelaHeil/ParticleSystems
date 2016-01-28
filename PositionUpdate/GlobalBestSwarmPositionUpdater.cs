using OpenTK;
using ParticleSystems.Particles;
using ParticleSystems.SettingsPanels;
using ParticleSystems.Strategies;
using System;
using System.Collections.Generic;
using ParticleSystems.ParticleSwarmDataStructures;

namespace ParticleSystems.PositionUpdate
{
    class GlobalBestSwarmPositionUpdater: SwarmPositionUpdater
    {
        private Vector2d GlobalBestLocation = new Vector2d(0.0);
        private double GlobalBestFitness = double.MaxValue;
        private bool changed = false;

        public GlobalBestSwarmPositionUpdater(ParticleSwarmFitnessStrategy fitnessStrategy) : base(fitnessStrategy)
        {

        }
     
        public override void UpdateSwarmPositions(List<SwarmParticle> particles)
        {
            Vector2d globalBestCache = new Vector2d();
            double fitnessCache = GlobalBestFitness;
            foreach (var particle in particles)
            {
                UpdateParticlePosition(particle);
                UpdateParticleFitness(particle);
               
                if (particle.GetOverallBestFitness() < fitnessCache)
                {
                    globalBestCache = particle.GetBestLocation();
                    fitnessCache = particle.GetOverallBestFitness();
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

 
        private void UpdateParticlePosition(SwarmParticle particle)
        {
            Vector2d Translation = particle.GetTranslation();
            Vector2d BestPosition = particle.GetBestLocation();
            Vector2d Position = particle.GetPosition();

            Translation.X = Translation.X * InertiaWeight + AccelerationConstant * GaussianRandomHelper.GetRandomValue(Mean, StandardDeviation) * (BestPosition.X - Position.X) + AccelerationConstant * GaussianRandomHelper.GetRandomValue(Mean, StandardDeviation) * (GlobalBestLocation.X - Position.X);
            Translation.Y = Translation.Y * InertiaWeight + AccelerationConstant * GaussianRandomHelper.GetRandomValue(Mean, StandardDeviation) * (BestPosition.Y - Position.Y) + AccelerationConstant * GaussianRandomHelper.GetRandomValue(Mean, StandardDeviation) * (GlobalBestLocation.Y - Position.Y);

            particle.SetTranslation(Translation);
            particle.updatePosition(Translation);
        }

        private void UpdateParticleFitness(SwarmParticle particle)
        {
            double currentFitness = FitnessStrategy.GetFitness(particle.GetPosition());
            double bestFitness = particle.GetOverallBestFitness();

            particle.SetCurrentFitness(currentFitness);

            if (currentFitness < bestFitness)
            {
                particle.UpdateFittestValues(currentFitness);
            }
        }

        public override void UpdateSwarmPositions(ParticleRing<SwarmParticle> particles)
        {
            throw new NotImplementedException(); //TODO
        }

        public override SwarmParticleMesh UpdateSwarmPositions(SwarmParticleMesh particles)
        {
            throw new NotImplementedException(); //TODO
        }
    }
}
