using ParticleSystems.Particles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems.ParticleSwarmDataStructures
{
    class ParticleRing<T> where T : Particle
    {
        private List<T> Particles = new List<T>();

        public ParticleRing(List<T> particles)
        {
            Particles = particles;
        }

        public ParticleRing()
        {
        }

        public List<T> GetNAdjacentParticles(int index, int k)
        {
            List<T> neighbours = new List<T>();
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
