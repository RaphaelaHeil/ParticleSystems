using System;
using System.Collections.Generic;
using OpenTK;
using ParticleSystems.Particles;
using ParticleSystems.SettingsPanels;

namespace ParticleSystems.PositionUpdate
{

    /// <summary>
    /// Linearily translates particle positions.
    /// </summary>
    class FirePositionUpdater : PositionUpdater
    {

        private const int DEFAULT_DELTA = 1;
        private Vector2d Translation;

        /// <summary>
        /// Default constructor, sets x and y updates to 1 each.
        /// </summary>
		public FirePositionUpdater()
        {
            Translation = new Vector2d(DEFAULT_DELTA, 0);
        }

        /// <summary>
        /// Constructs a LinearPositionUpdater that translates the positions by the given values.
        /// </summary>
        /// <param name="deltaX">Translation to be applied to the x coordinate</param>
        /// <param name="deltaY">Translation to be applied to the y coordinate</param>
		public FirePositionUpdater(int deltaY, int deltaX)
        {
            Translation = new Vector2d(deltaY, deltaX);
        }

        /// <see cref="PositionUpdater.UpdatePositions(List{Particle})"/>
        public void UpdatePositions(List<Particle> particles)
        {
            foreach (var particle in particles)
            {
                particle.updatePosition(Translation);
            }
        }

		public void SetContext(Context context){

		}

        public void SetSettingsPanel(ParticleSystemSettingsPanel settingsPanel)
        {
            throw new NotImplementedException();
        }
    }
}
