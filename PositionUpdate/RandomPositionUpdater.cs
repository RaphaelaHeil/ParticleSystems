using System;
using System.Collections.Generic;
using OpenTK;
using ParticleSystems.Particles;
using ParticleSystems.SettingsPanels;

namespace ParticleSystems.PositionUpdate
{
    class RandomPositionUpdater : PositionUpdater
    {
        private int UpperX = 5;
        private int UpperY = 5;
        private Random random = new Random();

        /// <summary>
        /// Default constructur, uses default values and generates translations in the range [-defaultValue*0.5 : defaultValue*0.5], both for x and y.
        /// </summary>
        public RandomPositionUpdater()
        {
            //nothing to do here, default values are already set :) 
        }

        /// <summary>
        /// Constructs a RandomPosititionUpdater that generates translations in the range [-maxX*0.5 : maxX*0.5] and [-maxY*0.5 : maxY*0.5] respectively.
        /// </summary>
        /// <param name="maxX">Upper bound for the x coordinate range</param>
        /// <param name="maxY">Upper bound for the y coordinate range</param>
        public RandomPositionUpdater(int maxX, int maxY)
        {
            UpperX = maxX;
            UpperY = maxY;
        }

        /// <see cref="PositionUpdater.UpdatePositions(List{Particle})"/>
        public void UpdatePositions(List<Particle> particles)
        {
            foreach(var particle in particles)
            {
                double x = (random.NextDouble() - 0.5) * UpperX;
                double y = (random.NextDouble() - 0.5) * UpperY;
                particle.updatePosition(new Vector2d(x, y));
            }
        }

        public void SetContext(Context context) {
            throw new NotImplementedException();
        }

        public void SetSettingsPanel(ParticleSystemSettingsPanel settingsPanel)
        {
            throw new NotImplementedException();
        }
    }
}
