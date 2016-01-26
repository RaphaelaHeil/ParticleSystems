using OpenTK;
using ParticleSystems.Strategies;
using System;

namespace ParticleSystems.Particles
{
    class SwarmParticle : Particle
    {
      //  private static Random Rand = new Random();
        private ParticleSwarmFitnessStrategy FitnessStrategy;

        private Vector2d BestPosition;
        private Vector2d Translation = new Vector2d(0.0);
        private double OverallBestFitness = double.MaxValue;
        private double CurrentFitness = double.MaxValue;

        private double InertiaWeight = 0.7298;
        private double AccelerationConstant = 0.8; //1.4961;
        private double Scaling = 0.08;

        //Vector2d initialPosition, int maxLifetime, int; agingVelocity, double velocity) : this(initialPosition, maxLifetime, agingVelocity)

        public SwarmParticle(Vector2d initialPosition, int maxLifetime, int agingVelocity, double velocity, ParticleSwarmFitnessStrategy fitnessStrategy) : base(initialPosition, maxLifetime, agingVelocity, velocity)
        {
            FitnessStrategy = fitnessStrategy;
            BestPosition = initialPosition;
        }

        public SwarmParticle(Vector2d initialPosition, ParticleSwarmFitnessStrategy fitnessStrategy) : base(initialPosition, 1, 1, 0.2)
        {
            FitnessStrategy = fitnessStrategy;
            BestPosition = initialPosition;
        }

        public override void updatePosition(Vector2d globalBest)
        {

            Translation.X = (Translation.X * InertiaWeight + AccelerationConstant* GaussianRandomHelper.GetRandomValue(0.0, 1.0) * (BestPosition.X - Position.X) + AccelerationConstant * GaussianRandomHelper.GetRandomValue(0.0, 1.0) * (globalBest.X - Position.X)) * Scaling;
            Translation.Y = (Translation.Y * InertiaWeight + AccelerationConstant * GaussianRandomHelper.GetRandomValue(0.0, 1.0) * (BestPosition.Y - Position.Y) + AccelerationConstant * GaussianRandomHelper.GetRandomValue(0.0, 1.0) * (globalBest.Y - Position.Y)) * Scaling;

            Position = Position + Translation ;

            CurrentFitness = FitnessStrategy.GetFitness(Position);
            if (CurrentFitness < OverallBestFitness)
            {
                OverallBestFitness = CurrentFitness;
                BestPosition = Position;
            }
        }

        public Vector2d GetBestLocation()
        {
            return BestPosition;
        }

        public double GetCurrentFitness()
        {
            return CurrentFitness;
        }

        public double GetOverallBestFitness()
        {
            return OverallBestFitness;
        }
    }
}
