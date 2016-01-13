using OpenTK;

namespace ParticleSystems.Strategies
{
    abstract class ParticleSwarmFitnessStrategy
    {
        public abstract double GetFitness(Vector2d position);
    }
}
