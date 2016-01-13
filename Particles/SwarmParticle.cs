using OpenTK;
using ParticleSystems.Strategies;
using System;

namespace ParticleSystems.Particles
{
    class SwarmParticle : Particle
    {
        private static Random Rand = new Random();
        private ParticleSwarmFitnessStrategy FitnessStrategy;

        private Vector2d BestPosition;
        private Vector2d Translation = new Vector2d(0.0);
        private double BestFitness = double.MaxValue;

        private double InertiaWeight = 0.7298;
        private double AccelerationConstant = 1.4961;
        private double Scaling = 0.02;

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



        //TODO: integrate velocity?! 
        public override void updatePosition(Vector2d globalBest)
        {
            Translation.X = (Translation.X * InertiaWeight + Rand.NextDouble() * AccelerationConstant * (BestPosition.X - Position.X) + Rand.NextDouble() * AccelerationConstant * (globalBest.X - Position.X))* Scaling;
            Translation.Y= (Translation.Y * InertiaWeight + Rand.NextDouble() * AccelerationConstant * (BestPosition.Y - Position.Y) + Rand.NextDouble() * AccelerationConstant * (globalBest.Y - Position.Y))* Scaling;

            Position = Position + Translation ;

            double currentFitness = FitnessStrategy.GetFitness(Position);
            if (currentFitness < BestFitness)
            {
                BestFitness = currentFitness;
                BestPosition = Position;
            }
        }

        public Vector2d GetBestLocation()
        {
            return BestPosition;
        }

        public double GetBestFitness()
        {
            return BestFitness;
        }
    }
}
