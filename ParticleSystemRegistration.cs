using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems
{
    class ParticleSystemRegistration
    {

        private Dictionary<String, Func<ParticleSystem>> systems = new Dictionary<String, Func<ParticleSystem>>();

        public ParticleSystemRegistration()
        {
            systems.Add("Linear Updating System", Expression.Lambda<Func<ParticleSystem>>(
            Expression.New(typeof(LinearilyUpdatingParticleSystem).GetConstructor(Type.EmptyTypes))
             ).Compile());
        }

        public String[] GetParticleSystemNames()
        {
            return systems.Keys.ToArray<string>();
        }

        public ParticleSystem GetParticleSystemInstance(string particleSystemName)
        {
            return systems[particleSystemName]();
        }
    }
}
