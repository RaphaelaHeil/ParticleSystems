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
        private double velocity = 1.0;
        
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

        public Particle(Vector2d initialPosition, int maxLifetime, int agingVelocity, double velocity) : this(initialPosition, maxLifetime, agingVelocity)
        {
            SetVelocity(velocity);
        }

        public void applyAging()
        {
            if (remainingLifetime > 0)
            {
                remainingLifetime -= agingVelocity;
            }
            if (remainingLifetime <= 0)
            {
                expired = true;
            }
        }    

        public void updatePosition(Vector2d translation)
        {
            position = Vector2d.Add(position, translation*velocity);
        }

        //GETTERS AND SETTERS:

        public Vector2d GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2d Position)
        {
            position = Position;
        }

        public int GetAgingVelocity()
        {
            return agingVelocity;
        }

        public void SetVelocity(double Velocity)
        {
            this.velocity = Velocity;
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
