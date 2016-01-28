using System;
using System.Collections.Generic;
using System.Linq;
using ParticleSystems.Particles;
using ParticleSystems.Strategies;
using OpenTK;
using ParticleSystems.ParticleSwarmDataStructures;

namespace ParticleSystems.PositionUpdate
{
    /// <summary>
    /// Updates swarm particle positions based on local properties of the swarm.
    /// </summary>
    class LocalBestSwarmPositionUpdater : SwarmPositionUpdater
    {
        private int NeighbourhoodSize;

        public LocalBestSwarmPositionUpdater(ParticleSwarmFitnessStrategy fitnessStrategy, int neighbourhoodSize = 10) : base(fitnessStrategy)
        {
            NeighbourhoodSize = neighbourhoodSize;
        }

        public override void UpdateSwarmPositions(ParticleRing<SwarmParticle> particles)
        {
            for (int i = 0; i < particles.Count(); i++)
            {
                SwarmParticle center = particles.ElementAt(i);
                List<SwarmParticle> neighbours = particles.GetNAdjacentParticles(i, NeighbourhoodSize);

                neighbours.OrderBy(n => n.GetCurrentFitness());

                UpdateParticle(center, neighbours.Last());
            }
        }

        public override SwarmParticleMesh UpdateSwarmPositions(SwarmParticleMesh particles)
        {
            SwarmParticleMesh newMesh = new SwarmParticleMesh(particles);

            for (int i = 0; i < particles.GetRowCount(); i++)
            {
                for (int j = 0; j < particles.GetColumnCount(); j++)
                {
                    List<SwarmParticle> neighbourhood = particles.GetListFromCell(i, j);
                    if (neighbourhood.Count > 0)
                    {

                        neighbourhood.OrderBy(n => n.GetCurrentFitness());
                        SwarmParticle fittestNeighbour = neighbourhood.Last();
                        neighbourhood.Remove(fittestNeighbour);
                        foreach (var particle in neighbourhood)
                        {
                            UpdateParticle(particle, fittestNeighbour);
                            newMesh.AddParticle(particle);
                        }
                        UpdateParticle(fittestNeighbour, fittestNeighbour);
                        newMesh.AddParticle(fittestNeighbour);
                    }
                }
            }
            return newMesh;
        }

        private void UpdateParticle(SwarmParticle particle, SwarmParticle fittestNeighbour)
        {
            Vector2d Translation = particle.GetTranslation();
            Vector2d BestPosition = particle.GetBestLocation();
            Vector2d Position = particle.GetPosition();

            Translation.X = Translation.X * InertiaWeight + AccelerationConstant * GaussianRandomHelper.GetRandomValue(Mean, StandardDeviation) * (BestPosition.X - Position.X) + AccelerationConstant * GaussianRandomHelper.GetRandomValue(Mean, StandardDeviation) * (fittestNeighbour.GetPosition().X - Position.X);
            Translation.Y = Translation.Y * InertiaWeight + AccelerationConstant * GaussianRandomHelper.GetRandomValue(Mean, StandardDeviation) * (BestPosition.Y - Position.Y) + AccelerationConstant * GaussianRandomHelper.GetRandomValue(Mean, StandardDeviation) * (fittestNeighbour.GetPosition().Y - Position.Y);

            particle.SetTranslation(Translation);
            particle.updatePosition(Translation);

            UpdateParticleFitness(particle);
        }

        private void UpdateParticleFitness(SwarmParticle particle)
        {
            double currentFitness = FitnessStrategy.GetFitness(particle.GetPosition());
            if (currentFitness < particle.GetCurrentFitness())
            {
                particle.SetCurrentLocationAsBest();
            }
            particle.SetCurrentFitness(currentFitness);
        }

        public override void UpdateSwarmPositions(List<SwarmParticle> particles)
        {
            //not needed at the moment, don't do anything
        }
    }
}
