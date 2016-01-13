using System;
using OpenTK;
using System.Threading;
using System.Collections.Generic;
using ParticleSystems.Particles;
using ParticleSystems.SettingsPanels;

namespace ParticleSystems.Systems
{
    //TODO
    abstract class ParticleSystem
    {
        private readonly object RenderingLock = new object();
        private const int TIMEOUT_IN_MS = 20;

        private RenderHelper RenderHelper;
        protected ParticleSettings ParticleSettings = new ParticleSettings();
        protected Context Context;
        protected List<Particle> Particles;
        protected Vector2d[] ParticlePositions = { };
        protected Vector3d[] ParticleColours = { };

        /// <summary>
        /// Function to initialise the particle system. Has to be called before the first call to RenderFrame.
        /// </summary>
        /// <param name="settings">Particle system settings</param>
        /// <param name="context">Particle system context</param>
        public void Init(Context context)
        {
            Particles = new List<Particle>();
            Context = context;
            RenderHelper = new RenderHelper(Context.GetIdHolder());
            Initialise();
        }

        /// <summary>
        /// Renders the next iteration of the particle system.
        /// </summary>
        /// <returns>True if a new frame has been prepared, false if another frame was still being processed.</returns>
        public bool RenderFrame()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(RenderingLock, TIMEOUT_IN_MS, ref lockTaken);
                if (lockTaken)
                {
                    PrepareFrame();
                    UpdateVBOs();
                    RenderHelper.Render(ParticlePositions, ParticleColours);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                if (lockTaken) Monitor.Exit(RenderingLock);
            }
        }

        private void PrepareFrame()
        {
            //TODO: chpt. 7.3, p.206
            //slighlty changed the execution order to e.g. be able to create as many new particles as were removed
            DecrementLifetime();
            RemoveExpiredParticles();
            GenerateNewParticles();
            UpdateParticlePositions();
        }

        /// <summary>
        /// Gets the system's particle settings, i.e. default values to fill the GUI with and whether certain elements are enabled or not. 
        /// </summary>
        /// <returns></returns>
        public abstract ParticleSettings GetParticleSettings();

        /// <summary>
        /// Gets the system's settings panel to be displayed in the UI.
        /// </summary>
        /// <returns>The system's settings panel</returns>
        public abstract ParticleSystemSettingsPanel GetParticleSystemSettingsPanel();

        /// <summary>
        /// Gets the particle system's description.
        /// </summary>
        /// <returns>Particle system description</returns>
        public abstract String GetDescription();

        /// <summary>
        /// Will be called upon initialisation of the base class. Can be used to perform implementation specific initialisations.
        /// </summary>
        protected abstract void Initialise();

        /// <summary>
        /// Method representing the lifecycle step in which the lifetime of particles is decremented.
        /// </summary>
        protected abstract void DecrementLifetime();

        /// <summary>
        /// Method representing the lifecycle step in which expired particles are removed from the system.
        /// </summary>
        protected abstract void RemoveExpiredParticles();

        /// <summary>
        /// Method representing the lifecycle step in which new particles are generated.
        /// </summary>
        protected abstract void GenerateNewParticles();

        /// <summary>
        /// Method representing the lifecycle step in which the particle positions are updated.
        /// </summary>
        protected abstract void UpdateParticlePositions();

        /// <summary>
        /// Retrieve the particle positions and intended colours for rendering and prepare the two arrays ParticlePositions and ParticleColours.
        /// </summary>
        protected abstract void UpdateVBOs();

        protected virtual void GetDefaultGUIValues()
        {
            // max Lifetime default = 100;
            // Input xyz deaktiviert
            // 
        }
    }
}
