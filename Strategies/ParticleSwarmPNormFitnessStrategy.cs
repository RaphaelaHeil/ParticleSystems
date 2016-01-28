using System;
using OpenTK;
using System.Collections.Generic;

namespace ParticleSystems.Strategies
{
    /// <summary>
    /// Particle swarm fitness function basing the fitness calculation on the p-norm.
    /// </summary>
    class ParticleSwarmPNormFitnessStrategy : ParticleSwarmFitnessStrategy
    {
        private int P = 1;

        public ParticleSwarmPNormFitnessStrategy(int p, HashSet<SwarmOptimum> optima, bool ignoreWeights)
        {
            IgnoreWeights = ignoreWeights;
            if (p >= 1)
            {
                P = p;
            }
            Optima = new List<SwarmOptimum>(optima);
        }

        public override double GetFitness(Vector2d position)
        {
            if (Optima.Count == 0)
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

        private double calculateFitness(Vector2d particlePosition, SwarmOptimum optimum)
        {
            Vector2d diff = particlePosition - optimum.GetPosition();
            double baseFitness = Math.Pow((Math.Pow(Math.Abs(diff.X), P) + Math.Pow(Math.Abs(diff.Y), P)), ((double)1.0 / P));

            if (IgnoreWeights)
            {
                return baseFitness;
            }

            return baseFitness / (double)optimum.GetWeight();
        }
    }
}
