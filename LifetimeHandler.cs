using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{
    class LifetimeHandler
    {
        public void DecrementLifetime(List<Particle> particles)
        {
            foreach (Particle particle in particles)
            {
                particle.applyAging();
            }
        }
    }
}
