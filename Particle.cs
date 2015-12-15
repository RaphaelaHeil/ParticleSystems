using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ParticleSystems
{
    
    class Particle
    {
        private Vector2d position;
        private int remainingLifetime;
        private int agingVelocity;
        private Boolean expired = false;
        
        public Particle(Vector2d initialPosition, int maxLifetime, int agingVelocity)
        {
            this.position = initialPosition;
            if (maxLifetime > 0)
            {
                this.remainingLifetime = maxLifetime;
            }
            else
            {
                //throw Exception
            }
            setAgingVelocity(agingVelocity);
        }


        public void applyDefaultAging()
        {
            ageBy(agingVelocity);
        }

        public void ageBy(int ageReduction)
        {
            if (remainingLifetime > 0)
            {
                remainingLifetime -= ageReduction;
            }
            if (remainingLifetime <= 0)
            {
                expired = true;
            }
        }

        public void updatePosition(Vector2d translation)
        {
            position = Vector2d.Add(position, translation);
        }

        //GETTERS AND SETTERS:

        public Vector2d getPosition()
        {
            return position;
        }

        public void setPosition(Vector2d Position)
        {
            position = Position;
        }

        public int getAgingVelocity()
        {
            return agingVelocity;
        }

        /// <summary>
        /// Sets a new aging velocity for this particle. Negative values will be discarded, while 0 will prevent this particle from aging.
        /// </summary>
        /// <param name="agingVelocity"></param>
        public void setAgingVelocity(int agingVelocity)
        {
            if (agingVelocity >= 0)
            {
                this.agingVelocity = agingVelocity;
            }
        }

        public int getRemainingLifetime()
        {
            return remainingLifetime;
        }

        public Boolean isExpired()
        {
            return expired;
        }
    }
}
