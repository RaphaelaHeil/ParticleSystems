using System.Linq;
using OpenTK;
using System;
using System.Drawing;
using ParticleSystems.PositionUpdate;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.SettingsPanels;
using ParticleSystems.Particles;
using System.Collections.Generic;

namespace ParticleSystems.Systems
{
    /// <summary>
    /// Particle System wich organizes particles and classes to simulates airflow.
    /// </summary>
    class AirFlowParticleSystem : ParticleSystem
    {
        private AirFlowPositionUpdater AirFlowPositionUpdater = new AirFlowPositionUpdater();
        private Random Rand = new Random();

        private AirFlowUserSettings Panel = new AirFlowUserSettings();

        private AirFlowParticleGenerator ParticleGenerator;

        private new List<AirParticle> Particles;
        private ParticleGrid<AirParticle> ParticleGrid;

        /// <summary>
        /// Contrucor with no purpose.
        /// </summary>
        public AirFlowParticleSystem(){}

        /// <summary>
        /// Function to initialise the particle system. Has to be called before the first call to RenderFrame.
        /// </summary>
        protected override void Initialise()
        {
            Particles = new List<AirParticle>();
            ParticleGenerator = new AirFlowParticleGenerator(
                Context.GetIdHolder().Width,
                Context.GetIdHolder().Height,
                ParticleSettings.GetLifetime(),
                ParticleSettings.GetAgingVelocity(),
                ParticleSettings.GetVelocity()
            );
            CreateInitialParticles();
            ParticleGrid = new ParticleGrid<AirParticle>(Context);
        }

        /// <summary>
        /// Updates the vertex buffer object.
        /// Set the colur of the partiles.
        /// </summary>
        protected override void UpdateVBOs()
        {
            ParticlePositions = new Vector2d[Particles.Count]; //TODO: find a safer solution :( 
            ParticleColours = new Vector3d[Particles.Count];
            Color color = Panel.getColor();
            for (int i = 0; i < Particles.Count; i++)
            {
                ParticlePositions[i] = Particles.ElementAt(i).GetPosition();
                Vector3d vec3color = new Vector3d(color.R, color.G, color.B);
                ParticleColours[i] = vec3color; //TODO: change accordingly
            }
        }

        /// <summary>
        /// Decrease the lifetime of the particles.
        /// </summary>
        protected override void DecrementLifetime()
        {
            foreach (AirParticle particle in Particles)
            {
                particle.applyAging();
            }
        }

        /// <summary>
        /// Remove expired particles from the particle list.
        /// </summary>
        protected override void RemoveExpiredParticles()
        {
            Particles.RemoveAll(particle => particle.IsExpired());
        }

        /// <summary>
        /// Gernate new particles with a random number of particle-waves to simulate an airwave.
        /// </summary>
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
                    Particles.Add(ParticleGenerator.GenerateParticle());
                }
            }
            else {
                for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * 0.8); i++)
                {
                    Particles.Add(ParticleGenerator.GenerateParticle());
                }
            }
        }

        /// <summary>
        /// Updates the position of the particles and sets the context, 
        /// particle-grid and the settingspanel for the update-class.
        /// </summary>
        protected override void UpdateParticlePositions()
        {
            AirFlowPositionUpdater.SetContext(Context);
            AirFlowPositionUpdater.SetParticleGrid(ParticleGrid);
            AirFlowPositionUpdater.SetSettingsPanel(Panel);
            AirFlowPositionUpdater.UpdateAirPositions(Particles);
        }

        /// <summary>
        /// Create an initial number of particles, based on the user settings.
        /// </summary>
        private void CreateInitialParticles()
        {
            for (int i = 0; i < ParticleSettings.GetInitialNumberOfParticles(); i++)
            {
                Particles.Add(ParticleGenerator.GenerateParticle());
            }
        }

        /// <summary>
        /// Returns the description of the particle system
        /// </summary>
        /// <returns></returns>
        public override string GetDescription()
        {
            return "A Wind Simulation with Paricles. It simulates wind flows with particles by changing the viscosity of the particle and its neightburs";
        }

        /// <summary>
        /// Returns the Settings-Panel-Object of the particle system.
        /// </summary>
        /// <returns></returns>
        public override ParticleSystemSettingsPanel GetParticleSystemSettingsPanel()
        {
            return Panel;
        }

        /// <summary>
        /// Resturns the default values for the Settings-Panel-Object
        /// </summary>
        /// <returns></returns>
        public override ParticleSettings GetParticleSettings()
        {
            Panel = (AirFlowUserSettings)GetParticleSystemSettingsPanel();
            ParticleSettings.WithInitialNumberOfParticles(5000);
            ParticleSettings.WithNewParticlesPerFrame(0);
            ParticleSettings.WithLifetime(1000); //the particle dies outside the right side of the draw-area
            ParticleSettings.WithVelocity(4);
            ParticleSettings.WithVelocityIsRandomlyGenerated(true);
            Color color = Panel.getColor();
            Color complementaryColor = Color.FromArgb((255 - color.R), (255 - color.G), (255 - color.B));
            ParticleSettings.WithGlBackgroundColor(complementaryColor);

            return ParticleSettings;
        }
    }
}
