using OpenTK;
using ParticleSystems.Particles;
using System;
using System.Collections.Generic;
using ParticleSystems.SettingsPanels;
using ParticleSystems.Strategies;
using ParticleSystems.ParticleSwarmDataStructures;

namespace ParticleSystems.PositionUpdate
{
    abstract class SwarmPositionUpdater: PositionUpdater
    {
        protected double InertiaWeight = 0.7298;
        protected double AccelerationConstant = 1.4961;
        protected double Mean = 0.5;
        protected double StandardDeviation = 0.5;

        protected ParticleSwarmFitnessStrategy FitnessStrategy;

        public SwarmPositionUpdater(ParticleSwarmFitnessStrategy fitnessStrategy)
        {
            FitnessStrategy = fitnessStrategy;
        }


        public abstract void UpdateSwarmPositions(List<SwarmParticle> particles);

        public abstract void UpdateSwarmPositions(ParticleRing<SwarmParticle> particles);

        public abstract SwarmParticleMesh UpdateSwarmPositions(SwarmParticleMesh particles);

        public void UpdatePositions(List<Particle> particles)
        {
            // substituted by custom method signature to avoid casting :) 
            // not needed here, therefore don't do anything
        }

        public void SetContext(Context context)
        {
           // not needed here, therefore don't do anything
        }

        public void SetSettingsPanel(ParticleSystemSettingsPanel settingsPanel)
        {
            // not needed here, therefore don't do anything
        }
    }
}
