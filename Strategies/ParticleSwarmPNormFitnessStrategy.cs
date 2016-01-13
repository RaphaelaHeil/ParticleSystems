using System;
using OpenTK;

namespace ParticleSystems.Strategies
{
    class ParticleSwarmPNormFitnessStrategy : ParticleSwarmFitnessStrategy
    {

        private int P = 1;
        private Vector2d TargetPosition;

        public ParticleSwarmPNormFitnessStrategy(int p, Vector2d targetPosition)
        {
            if (p >= 1)
            {
                P = p;
            }
            TargetPosition = targetPosition;
        }

        public override double GetFitness(Vector2d position)
        {
            Vector2d diff = position - TargetPosition;
            return Math.Pow((Math.Pow(Math.Abs(diff.X), P) + Math.Pow(Math.Abs(diff.Y), P)), ((double)1.0 / P));
        }
    }
}
