using OpenTK;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.SettingsPanels;
using ParticleSystems.Strategies;
using System.Collections.Generic;
using System;

namespace ParticleSystems.Systems
{
    /// <summary>
    /// Particle system that implements the particle swarm optimisation, looking for 1 to n user defined optima in the search space.
    /// <seealso cref="http://www.swarmintelligence.org/tutorials.php"/>
    /// </summary>
    class ParticleSwarmSystem : ParticleSystem
    {
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
            return "Particle system that implements the particle swarm optimisation, looking for 1 to n user defined optima in the search space.";
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
