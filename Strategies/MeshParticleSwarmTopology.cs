﻿using OpenTK;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.ParticleSwarmDataStructures;
using ParticleSystems.PositionUpdate;
using System;

namespace ParticleSystems.Strategies
{
    /// <summary>
    /// Particle swarm topology that searches for optima using a mesh/grid.
    /// </summary>
    class MeshParticleSwarmTopology : ParticleSwarmTopology
    {
        private SwarmParticleMesh Particles;
        private SwarmPositionUpdater PositionUpdater;
        private SwarmParticleGenerator ParticleGenerator;

        private ParticleSwarmFitnessStrategy FitnessStrategy;

        private Vector2d[] ParticlePositions;
        private Vector3d[] ParticleColours;

        public MeshParticleSwarmTopology(ParticleSwarmFitnessStrategy fitnessStrategy, SwarmParticleGenerator particleGenerator, int cellSize = 10, int gridWidth = 600, int gridHeight = 600)
        {
            Particles = new SwarmParticleMesh(cellSize, gridWidth, gridHeight);
            FitnessStrategy = fitnessStrategy;
            PositionUpdater = new LocalBestSwarmPositionUpdater(fitnessStrategy);
            ParticleGenerator = particleGenerator;
        }


        public override void Initialise(int initialNumberOfParticles)
        {
            for (int i = 0; i < initialNumberOfParticles; i++)
            {
                Particles.AddParticle(ParticleGenerator.GenerateParticle());
            }
        }

        public override void UpdateParticlePositions()
        {
            Particles = PositionUpdater.UpdateSwarmPositions(Particles);
        }

        public override Tuple<Vector2d[], Vector3d[]> GetVBOs()
        {
            ParticlePositions = new Vector2d[Particles.GetParticleCount()];
            ParticleColours = new Vector3d[Particles.GetParticleCount()];

            int indexCounter = 0;

            for (int i = 0; i < Particles.GetRowCount(); i++)
            {
                for (int j = 0; j < Particles.GetColumnCount(); j++)
                {
                    foreach (var particle in Particles.GetListFromCell(i, j))
                    {
                        ParticlePositions[indexCounter] = particle.GetPosition();
                        ParticleColours[indexCounter] = GetColour(particle);
                        indexCounter++;
                    }
                }
            }
            return new Tuple<Vector2d[], Vector3d[]>(ParticlePositions, ParticleColours);
        }

        public override void RemoveExpiredParticles()
        {
            //not supported at the moment, don't do anything
        }

        public override void DecrementLifetime()
        {
            //not supported at the moment, don't do anything
        }

        public override void GenerateNewParticles()
        {
            //not supported at the moment, don't do anything
        }
    }
}
