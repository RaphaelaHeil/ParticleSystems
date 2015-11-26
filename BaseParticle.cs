using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{

    using OpenTK.Graphics.OpenGL4;

    abstract class BaseParticle
    {

        private int maxAge;
        private int remainingLifetime;
        private int agingSpeed;


        /// <summary>
        /// Initialises a new Particle with the given maximum age and aging speed.
        /// </summary>
        /// <param name="maxAge">The maximum age a particle can reach before being removed from the system.</param>
        /// <param name="agingSpeed">The speed at which the particle ages.</param>
        public BaseParticle(int maxAge, int agingSpeed)
        {
            this.maxAge = maxAge;
            this.remainingLifetime = maxAge;
            this.agingSpeed = agingSpeed;
        }
        
        /// <summary>
        /// TODO 
        /// </summary>
        /// <param name="speed"></param>
        public void setAgingSpeed(int speed)
        {
            if (speed > 0)
            {
                agingSpeed = speed;
            }
        }

        
        /// <summary>
        /// TODO 
        /// </summary>
        /// <param name="maxAge"></param>
        public void setMaxAge(int maxAge)
        {
            if (maxAge > 0)
            {
                this.maxAge = maxAge;
                this.remainingLifetime = maxAge;
            }
        }
        
        

    }
}
