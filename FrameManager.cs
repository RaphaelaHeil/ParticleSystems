using ParticleSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{
    class FrameManager
    {
        private int MAX_LIFETIME = 20;
        private int MAX_NEW_PARTICLES = 100;
        private Boolean RANDOMLY = true;

        private ParticleGenerator particleGenerator;
        private PositionUpdater positionUpdater;

        private Context context = new Context();
        private LifetimeHandler lifetimeHandler = new LifetimeHandler();
        private ExpirationHandler expirationHandler = new ExpirationHandler();

        public void InitContext(int amountOfParticles, int maxLifetime, int maxNewParticles, Boolean randomly)
        {
            MAX_NEW_PARTICLES = maxNewParticles;
            MAX_LIFETIME = maxLifetime;
            RANDOMLY = randomly;
            particleGenerator = new RandomParticleGenerator(400, 400, MAX_LIFETIME, 1, 1.0);
           
                for (int i = 0; i < amountOfParticles; i++)
                {
                    context.addParticle(particleGenerator.GenerateParticle());
                }
           
           
        }

        /// <summary>
        /// To be called whenever a new frame is to be prepared. In order to acutally render the frame, excute FrameManager.Render()
        /// </summary>
        public void PrepareFrame()
        {

            //slighlty changed the execution order to e.g. be able to create as many new particles as were removed

            //decrement lifetime of existing particles
            lifetimeHandler.decrementLifetime(context.getParticles());

            //remove expired particles
            expirationHandler.handleExpiration(context.getParticles());
            //RemoveWhere(particle => particle.isExpired());
            // Console.WriteLine("Removed: " + removed);

            //generate new particles

            Random rand = new Random();
            int random = rand.Next(MAX_NEW_PARTICLES);
           
                for (int i = 0; i < random; i++)
                {
                    context.addParticle(particleGenerator.GenerateParticle());
                }
          

            Console.WriteLine(context.getParticles().Count);

            //animate

            positionUpdater.UpdatePositions(context.getParticles());

        
            //TODO: render

        }

        public void RenderFrame()
        {

        }

        public void SetLifetimeHandler(LifetimeHandler LifetimeHandler)
        {
            lifetimeHandler = LifetimeHandler;
        }

        public void SetPositionHandler(PositionUpdater PositionHandler)
        {
            positionUpdater = PositionHandler;
        }

        public void SetExpirationHandler(ExpirationHandler Expirationhandler)
        {
            expirationHandler = Expirationhandler;
        }

        public void SetParticleGenerator(ParticleGenerator ParticleGenerator)
        {
            particleGenerator = ParticleGenerator;
        }

        public List<Particle> GetParticles()
        {
            return context.getParticles();
        }
    }
}
