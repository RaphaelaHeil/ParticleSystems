using OpenTK;

namespace ParticleSystems.Particles
{
    /// <summary>
    /// Base particle, representing the general structure of a particle. 
    /// </summary>
    class Particle
    {
        protected Vector2d Position;
        protected int RemainingLifetime;
        protected int AgingVelocity;
        protected bool Expired = false;
        protected double Velocity = 1.0;

        /// <summary>
        /// Constructor with default velocity, i.e. 1.0.
        /// </summary>
        /// <param name="initialPosition">The particle's initial position</param>
        /// <param name="maxLifetime">The particle's maximum lifetime</param>
        /// <param name="agingVelocity">The particle's aging velocity</param>
        public Particle(Vector2d initialPosition, int maxLifetime, int agingVelocity)
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
        public Particle(Vector2d initialPosition, int maxLifetime, int agingVelocity, double velocity) : this(initialPosition, maxLifetime, agingVelocity)
        {
            SetVelocity(velocity);
        }

        /// <summary>
        /// Apply the previously defined aging to the currently remaining lifetime.
        /// </summary>
        public virtual void applyAging()
        {
            if (RemainingLifetime > 0)
            {
                RemainingLifetime -= AgingVelocity;
            }
            if (RemainingLifetime <= 0)
            {
                Expired = true;
            }
        }

        /// <summary>
        /// Updates the particle's current position.
        /// </summary>
        /// <param name="translation">Translation to be applied to the current position (possibly taking the velocity into consideration)</param>
        public virtual void updatePosition(Vector2d translation)
        {
            Position = Vector2d.Add(Position, translation * Velocity);
        }

        /// <summary>
        /// Gets the particle's current position.
        /// </summary>
        /// <returns>The particle's current position</returns>
        public virtual Vector2d GetPosition()
        {
            return Position;
        }

        /// <summary>
        /// Replaces the particle's position with the given position.
        /// </summary>
        /// <param name="position">New position</param>
        public virtual void SetPosition(Vector2d position)
        {
            this.Position = position;
        }

        /// <summary>
        /// Gets the particle's aging velocity.
        /// </summary>
        /// <returns>The particle's aging velocity</returns>
        public virtual int GetAgingVelocity()
        {
            return AgingVelocity;
        }

        /// <summary>
        /// Replaces the particle's current velocity with the given velocity.
        /// </summary>
        /// <param name="velocity">New velocity</param>
        public virtual void SetVelocity(double velocity)
        {
            this.Velocity = velocity;
        }

        /// <summary>
        /// Sets a new aging velocity for this particle.
        /// </summary>
        /// <param name="agingVelocity">New aging velocity; only accepts values bigger than 0!</param>
        public virtual void SetAgingVelocity(int agingVelocity)
        {
            if (agingVelocity >= 0)
            {
                this.AgingVelocity = agingVelocity;
            }
        }

        /// <summary>
        /// Gets the particle's remaining lifetime.
        /// </summary>
        /// <returns>The particle's remaining lifetime</returns>
        public int GetRemainingLifetime()
        {
            return RemainingLifetime;
        }

        /// <summary>
        /// Checks whether the particle is expired.
        /// </summary>
        /// <returns>True if the particle has expired, false otherwise</returns>
        public virtual bool IsExpired()
        {
            return Expired;
        }
    }
}
