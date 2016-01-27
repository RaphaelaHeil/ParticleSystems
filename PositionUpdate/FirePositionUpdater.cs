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
		private Vector2d TranslationX;
		private Vector2d TranslationYup;
		private Vector2d TranslationYdown;
		LifetimeHandler LifetimeHandler = new LifetimeHandler ();
		ExpirationHandler ExpirationHandler = new ExpirationHandler ();


		public FirePositionUpdater ()
		{
			TranslationX = new Vector2d (DEFAULT_DELTA, 0);
			TranslationYup = new Vector2d (0, DEFAULT_DELTA);
			TranslationYdown = new Vector2d (0, -DEFAULT_DELTA);
		}

		/// <see cref="PositionUpdater.UpdatePositions(List{Particle})"/>
		public void UpdatePositions (List<Particle> particles)
		{
			bool isFire = true;
			foreach (var particle in particles) {
				int particlePosX = (int)particle.GetPosition ().X;
				int particlePosY = (int)particle.GetPosition ().Y;
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


		public void SetContext (Context context)
		{
			this.context = context;
		}

		public void SetSettingsPanel (ParticleSystemSettingsPanel settingsPanel)
		{
			//TODO
		}
	}
}
