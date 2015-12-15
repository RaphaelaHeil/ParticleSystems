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

        private Context context;
        private BaseLifetimeHandler lifetimeHandler;
        private PositionGenerator positionGenerator;

        public FrameManager(Context context)
        {
            this.context = context;
            lifetimeHandler = new BaseLifetimeHandler(); //TODO: make configurable! 
            positionGenerator = new PositionGenerator();
        }


        public void initContext(int amountOfParticles, int maxLifetime, int maxNewParticles, Boolean randomly)
        {
            MAX_NEW_PARTICLES = maxNewParticles;
            MAX_LIFETIME = maxLifetime;
            RANDOMLY = randomly;
            for (int i = 0; i < amountOfParticles; i++)
            { 
                context.addParticle(createNewParticle()); 
            }
        }

        /// <summary>
        /// To be called whenever a new frame is to be rendered.
        /// </summary>
        public void prepareFrame()
        {

            //slighlty changed the execution order to e.g. be able to create as many new particles as were removed

            //decrement lifetime of existing particles
            lifetimeHandler.decrementLifetime(context.getParticles());

            //remove expired particles
            int removed = context.getParticles().RemoveAll(particle => particle.isExpired());
                //RemoveWhere(particle => particle.isExpired());
           // Console.WriteLine("Removed: " + removed);

            //generate new particles

            Random rand = new Random();
            int random = rand.Next(MAX_NEW_PARTICLES);
            for (int i = 0; i < random; i++)
            {
                context.addParticle(createNewParticle());
            }
           // Console.WriteLine("Added: " + random);

            
            Console.WriteLine(context.getParticles().Count);

            //animate
            if (RANDOMLY)
            {
                foreach (Particle particle in context.getParticles())
                {
                    positionGenerator.updatePositionRandomly(particle);
                }
            }
            else
            {
                foreach (Particle particle in context.getParticles())
                {
                    positionGenerator.updatePositionByOne(particle);
                }
            }
            

            //TODO: render

        }

        private Particle createNewParticle()
        {
            return new Particle(positionGenerator.generateRandomPosition(), MAX_LIFETIME, 1);
        }
    }
}
