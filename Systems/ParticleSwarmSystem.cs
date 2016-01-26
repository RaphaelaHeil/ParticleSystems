using OpenTK;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.Particles;
using ParticleSystems.PositionUpdate;
using ParticleSystems.SettingsPanels;
using ParticleSystems.Strategies;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;

namespace ParticleSystems.Systems
{

    public enum Topology
    {

        [Description("Global Best")]
        GlobalBest,
        [Description("Ring (Local Best)")]
        Ring
    };

    // public enum Shape { Square, Rectangle};
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
            //Panel.GetSelectedTopology();
            

            AddOptimaAsPlaceableObjects(Panel.GetOptima());
            


            ParticleSwarmFitnessStrategy fitnessStrategy = new ParticleSwarmPNormFitnessStrategy(2, Panel.GetOptima());
            ParticleGenerator = new SwarmParticleGenerator(fitnessStrategy, Context.GetIdHolder().Width, Context.GetIdHolder().Height);
            PositionUpdater = new SwarmPositionUpdater();

            ////generate new particles 
            CreateInitialParticles();

        }

        private void AddOptimaAsPlaceableObjects(HashSet<Vector2d> optima)
        {
            Context.clearPlaceableObjects();
            foreach(var optimum in optima)
            {
                Context.addPlacableObject(new PlaceableObject(PlaceableObject.Shape.Rectangle, (int) optimum.X,(int) optimum.Y, 5,5));
            }           
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
                ParticleColours[i] = new Vector3d(Particles.ElementAt(i).GetCurrentFitness()/80.0); //TODO: change accordingly
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
