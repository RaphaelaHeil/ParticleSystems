using System.Collections.Generic;
using System.Linq;
using OpenTK;
using System;

namespace ParticleSystems
{
    class AirFlowParticleSystem : ParticleSystem
    {
        private PositionUpdater PositionUpdater = new AirFlowPositionUpdater();
        private LifetimeHandler LifetimeHandler = new LifetimeHandler();
        private ExpirationHandler ExpirationHandler = new ExpirationHandler();
        private Random Rand = new Random();

        private AirFlowParticleGenerator ParticleGenerator;

        public AirFlowParticleSystem()
        {
            Panel = new AirFlowUserSettings();
        }

        protected override void Initialise()
        {
            int width = Context.GetIdHolder().Width;
            ParticleSettings.SetInitialNumberOfParticles(0);
            ParticleSettings.SetNewParticlesPerFrame(150);
            double lifetime = width * 0.5;
            ParticleSettings.SetLifetime((int)lifetime);
            ParticleSettings.SetVelocity(5);
            ParticleSettings.SetAgingVelocity(1);

            ParticleGenerator = new AirFlowParticleGenerator(
                width,
                Context.GetIdHolder().Height,
                ParticleSettings.GetLifetime(),
                ParticleSettings.GetAgingVelocity(),
                ParticleSettings.GetVelocity()
            );
            CreateInitialParticles();

            //TODO: create stuff from settings
            //TODO: generate initial particles
        }

        protected override void UpdateVBOs()
        {
            List<Particle> particles = Context.GetParticles();

            ParticlePositions = new Vector2d[particles.Count]; //TODO: find a safer solution :( 
            ParticleColours = new Vector3d[particles.Count];
            for (int i = 0; i < particles.Count; i++)
            {
                ParticlePositions[i] = particles.ElementAt(i).GetPosition();
                ParticleColours[i] = new Vector3d(0.0); //TODO: change accordingly
            }
        }

        protected override void DecrementLifetime()
        {
            LifetimeHandler.DecrementLifetime(Context.GetParticles());
        }

        protected override void RemoveExpiredParticles()
        {
            ExpirationHandler.handleExpiration(Context.GetParticles());
        }

        protected override void GenerateNewParticles()
        {
            //create a air wave at a random intervall
            //the random wave has a random mutiple number of paricles (20 - 40 times) and a reduced lifetime, also random (5 - 15)
            int randWave = Rand.Next(0, 50);
            int randNewParticlesOnWave = Rand.Next(20, 40);
            int randReducedLifeTime = Rand.Next(5, 15);
            if (randWave == 25)
            {
                for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * randNewParticlesOnWave); i++)
                {
                    ParticleSettings.SetAgingVelocity(randReducedLifeTime);
                    Context.addParticle(ParticleGenerator.GenerateParticle());
                }
            }else
            {
                for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * 0.8); i++)
                {
                    ParticleSettings.SetAgingVelocity(2);
                    Context.addParticle(ParticleGenerator.GenerateParticle());
                }
            }
        }

        protected override void UpdateParticlePositions()
        {
            PositionUpdater.UpdatePositions(Context.GetParticles());
        }

        private void CreateInitialParticles()
        {
            for (int i = 0; i < ParticleSettings.GetInitialNumberOfParticles(); i++)
            {
                Context.addParticle(ParticleGenerator.GenerateParticle());
            }
        }

        public override string GetDescription()
        {
            return "A Wind Simulation with Paricles. It simulates wind flows with particles by changing the viscosity of the particle and its neightburs";
        }
    }
}
