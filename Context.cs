using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace ParticleSystems
{
    class Context
    {

        private List<Particle> particles = new List<Particle>();
        
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

        //public Vector2d[] getParticlePositions()
        //{
        //    Vector2d[] positions = new Vector2d[particles.Count];
            
        //    foreach(var particle)

        //    for(int i=0; i<particles.Count;i++)
        //    {
        //        positions[i] = particles.ElementAt(i).GetPosition();
        //    }
        //    return positions;
        //}

        public void clear()
        {
            particles.Clear();
            //TODO: Obstacles clear
        }
    }
}
