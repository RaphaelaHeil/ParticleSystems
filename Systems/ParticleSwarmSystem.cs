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
    class ParticleSwarmSystem : ParticleSystem
    {

        //http://www.swarmintelligence.org/tutorials.php

        private ParticleSwarmSettingsPanel Panel = new ParticleSwarmSettingsPanel();
        private ParticleSwarmTopology ParticleSwarmTopology;


        protected override void Initialise()
        {
            AddOptimaAsPlaceableObjects(Panel.GetOptima());

            ParticleSwarmFitnessStrategy fitnessStrategy = new ParticleSwarmPNormFitnessStrategy(2, Panel.GetOptima(), Panel.AreWeightsIgnored());
            SwarmParticleGenerator particleGenerator = new SwarmParticleGenerator(ParticleSettings, Panel.GetXMin(), Panel.GetXMax(), Panel.GetyMin(), Panel.GetYMax());

            switch (Panel.GetSelectedTopology())
            {
                case Topology.Global:
                    ParticleSwarmTopology = new GlobalParticleSwarmTopology(fitnessStrategy, particleGenerator);
                  
                    break;
                case Topology.Ring:
                    ParticleSwarmTopology = new RingParticleSwarmTopology(fitnessStrategy, particleGenerator, Panel.GetNeighbourhoodSize());
                   break;
                case Topology.Mesh:
                    ParticleSwarmTopology = new MeshParticleSwarmTopology(fitnessStrategy, particleGenerator, Panel.GetNeighbourhoodSize(), Context.GetIdHolder().Width, Context.GetIdHolder().Height);
                    break;
                default:
                    break;
            }

            ParticleSwarmTopology.Initialise(ParticleSettings.GetInitialNumberOfParticles());
        }

        private void AddOptimaAsPlaceableObjects(HashSet<SwarmOptimum> optima)
        {
            Context.clearPlaceableObjects();
            foreach (var optimum in optima)
            {
                Context.addPlacableObject(new PlaceableObject(PlaceableObject.Shape.Rectangle, (int)optimum.GetPosition().X, (int)optimum.GetPosition().Y, 5, 5));
            }
        }

        protected override void UpdateParticlePositions()
        {
            ParticleSwarmTopology.UpdateParticlePositions();
        }

        protected override void UpdateVBOs()
        {
            Tuple<Vector2d[], Vector3d[]>vbos =  ParticleSwarmTopology.GetVBOs();
            ParticlePositions = vbos.Item1;
            ParticleColours = vbos.Item2;
        }


        public override string GetDescription()
        {
            return "XXX"; //TODO :D  
        }

        public override ParticleSettings GetParticleSettings()
        {
            ParticleSettings.WithAgingVelocity(0).WithAgingVelocityEnabled(false).
                WithLifetime(1).WithLifetimeEnabled(false).
                WithNewParticlesPerFrame(0).WithNewParticlesPerFrameEnabled(false).
                WithVelocity(0.02).WithVelocityEnabled(true).
                WithInitialNumberOfParticles(50).
                WithGlBackgroundColor(System.Drawing.Color.DarkGray);

            return ParticleSettings;
        }

        protected override void DecrementLifetime()
        {
            ParticleSwarmTopology.DecrementLifetime();
        }

        protected override void GenerateNewParticles()
        {
            ParticleSwarmTopology.GenerateNewParticles();
        }

        protected override void RemoveExpiredParticles()
        {
            ParticleSwarmTopology.RemoveExpiredParticles();
        }

        public override ParticleSystemSettingsPanel GetParticleSystemSettingsPanel()
        {
            return Panel;
        }

    }


    public enum Topology
    {
        Global,
        Ring,
        Mesh
    };
}
