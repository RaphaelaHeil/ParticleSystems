using System;
using System.Collections.Generic;
using OpenTK;
using ParticleSystems.Particles;
using ParticleSystems;
using ParticleSystems.SettingsPanels;

namespace ParticleSystems.PositionUpdate
{

	/// <summary>
	/// Linearily translates particle positions.
	/// </summary>
	class FirePositionUpdater : PositionUpdater
	{
		private Context context;
		private const int DEFAULT_DELTA = 1;

		/// <summary>
		/// unused constructor
		/// </summary>
		public FirePositionUpdater ()
		{
		}

		/// <see cref="PositionUpdater.UpdatePositions(List{Particle})"/>
		/// <summary>
		/// Initiates the particle moving behaviour and directions
		/// </summary>
		public void UpdatePositions (List<Particle> particles)
		{
			bool isFire = true;
			foreach (var particle in particles) {
				if (isFire) {
					Random rand = new Random ();
					double x = rand.NextDouble ();
					// To generate movings of the particles
					if (x > 0.5) {
						x = x - 1;
					}
					x = x / 5;

					Vector2d Translation = new Vector2d (x, DEFAULT_DELTA);
					particle.updatePosition (Translation);
					isFire = false;
				} else {
					Random rand = new Random ();
					double x = rand.NextDouble ();
					if (x > 0.5) {
						x = x - 1;
					}
					x = x / 5;

					Vector2d Translation = new Vector2d (x, -DEFAULT_DELTA);
					particle.updatePosition (Translation);
					isFire = true;
				}
			}
		}

		/// <summary>
		/// Sets the context object
		/// </summary>
		/// <param name="context"></param>
		public void SetContext (Context context)
		{
			this.context = context;
		}

		/// <summary>
		/// Unused method
		/// </summary>
		/// <param name="context"></param>
		public void SetSettingsPanel (ParticleSystemSettingsPanel settingsPanel)
		{
			//TODO
		}
	}
}
