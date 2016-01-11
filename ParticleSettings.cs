namespace ParticleSystems
{
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


        public ParticleSettings WithInitialNumberOfParticles(int initialNumberOfParticles)
        {
            InitialNumberOfParticles = initialNumberOfParticles;
            return this;
        }

        public ParticleSettings WithNewParticlesPerFrame(int newParticlesPerFrame)
        {
            NewParticlesPerFrame = newParticlesPerFrame;
            return this;
        }

        public ParticleSettings WithLifetime(int Lifetime)
        {
            this.Lifetime = Lifetime;
            return this;
        }

        public ParticleSettings WithAgingVelocity(int AgingVelocity)
        {
            this.AgingVelocity = AgingVelocity;
            return this;
        }

        public ParticleSettings WithVelocity(double Velocity)
        {
            this.Velocity = Velocity;
            return this;
        }

        public ParticleSettings WithNumberOfNewParticlesIsRandomlyGenerated(bool randomly)
        {
            NumberOfNewParticlesRandomlyGenerated = randomly;
            return this;
        }

        public ParticleSettings WithLifetimeIsRandomlyGenerated(bool randomly)
        {
            LifetimeRandomlyGenerated = randomly;
            return this;
        }

        public ParticleSettings WithAgingVelocityIsRandomlyGenerated(bool randomly)
        {
            AgingVelocityRandomlyGenerated = randomly;
            return this;
        }

        public ParticleSettings WithVelocityIsRandomlyGenerated(bool randomly)
        {
            VelocityRandomlyGenerated = randomly;
            return this;
        }

        public ParticleSettings WithInitialNumberOfParticlesEnabled(bool initialNumberOfParticlesEnabled)
        {
            InitialNumberOfParticlesEnabled = initialNumberOfParticlesEnabled;
            return this;
        }

        public ParticleSettings WithNewParticlesPerFrameEnabled(bool newParticlesPerFrameEnabled)
        {
            NewParticlesPerFrameEnabled = newParticlesPerFrameEnabled;
            return this;
        }

        public ParticleSettings WithLifetimeEnabled(bool lifetimeEnabled)
        {
            LifetimeEnabled = lifetimeEnabled;
            return this;
        }

        public ParticleSettings WithAgingVelocityEnabled(bool agingVelocityEnabled)
        {
            AgingVelocityEnabled = agingVelocityEnabled;
            return this;
        }

        public ParticleSettings WithVelocityEnabled(bool velocityEnabled)
        {
            VelocityEnabled = velocityEnabled;
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
