using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{
    class ExpirationHandler
    {

        public int handleExpiration(List<Particle> particles)
        {
            return particles.RemoveAll(particle => particle.isExpired());

        }
    }
}
