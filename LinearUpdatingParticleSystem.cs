using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ParticleSystems
{
    class LinearilyUpdatingParticleSystem : ParticleSystem
    {
        private PositionUpdater positionUpdater = new LinearPositionUpdater();
        private LifetimeHandler lifetimeHandler = new LifetimeHandler();
        private ExpirationHandler expirationHandler = new ExpirationHandler();
        private Random rand = new Random();

        private RandomParticleGenerator particleGenerator;
        private ParticleSettings particleSettings;

        public LinearilyUpdatingParticleSystem()
        {
            panel = new Test();
        }

        public override void Initialise(ParticleSettings settings, Context context)
        {
            base.context = context;
            particleSettings = settings;
            particleGenerator = new RandomParticleGenerator(600, 600, particleSettings.GetLifetime(), particleSettings.GetAgingVelocity(), particleSettings.GetVelocity());
            //TODO: create stuff from settings
            //TODO: generate initial particles
        }

        protected override void BuildVBO()
        {
            throw new NotImplementedException();
        }

        protected override void DrawFrame()
        {
            //TODO
            Console.WriteLine(context.GetParticles().Count);
            foreach(var particle in context.GetParticles())
            {
                GL.Vertex2(particle.GetPosition());
            }
            //foreach (var position in context.getParticlePositions())
            //{
            //    GL.Vertex2(position);
            //}
        }

        public override string GetDescription()
        {
            return "A simple particle system for demonstration purposes that updates the particles positions linearly. XXX";
        }

        protected override void DecrementLifetime()
        {
            lifetimeHandler.DecrementLifetime(context.GetParticles());
        }

        protected override void RemoveExpiredParticles()
        {
            expirationHandler.handleExpiration(context.GetParticles());
        }

        protected override void GenerateNewParticles()
        {
            if (particleSettings.IsNumberOfNewParticlesRandomlyGenerated())
            {
                int random = rand.Next(particleSettings.GetNumberOfNewParticlesPerFrame());
                for (int i = 0; i < random; i++)
                {
                    context.addParticle(particleGenerator.GenerateParticle());
                }
            }
            else
            {
                for (int i = 0; i < particleSettings.GetNumberOfNewParticlesPerFrame(); i++)
                {
                    context.addParticle(particleGenerator.GenerateParticle());
                }
            }
        }

        protected override void UpdateParticlePositions()
        {
            positionUpdater.UpdatePositions(context.GetParticles());
        }
    }
}
