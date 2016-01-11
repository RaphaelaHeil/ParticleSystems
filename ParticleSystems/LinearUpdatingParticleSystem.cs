using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace ParticleSystems
{
    class LinearilyUpdatingParticleSystem : ParticleSystem
    {
        private PositionUpdater PositionUpdater = new LinearPositionUpdater();
        private LifetimeHandler LifetimeHandler = new LifetimeHandler();
        private ExpirationHandler ExpirationHandler = new ExpirationHandler();
        private Random Rand = new Random();

        private RandomParticleGenerator ParticleGenerator;
        
        public LinearilyUpdatingParticleSystem()
        {
            Panel = new Test();
        }

        protected override void Initialise()
        {
            ParticleGenerator = new RandomParticleGenerator(Context.GetIdHolder().Width, Context.GetIdHolder().Height, ParticleSettings.GetLifetime(), ParticleSettings.GetAgingVelocity(), ParticleSettings.GetVelocity());
            CreateInitialParticles();
            
            //TODO: create stuff from settings
            //TODO: generate initial particles
        }

        protected override void UpdateVBOs()
        {           
            ParticlePositions = new Vector2d[Particles.Count]; //TODO: find a safer solution :( 
            ParticleColours = new Vector3d[Particles.Count];
            for(int i=0; i < Particles.Count; i++)
            {
                ParticlePositions[i] = Particles.ElementAt(i).GetPosition();
                ParticleColours[i] = new Vector3d(0.0); //TODO: change accordingly
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
            return "A simple particle system for demonstration purposes that updates the particles positions linearly. XXX";
        }
    }
}
