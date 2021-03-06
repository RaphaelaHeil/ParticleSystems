﻿using System;
using System.Linq;
using OpenTK;
using ParticleSystems.SettingsPanels;
using ParticleSystems.PositionUpdate;
using ParticleSystems.ParticleGeneration;

namespace ParticleSystems.Systems
{
    /// <summary>
    /// A simple particle system for demonstration purposes that updates the particle's positions linearly.
    /// </summary>
    class LinearilyUpdatingParticleSystem : ParticleSystem
    {
        private PositionUpdater PositionUpdater = new LinearPositionUpdater();
        private LifetimeHandler LifetimeHandler = new LifetimeHandler();
        private ExpirationHandler ExpirationHandler = new ExpirationHandler();
        private Random Rand = new Random();

        private RandomParticleGenerator ParticleGenerator;
        private LinearSettings Panel = new LinearSettings();

        protected override void Initialise()
        {
            ParticleGenerator = new RandomParticleGenerator(Context.GetIdHolder().Width, Context.GetIdHolder().Height, ParticleSettings.GetLifetime(), ParticleSettings.GetAgingVelocity(), ParticleSettings.GetVelocity());
            PositionUpdater = new LinearPositionUpdater(Panel.GetXDirectionChange(), Panel.GetYDirectionChange());
            CreateInitialParticles();
        }

        protected override void UpdateVBOs()
        {
            ParticlePositions = new Vector2d[Particles.Count];
            ParticleColours = new Vector3d[Particles.Count];
            for (int i = 0; i < Particles.Count; i++)
            {
                ParticlePositions[i] = Particles.ElementAt(i).GetPosition();
                ParticleColours[i] = new Vector3d(0.0);
            }
        }

        protected override void DecrementLifetime()
        {
            LifetimeHandler.DecrementLifetime(Particles);
        }

        protected override void RemoveExpiredParticles()
        {
            ExpirationHandler.handleExpiration(Particles);
        }

        protected override void GenerateNewParticles()
        {
            if (ParticleSettings.IsNumberOfNewParticlesRandomlyGenerated())
            {
                int random = Rand.Next(ParticleSettings.GetNumberOfNewParticlesPerFrame());
                for (int i = 0; i < random; i++)
                {
                    Particles.Add(ParticleGenerator.GenerateParticle());
                }
            }
            else
            {
                for (int i = 0; i < ParticleSettings.GetNumberOfNewParticlesPerFrame(); i++)
                {
                    Particles.Add(ParticleGenerator.GenerateParticle());
                }
            }
        }

        protected override void UpdateParticlePositions()
        {
            PositionUpdater.UpdatePositions(Particles);
        }

        private void CreateInitialParticles()
        {
            for (int i = 0; i < ParticleSettings.GetInitialNumberOfParticles(); i++)
            {
                Particles.Add(ParticleGenerator.GenerateParticle());
            }
        }

        public override string GetDescription()
        {
            return "A simple particle system for demonstration purposes that updates the particle's positions linearly.";
        }

        public override ParticleSystemSettingsPanel GetParticleSystemSettingsPanel()
        {
            return Panel;
        }

        public override ParticleSettings GetParticleSettings()
        {
            return ParticleSettings;
        }
    }
}
