using System;
using OpenTK;
using System.Collections.Generic;

namespace ParticleSystems.Strategies
{
    class ParticleSwarmPNormFitnessStrategy : ParticleSwarmFitnessStrategy
    {

        private int P = 1;
        private List<Vector2d> Optima;

        public ParticleSwarmPNormFitnessStrategy(int p, HashSet<Vector2d> optima)
        {
            if (p >= 1)
            {
                P = p;
            }
            Optima = new List<Vector2d>(optima);
        }

        public override double GetFitness(Vector2d position)
        {
            if(Optima.Count == 0)
            {
                return double.MaxValue;
            }
            double bestFitness = calculateFitness(position, Optima[0]);

            for (int i = 1; i < Optima.Count; i++)
            {
                double fitness = calculateFitness(position, Optima[i]);
                if (fitness < bestFitness)
                {
                    bestFitness = fitness;
                }
            }

            return bestFitness;
        }

        private double calculateFitness(Vector2d particlePosition, Vector2d optimum)
        {
            Vector2d diff = particlePosition - optimum;
            return Math.Pow((Math.Pow(Math.Abs(diff.X), P) + Math.Pow(Math.Abs(diff.Y), P)), ((double)1.0 / P));
        }
    }
}
