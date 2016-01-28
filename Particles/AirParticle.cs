using OpenTK;

namespace ParticleSystems.Particles
{
    /// <summary>
    /// Base particle, representing the general structure of a particle. 
    /// </summary>
    class AirParticle : Particle
    {
        private Vector2d StartingPosition;
        private int MaxLifetime = 0;

        /// <summary>
        /// Constructor with default velocity, i.e. 1.0.
        /// </summary>
        /// <param name="initialPosition">The particle's initial position</param>
        /// <param name="maxLifetime">The particle's maximum lifetime</param>
        /// <param name="agingVelocity">The particle's aging velocity</param>
        public AirParticle(Vector2d initialPosition, int maxLifetime, int agingVelocity) : base(initialPosition, maxLifetime, agingVelocity)
        {
            this.Position = initialPosition;
            this.RemainingLifetime = maxLifetime;
            SetAgingVelocity(agingVelocity);
        }

        /// <summary>
        /// Constructor with specified velocity.
        /// </summary>
        /// <param name="initialPosition">The particle's initial position</param>
        /// <param name="maxLifetime">The particle's maximum lifetime</param>
        /// <param name="agingVelocity">The particle's aging velocity</param>
        /// <param name="velocity">The particle's velocity</param>
        public AirParticle(Vector2d initialPosition, int maxLifetime, int agingVelocity, double velocity) : this(initialPosition, maxLifetime, agingVelocity)
        {
            SetVelocity(velocity);
        }

        /// <summary>
        /// Returns the velocity of the current airflow particle.
        /// </summary>
        /// <returns></returns>
        public virtual double GetVelocity()
        {
            return this.Velocity;
        }

        /// <summary>
        /// Sets the remaining lifetime of the current airflow particle.
        /// </summary>
        /// <param name="remainingLifetime"></param>
        public void SetRemainingLifetime(int remainingLifetime)
        {
            this.RemainingLifetime = remainingLifetime;
        }

        /// <summary>
        /// Sets the starting position of the current airflow particle.
        /// </summary>
        /// <param name="startingPosition"></param>
        public void SetStartingPosition(Vector2d startingPosition)
        {
            this.StartingPosition = startingPosition;
        }

        /// <summary>
        /// Returns the starting position of the current airflow particle.
        /// </summary>
        /// <returns></returns>
        public Vector2d GetStartingPosition()
        {
            return this.StartingPosition;
        }

        /// <summary>
        /// Sets the maximum lifetime of the current airflow particle.
        /// </summary>
        /// <param name="maxLifetime"></param>
        public void SetMaxLifetime(int maxLifetime)
        {
            this.MaxLifetime = maxLifetime;
        }

        /// <summary>
        /// Return the maximum lifetime of the current airflow particle.
        /// </summary>
        /// <returns></returns>
        public int GetMaxLifetime()
        {
            return this.MaxLifetime;
        }
    }
}
