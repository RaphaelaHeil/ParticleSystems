using ParticleSystems.Particles;
using System.Collections.Generic;
using System.Linq;

namespace ParticleSystems.ParticleSwarmDataStructures
{
    /// <summary>
    /// Ring data structure for particles.
    /// </summary>
    /// <typeparam name="T">Type of particles handled by the instance of this class</typeparam>
    class ParticleRing<T> where T : Particle
    {
        private List<T> Particles = new List<T>();

        /// <summary>
        /// Constructs a particle ring instance containing all particles from the given list.
        /// </summary>
        /// <param name="particles"></param>
        public ParticleRing(List<T> particles)
        {
            Particles = particles;
        }

        /// <summary>
        /// Constructs an emtpy instance.
        /// </summary>
        public ParticleRing()
        {
        }

        /// <summary>
        /// Gets the n particles adjacent of the given index in both directions (i.e. 2*n particles, does not contain the center particle)
        /// </summary>
        /// <param name="index">Index of the center particle</param>
        /// <param name="k">Number of particles to retrieve from either side of the center</param>
        /// <returns>Neighbours</returns>
        public List<T> GetNAdjacentParticles(int index, int k)
        {
            List<T> neighbours = new List<T>();
            if(Particles.Count == 0)
            {
                return neighbours;
            }

            for (int i = index - k; i < index + k; i++)
            {
                if (i == index)
                {
                    continue;
                }
                int n = i;
                if (i >= Particles.Count)
                {
                    n = i % Particles.Count;
                }
                if (i < 0)
                {
                    n = Particles.Count + i % Particles.Count - 1;
                }
                neighbours.Add(Particles[n]);
            }
            return neighbours;
        }

        public void AddParticle(T particle)
        {
            Particles.Add(particle);
        }

        public void RemoveParticle(T particle)
        {
            Particles.Remove(particle);
        }

        public T ElementAt(int index)
        {
            return Particles.ElementAt(index);
        }

        public int Count()
        {
            return Particles.Count;
        }

        public List<T> getParticleList()
        {
            return Particles;
        }
    }
}
