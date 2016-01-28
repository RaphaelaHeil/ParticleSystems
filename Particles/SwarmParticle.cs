using OpenTK;
using ParticleSystems.Strategies;
using System;

namespace ParticleSystems.Particles
{
    /// <summary>
    /// Custom particle implementation for particle swarm optimisations.
    /// </summary>
    class SwarmParticle : Particle
    {
        private Vector2d BestPosition;
        private Vector2d Translation = new Vector2d(0.0);
        private double OverallBestFitness = double.MaxValue;
        private double CurrentFitness = double.MaxValue;
       

        public SwarmParticle(Vector2d initialPosition, int maxLifetime, int agingVelocity, double velocity) : base(initialPosition, maxLifetime, agingVelocity, velocity)
        {
            BestPosition = initialPosition;
        }

        public SwarmParticle(Vector2d initialPosition) : base(initialPosition, 1, 0, 0.02)
        {
            BestPosition = initialPosition;
        }

        public Vector2d GetBestLocation()
        {
            return BestPosition;
        }

        public double GetCurrentFitness()
        {
            return CurrentFitness;
        }

        public void SetCurrentFitness(double currentFitness)
        {
            CurrentFitness = currentFitness;
        }

        public double GetOverallBestFitness()
        {
            return OverallBestFitness;
        }

        public void SetOverallBestFitness(double newFitness)
        {
            OverallBestFitness = newFitness;
        }

        public Vector2d GetTranslation()
        {
            return Translation;
        }

        public void SetTranslation(Vector2d translation)
        {
            Translation = translation;
        }

        /// <summary>
        /// Updates the particle's fitness value and sets the overall best location to be the current location.
        /// </summary>
        /// <param name="highestFitness">New fitness value</param>
        public void UpdateFittestValues(double highestFitness)
        {
            OverallBestFitness = highestFitness;
            SetCurrentLocationAsBest();
        }

        public void SetCurrentLocationAsBest()
        {
            BestPosition = Position;
        }
    }
}
