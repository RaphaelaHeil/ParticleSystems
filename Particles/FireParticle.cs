using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems.Particles
{
    class FireParticle : Particle
    {

        private double Temperature = 0.0;

        public FireParticle(Vector2d initialPosition, int maxLifetime, int agingVelocity):base(initialPosition, maxLifetime, agingVelocity)
        {

        }


    }
}
