using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{
    class LinearUpdatingParticleSystem : ParticleSystem
    {

        public LinearUpdatingParticleSystem()
        {
            panel = new Test();
        }


        public override string GetDescription()
        {
            return "A simple particle system for demonstration purposes that updates the particles positions linearly. XXX";
        }

        public override void Initialise()
        {
            throw new NotImplementedException();
        }

        protected override void BuildFrame()
        {


            //TODO
        }

        protected override void DrawFrame()
        {
            //TODO
        }
    }
}
