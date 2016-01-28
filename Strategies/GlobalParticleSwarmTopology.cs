using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParticleSystems.Particles;
using ParticleSystems.PositionUpdate;
using ParticleSystems.ParticleGeneration;
using OpenTK;

namespace ParticleSystems.Strategies
{
    class GlobalParticleSwarmTopology : ParticleSwarmTopology
    {
        private List<SwarmParticle> Particles = new List<SwarmParticle>();
        private SwarmPositionUpdater PositionUpdater;
        private SwarmParticleGenerator ParticleGenerator;

        private ParticleSwarmFitnessStrategy FitnessStrategy;

        private Vector2d[] ParticlePositions;
        private Vector3d[] ParticleColours;

        public GlobalParticleSwarmTopology(ParticleSwarmFitnessStrategy fitnessStrategy, SwarmParticleGenerator particleGenerator)
        {
            FitnessStrategy = fitnessStrategy;
            PositionUpdater = new GlobalBestSwarmPositionUpdater(fitnessStrategy);
            ParticleGenerator = particleGenerator;
        }

        public override void Initialise(int initialNumberOfParticles)
        {
            for (int i = 0; i < initialNumberOfParticles; i++)
            {
                Particles.Add(ParticleGenerator.GenerateParticle());
            }
        }

        public override void UpdateParticlePositions()
        {
            PositionUpdater.UpdateSwarmPositions(Particles);
        }

        public override void DecrementLifetime()
        {
          // TODO throw new NotImplementedException();
        }

        public override void GenerateNewParticles()
        {
            //TODO throw new NotImplementedException();
        }

        public override Tuple<Vector2d[], Vector3d[]> GetVBOs()
        {
            ParticlePositions = new Vector2d[Particles.Count];
            ParticleColours = new Vector3d[Particles.Count];
            for (int i = 0; i < Particles.Count; i++)
            {
                ParticlePositions[i] = Particles.ElementAt(i).GetPosition();
                ParticleColours[i] = GetColour(Particles.ElementAt(i));
                //ParticleColours[i] = new Vector3d(Particles.ElementAt(i).GetCurrentFitness() / 100.0); //TODO: change accordingly
            }

            return new Tuple<Vector2d[], Vector3d[]>(ParticlePositions, ParticleColours);
        }

       

        public override void RemoveExpiredParticles()
        {
            // TODO throw new NotImplementedException();
        }


    }
}
