using System.Linq;
using OpenTK;
using System;
using System.Drawing;
using ParticleSystems.PositionUpdate;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.SettingsPanels;
using ParticleSystems.Particles;
using System.Collections.Generic;

namespace ParticleSystems.Systems {
    class AirFlowParticleSystem : ParticleSystem {
        private AirFlowPositionUpdater AirFlowPositionUpdater = new AirFlowPositionUpdater();
        private Random Rand = new Random();

        private AirFlowUserSettings Panel = new AirFlowUserSettings();

        private AirFlowParticleGenerator ParticleGenerator;

        private new List<AirParticle> Particles;

        public AirFlowParticleSystem() {

            //Panel = new AirFlowUserSettings();
        }

        protected override void Initialise() {
            Particles = new List<AirParticle>();
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
            foreach (AirParticle particle in Particles)
            {
                particle.applyAging();
            }
        }

        protected override void RemoveExpiredParticles() {
            Particles.RemoveAll(particle => particle.IsExpired());
        }

        protected override void GenerateNewParticles() {
            //create a air wave at a random intervall
            //the random wave has a random mutiple number of paricles (20 - 40 times) and a reduced lifetime, also random (5 - 15)
            int randWave = Rand.Next(0, 50);
            int randNewParticlesOnWave = Rand.Next(20, 40);
            int randReducedLifeTime = Rand.Next(5, 15);
            if (randWave == 25) {
                for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * randNewParticlesOnWave); i++) {
                    Particles.Add(ParticleGenerator.GenerateParticle());
                }
            }
            else {
                for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * 0.8); i++) {
                    Particles.Add(ParticleGenerator.GenerateParticle());
                }
            }
        }

        protected override void UpdateParticlePositions() {

            AirFlowPositionUpdater.SetContext(Context);
            AirFlowPositionUpdater.SetSettingsPanel(Panel);
            AirFlowPositionUpdater.UpdateAirPositions(Particles);
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
            ParticleSettings.WithInitialNumberOfParticles(500);
            ParticleSettings.WithNewParticlesPerFrame(5);
            ParticleSettings.WithLifetime(1000); //the particle dies outside the right side of the draw-area
            ParticleSettings.WithVelocity(1);
            Color color = Panel.getColor();
            Color complementaryColor = Color.FromArgb((255 - color.R), (255 - color.G), (255 - color.B));
            ParticleSettings.WithGlBackgroundColor(complementaryColor);

            return ParticleSettings;
        }
    }
}
