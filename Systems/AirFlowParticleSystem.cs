using System.Linq;
using OpenTK;
using System;
using System.Drawing;
using ParticleSystems.PositionUpdate;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.SettingsPanels;

namespace ParticleSystems.Systems {
    class AirFlowParticleSystem : ParticleSystem {
        private PositionUpdater PositionUpdater = new AirFlowPositionUpdater();
        private LifetimeHandler LifetimeHandler = new LifetimeHandler();
        private ExpirationHandler ExpirationHandler = new ExpirationHandler();
        private Random Rand = new Random();

        private AirFlowUserSettings Panel = new AirFlowUserSettings();

        private AirFlowParticleGenerator ParticleGenerator;

        public AirFlowParticleSystem() {

            //Panel = new AirFlowUserSettings();
        }

        protected override void Initialise() {
            ParticleGenerator = new AirFlowParticleGenerator(
                Context.GetIdHolder().Width,
                Context.GetIdHolder().Height,
                ParticleSettings.GetLifetime(),
                ParticleSettings.GetAgingVelocity(),
                ParticleSettings.GetVelocity()
            );
            CreateInitialParticles();

            //TODO: create stuff from settings
            //TODO: generate initial particles
        }

        protected override void UpdateVBOs() {
            ParticlePositions = new Vector2d[Particles.Count]; //TODO: find a safer solution :( 
            ParticleColours = new Vector3d[Particles.Count];
            for (int i = 0; i < Particles.Count; i++) {
                Panel = (AirFlowUserSettings)GetParticleSystemSettingsPanel();
                ParticlePositions[i] = Particles.ElementAt(i).GetPosition();
                Color color = Panel.getColor();
                Vector3d vec3color = new Vector3d(color.R, color.G, color.B);
                ParticleColours[i] = vec3color; //TODO: change accordingly
            }
        }

        protected void UpdateVBOs(Color color) {
            ParticlePositions = new Vector2d[Particles.Count]; //TODO: find a safer solution :( 
            ParticleColours = new Vector3d[Particles.Count];
            for (int i = 0; i < Particles.Count; i++) {
                ParticlePositions[i] = Particles.ElementAt(i).GetPosition();
                Vector3d vec3color = new Vector3d(color.R, color.G, color.B);
                ParticleColours[i] = vec3color; //TODO: change accordingly
            }
        }

        protected override void DecrementLifetime() {
            LifetimeHandler.DecrementLifetime(Particles);
        }

        protected override void RemoveExpiredParticles() {
            ExpirationHandler.handleExpiration(Particles);
        }

        protected override void GenerateNewParticles() {
            //create a air wave at a random intervall
            //the random wave has a random mutiple number of paricles (20 - 40 times) and a reduced lifetime, also random (5 - 15)
            //int randWave = Rand.Next(0, 50);
            //int randNewParticlesOnWave = Rand.Next(20, 40);
            //int randReducedLifeTime = Rand.Next(5, 15);
            //if (randWave == 25) {
            //    for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * randNewParticlesOnWave); i++) {
            //        Particles.Add(ParticleGenerator.GenerateParticle());
            //    }
            //}
            //else {
            //    for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * 0.8); i++) {
            //        Particles.Add(ParticleGenerator.GenerateParticle());
            //    }
            //}
            for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * 0.8); i++) {
                Particles.Add(ParticleGenerator.GenerateParticle());
            }
        }

        protected override void UpdateParticlePositions() {
            PositionUpdater.SetContext(Context);
            PositionUpdater.UpdatePositions(Particles);
        }

        private void CreateInitialParticles() {
            for (int i = 0; i < ParticleSettings.GetInitialNumberOfParticles(); i++) {
                Particles.Add(ParticleGenerator.GenerateParticle());
            }
        }

        public override string GetDescription() {
            return "A Wind Simulation with Paricles. It simulates wind flows with particles by changing the viscosity of the particle and its neightburs";
        }

        public override ParticleSystemSettingsPanel GetParticleSystemSettingsPanel() {
            return Panel;
        }

        public override ParticleSettings GetParticleSettings() {
            Panel = (AirFlowUserSettings)GetParticleSystemSettingsPanel();
            ParticleSettings.WithInitialNumberOfParticles(2000);
            ParticleSettings.WithNewParticlesPerFrame(0);
            ParticleSettings.WithLifetime(200); //the particle dies outside the right side of the draw-area
            ParticleSettings.WithVelocity(5);
            Color color = Panel.getColor();
            Color complementaryColor = Color.FromArgb((255 - color.R), (255 - color.G), (255 - color.B));
            ParticleSettings.WithGlBackgroundColor(complementaryColor);

            return ParticleSettings;
        }
    }
}
