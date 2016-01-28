using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using ParticleSystems.Particles;
using ParticleSystems.PositionUpdate;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.ParticleSwarmDataStructures;

namespace ParticleSystems.Strategies
{
    class RingParticleSwarmTopology : ParticleSwarmTopology
    {
        private ParticleRing<SwarmParticle> Particles = new ParticleRing<SwarmParticle>();
        private SwarmPositionUpdater PositionUpdater;
        private SwarmParticleGenerator ParticleGenerator;
        private int NeighbourhoodSize = 1;

        private ParticleSwarmFitnessStrategy FitnessStrategy;

        private Vector2d[] ParticlePositions;
        private Vector3d[] ParticleColours;

        public RingParticleSwarmTopology(ParticleSwarmFitnessStrategy fitnessStrategy, SwarmParticleGenerator particleGenerator, int neighbourhoodSize)
        {
            NeighbourhoodSize = neighbourhoodSize;
            FitnessStrategy = fitnessStrategy;
            PositionUpdater = new LocalBestSwarmPositionUpdater(fitnessStrategy, NeighbourhoodSize);
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
            PositionUpdater.UpdateSwarmPositions(Particles);
        }

        public override Tuple<Vector2d[], Vector3d[]> GetVBOs()
        {
            ParticlePositions = new Vector2d[Particles.Count()];
            ParticleColours = new Vector3d[Particles.Count()];
            for (int i = 0; i < Particles.Count(); i++)
            {
                ParticlePositions[i] = Particles.ElementAt(i).GetPosition();
                ParticleColours[i] = GetColour(Particles.ElementAt(i));
            }

            return new Tuple<Vector2d[], Vector3d[]>(ParticlePositions, ParticleColours);
        }

        public override void DecrementLifetime()
        {
            //throw new NotImplementedException();
        }

        public override void GenerateNewParticles()
        {
           // throw new NotImplementedException();
        }
        
        public override void RemoveExpiredParticles()
        {
          //  throw new NotImplementedException();
        }      
    }
}
