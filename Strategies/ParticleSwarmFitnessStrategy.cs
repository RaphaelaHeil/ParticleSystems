using OpenTK;
using System.Collections.Generic;

namespace ParticleSystems.Strategies
{
    abstract class ParticleSwarmFitnessStrategy
    {

        protected int OptimumIndex = 0;
        protected int DefaulMaxtWeight = 2;
        protected bool IgnoreWeights = false;
        protected List<SwarmOptimum> Optima = new List<SwarmOptimum>();

        public abstract double GetFitness(Vector2d position);
    }
}
