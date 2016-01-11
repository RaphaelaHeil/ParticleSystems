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

        private AirFlowUserSettings Panel = new AirFlowUserSettings();

        private AirFlowParticleGenerator ParticleGenerator;

        public AirFlowParticleSystem()
        {
           // Panel = new AirFlowUserSettings(); wird jetzt nicht mehr gebraucht :)
           // wenn du ansonsten hier nichts mehr machen willst kannst du den Konstruktor auch komplett rausschmeißen :) 
        }

        protected override void Initialise()
        {
            int width = Context.GetIdHolder().Width;
            ParticleSettings.WithInitialNumberOfParticles(0);
            ParticleSettings.WithNewParticlesPerFrame(150);
            double lifetime = width * 0.5;
            ParticleSettings.WithLifetime((int)lifetime);
            ParticleSettings.WithVelocity(5);
            ParticleSettings.WithAgingVelocity(1);

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
            ParticlePositions = new Vector2d[Particles.Count]; //TODO: find a safer solution :( 
            ParticleColours = new Vector3d[Particles.Count];
            for (int i = 0; i < Particles.Count; i++)
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
            //create a air wave at a random intervall
            //the random wave has a random mutiple number of paricles (20 - 40 times) and a reduced lifetime, also random (5 - 15)
            int randWave = Rand.Next(0, 50);
            int randNewParticlesOnWave = Rand.Next(20, 40);
            int randReducedLifeTime = Rand.Next(5, 15);
            if (randWave == 25)
            {
                for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * randNewParticlesOnWave); i++)
                {
                    ParticleSettings.WithAgingVelocity(randReducedLifeTime);
                    Particles.Add(ParticleGenerator.GenerateParticle());
                }
            }else
            {
                for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * 0.8); i++)
                {
                    ParticleSettings.WithAgingVelocity(2);
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
            return "A Wind Simulation with Paricles. It simulates wind flows with particles by changing the viscosity of the particle and its neightburs";
        }

        public override ParticleSystemSettingsPanel GetParticleSystemSettingsPanel()
        {
            return Panel;
        }

        public override ParticleSettings GetParticleSettings()
        {
            throw new NotImplementedException(); //TODO: hier kannst du deine default werte einstellen und ob die einzelnen auswahlmöglichkeiten aktiviert sein sollen oder nicht :) 
            //du könntest also z.B. einen Wert festsetzen und das Panel dann sperren. Dann kann der User zwar nichts machen, sieht aber was Sache ist ... oder so :D
        }
    }
}
