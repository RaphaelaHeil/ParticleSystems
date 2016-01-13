using OpenTK;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.Particles;
using ParticleSystems.PositionUpdate;
using ParticleSystems.SettingsPanels;
using ParticleSystems.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace ParticleSystems.Systems
{
    class ParticleSwarmSystem : ParticleSystem
    {

        //http://www.swarmintelligence.org/tutorials.php

        private ParticleSwarmSettingsPanel Panel = new ParticleSwarmSettingsPanel();
        private SwarmPositionUpdater PositionUpdater;
        private new List<SwarmParticle> Particles;

        private SwarmParticleGenerator ParticleGenerator;

        public override ParticleSystemSettingsPanel GetParticleSystemSettingsPanel()
        {
            
            return Panel;
        }



        protected override void Initialise()
        {
            Particles = new List<SwarmParticle>();
            //TODO read values from Settings

            //TODO: get P value/strategy selection from panel!

            ParticleSwarmFitnessStrategy fitnessStrategy = new ParticleSwarmPNormFitnessStrategy(2, Panel.GetTargetPosition());
            ParticleGenerator = new SwarmParticleGenerator(fitnessStrategy, Context.GetIdHolder().Width, Context.GetIdHolder().Height);
            PositionUpdater = new SwarmPositionUpdater();

            ////generate new particles 
            CreateInitialParticles();

        }



        protected override void UpdateParticlePositions()
        {
            PositionUpdater.UpdateSwarmPositions(Particles);
        }

        protected override void UpdateVBOs()
        {
            ParticlePositions = new Vector2d[Particles.Count]; //TODO: find a safer solution :( 
            ParticleColours = new Vector3d[Particles.Count];
            for (int i = 0; i < Particles.Count; i++)
            {
                ParticlePositions[i] = Particles.ElementAt(i).GetPosition();
                ParticleColours[i] = new Vector3d(Particles.ElementAt(i).GetBestFitness()/80.0); //TODO: change accordingly
            }
        }


        public override string GetDescription()
        {
            return "XXX"; //TODO :D  
        }

        public override ParticleSettings GetParticleSettings()
        {
            ParticleSettings.WithAgingVelocity(0).WithAgingVelocityEnabled(false).WithLifetime(0).WithLifetimeEnabled(false).WithNewParticlesPerFrame(0).WithNewParticlesPerFrameEnabled(false);
            ParticleSettings.WithVelocity(1).WithVelocityEnabled(false).WithInitialNumberOfParticles(50);

            return ParticleSettings;
        }

        private void CreateInitialParticles()
        {
            for (int i = 0; i < ParticleSettings.GetInitialNumberOfParticles(); i++)
            {
                Particles.Add(ParticleGenerator.GenerateParticle());
            }
        }

        protected override void DecrementLifetime()
        {
            //XXX not needed
        }

        protected override void GenerateNewParticles()
        {
            //XXX not needed
        }

        protected override void RemoveExpiredParticles()
        {
            // XXX not needed
        }

    }
}
