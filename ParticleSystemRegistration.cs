using ParticleSystems.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ParticleSystems
{
    class ParticleSystemRegistration
    {

        private Dictionary<String, Func<ParticleSystem>> systems = new Dictionary<String, Func<ParticleSystem>>();

        public ParticleSystemRegistration()
        {
            //How to add a new particle system: 
            // 1) copy the following statement
            /**
            systems.Add("NAME", Expression.Lambda<Func<ParticleSystem>>(
            Expression.New(typeof(CLASSNAME).GetConstructor(Type.EmptyTypes))
             ).Compile());
            */
            // 2) Replace NAME with the name to be shown in the dropdown in the UI
            // 3) Replace CLASSNAME with the name of the new particle system

            systems.Add("Linear Updating System", Expression.Lambda<Func<ParticleSystem>>(
            Expression.New(typeof(LinearilyUpdatingParticleSystem).GetConstructor(Type.EmptyTypes))
             ).Compile());
            systems.Add("Airflow Simulation System", Expression.Lambda<Func<ParticleSystem>>(
            Expression.New(typeof(AirFlowParticleSystem).GetConstructor(Type.EmptyTypes))
             ).Compile());
            systems.Add("Particle Swarm Optimisation", Expression.Lambda<Func<ParticleSystem>>(
            Expression.New(typeof(ParticleSwarmSystem).GetConstructor(Type.EmptyTypes))
             ).Compile());
			systems.Add("Fire Particle System", Expression.Lambda<Func<ParticleSystem>>(
				Expression.New(typeof(FireParticleSystem).GetConstructor(Type.EmptyTypes))
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
