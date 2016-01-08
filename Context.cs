using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace ParticleSystems
{
    
    class Context
    {
        private List<Particle> particles = new List<Particle>();
        private IdHolder IdHolder;

        public Context(IdHolder idHolder)
        {
            IdHolder = idHolder;
        }
        
        //private List<Obstacle>

        public void addParticle(Particle particle)
        {
            particles.Add(particle);
        }

        public void removeParticle(Particle particle)
        {
            particles.Remove(particle);
        }

        public List<Particle> GetParticles()
        {
            return particles;
        }

        public IdHolder GetIdHolder()
        {
            return IdHolder;
        }
    }
}
