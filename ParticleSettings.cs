using System.Drawing;

namespace ParticleSystems
{
    /// <summary>
    /// Wrapper for general particle settings.
    /// </summary>
    class ParticleSettings
    {
        private int InitialNumberOfParticles = 20;
        private int NewParticlesPerFrame = 10;
        private int Lifetime = 5;
        private int AgingVelocity = 1;
        private double Velocity = 1;

        private bool NumberOfNewParticlesRandomlyGenerated = false;
        private bool LifetimeRandomlyGenerated = false;
        private bool AgingVelocityRandomlyGenerated = false;
        private bool VelocityRandomlyGenerated = false;

        private bool InitialNumberOfParticlesEnabled = true;
        private bool NewParticlesPerFrameEnabled = true;
        private bool LifetimeEnabled = true;
        private bool AgingVelocityEnabled = true;
        private bool VelocityEnabled = true;

        private Color GlControlBackgroundColor = Color.CornflowerBlue;

        /// <summary>
        /// Sets the initial number of particles
        /// </summary>
        /// <param name="initialNumberOfParticles">Initial number of particles</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithInitialNumberOfParticles(int initialNumberOfParticles)
        {
            InitialNumberOfParticles = initialNumberOfParticles;
            return this;
        }

        /// <summary>
        /// Sets the number of new particles per frame.
        /// </summary>
        /// <param name="newParticlesPerFrame">Number of new particles per frame</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithNewParticlesPerFrame(int newParticlesPerFrame)
        {
            NewParticlesPerFrame = newParticlesPerFrame;
            return this;
        }

        /// <summary>
        /// Sets the particle lifetime
        /// </summary>
        /// <param name="Lifetime">Particle lifetime</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithLifetime(int Lifetime)
        {
            this.Lifetime = Lifetime;
            return this;
        }

        /// <summary>
        /// Sets the aging velocity
        /// </summary>
        /// <param name="AgingVelocity">Aging velocity</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithAgingVelocity(int AgingVelocity)
        {
            this.AgingVelocity = AgingVelocity;
            return this;
        }

        /// <summary>
        /// Sets the velocity 
        /// </summary>
        /// <param name="Velocity">Velocity</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithVelocity(double Velocity)
        {
            this.Velocity = Velocity;
            return this;
        }

        /// <summary>
        /// Sets whether the number of new particles should be generated randomly.
        /// </summary>
        /// <param name="randomly">True: number of particles is randomly generated, false: exact value is used</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithNumberOfNewParticlesIsRandomlyGenerated(bool randomly)
        {
            NumberOfNewParticlesRandomlyGenerated = randomly;
            return this;
        }

        /// <summary>
        /// Sets whether the particle lifetime should be generated randomly.
        /// </summary>
        /// <param name="randomly">True: random generation, false: exact value is used</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithLifetimeIsRandomlyGenerated(bool randomly)
        {
            LifetimeRandomlyGenerated = randomly;
            return this;
        }

        /// <summary>
        /// Sets whether the aging velocity should be generated randomly.
        /// </summary>
        /// <param name="randomly">True: random generation, false: exact value is used</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithAgingVelocityIsRandomlyGenerated(bool randomly)
        {
            AgingVelocityRandomlyGenerated = randomly;
            return this;
        }

        /// <summary>
        /// Sets whether the velocity should be generated randomly.
        /// </summary>
        /// <param name="randomly">True: random generation, false: exact value is used</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithVelocityIsRandomlyGenerated(bool randomly)
        {
            VelocityRandomlyGenerated = randomly;
            return this;
        }

        /// <summary>
        /// Sets whether the settings for the initial number of particles should be enabled or not.
        /// </summary>
        /// <param name="initialNumberOfParticlesEnabled">True: enabled, false: disabled</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithInitialNumberOfParticlesEnabled(bool initialNumberOfParticlesEnabled)
        {
            InitialNumberOfParticlesEnabled = initialNumberOfParticlesEnabled;
            return this;
        }

        /// <summary>
        /// Sets whether the settings for the new particles per frame should be enabled or not.
        /// </summary>
        /// <param name="newParticlesPerFrameEnabled">True: enabled, false: disabled</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithNewParticlesPerFrameEnabled(bool newParticlesPerFrameEnabled)
        {
            NewParticlesPerFrameEnabled = newParticlesPerFrameEnabled;
            return this;
        }

        /// <summary>
        /// Sets whether the settings for the liftime should be enabled or not.
        /// </summary>
        /// <param name="lifetimeEnabled">True: enabled, false: disabled</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithLifetimeEnabled(bool lifetimeEnabled)
        {
            LifetimeEnabled = lifetimeEnabled;
            return this;
        }

        /// <summary>
        /// Sets whether the settings for the aging velocity should be enabled or not.
        /// </summary>
        /// <param name="agingVelocityEnabled">True: enabled, false:disabled</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithAgingVelocityEnabled(bool agingVelocityEnabled)
        {
            AgingVelocityEnabled = agingVelocityEnabled;
            return this;
        }

        /// <summary>
        /// Sets whether the settings for the velocity should be enabled or not.
        /// </summary>
        /// <param name="velocityEnabled">True: enabled, false:disabled</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithVelocityEnabled(bool velocityEnabled)
        {
            VelocityEnabled = velocityEnabled;
            return this;
        }

        /// <summary>
        /// Sets the background colour that should be displayed in the rendering area.
        /// </summary>
        /// <param name="glControlBackgroundColor">Colour to be displayed</param>
        /// <returns>The ParticleSettings instance</returns>
        public ParticleSettings WithGlBackgroundColor(Color glControlBackgroundColor)
        {
            GlControlBackgroundColor = glControlBackgroundColor;
            return this;
        }

        public int GetInitialNumberOfParticles()
        {
            return InitialNumberOfParticles;
        }

        public int GetNumberOfNewParticlesPerFrame()
        {
            return NewParticlesPerFrame;
        }

        public int GetLifetime()
        {
            return Lifetime;
        }

        public int GetAgingVelocity()
        {
            return AgingVelocity;
        }

        public double GetVelocity()
        {
            return Velocity;
        }

        public Color getGlControlBackgroundColor()
        {
            return GlControlBackgroundColor;
        }

        public bool IsNumberOfNewParticlesRandomlyGenerated()
        {
            return NumberOfNewParticlesRandomlyGenerated;
        }

        public bool IsLifetimeRandomlyGenerated()
        {
            return LifetimeRandomlyGenerated;
        }

        public bool IsAgingVelocityRandomlyGenerated()
        {
            return AgingVelocityRandomlyGenerated;
        }

        public bool IsVelocityRandomlyGenerated()
        {
            return VelocityRandomlyGenerated;
        }

        public bool IsInitialNumberOfParticlesEnabled()
        {
            return InitialNumberOfParticlesEnabled;
        }

        public bool IsNewParticlesPerFrameEnabled()
        {
            return NewParticlesPerFrameEnabled;
        }

        public bool IsLifetimeEnabled()
        {
            return LifetimeEnabled;
        }

        public bool IsAgingVelocityEnabled()
        {
            return AgingVelocityEnabled;
        }

        public bool IsVelocityEnabled()
        {
            return VelocityEnabled;
        }
    }
}
