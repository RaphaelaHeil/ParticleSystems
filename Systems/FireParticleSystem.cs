using System.Linq;
using OpenTK;
using System;
using System.Drawing;
using ParticleSystems.PositionUpdate;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.SettingsPanels;

namespace ParticleSystems.Systems
{
	/// <summary>
	/// Particle System wich organizes particles and classes to simulates a wall of fire with a waterfall.
	/// </summary>
	class FireParticleSystem : ParticleSystem
	{
		private PositionUpdater PositionUpdater = new FirePositionUpdater ();
		private LifetimeHandler LifetimeHandler = new LifetimeHandler ();
		private ExpirationHandler ExpirationHandler = new ExpirationHandler ();

		private FireUserSettings Panel = new FireUserSettings ();

		private FireParticleGenerator ParticleGenerator;

		private int minX = 280;
		private int maxX = 320;
		private int range = 5;
		/// <summary>
		/// Empty constructor, doesn't do anything at the moment
		/// </summary>
		public FireParticleSystem ()
		{
		}

		/// <summary>
		/// Function to initialise the particle system. Has to be called before the first call to RenderFrame.
		/// </summary>
		protected override void Initialise ()
		{
			ParticleGenerator = new FireParticleGenerator (
				Context.GetIdHolder ().Width,
				Context.GetIdHolder ().Height,
				ParticleSettings.GetLifetime (),
				ParticleSettings.GetAgingVelocity (),
				ParticleSettings.GetVelocity ()
			);

			minX = Panel.GetXMin ();
			maxX = Panel.GetXMax ();
			if (minX > maxX) {
				maxX = Panel.GetXMin ();
				minX = Panel.GetXMax ();
			}
			range = Panel.GetRange ();

			CreateInitialParticles ();

			//TODO: create stuff from settings
			//TODO: generate initial particles
		}

		/// <summary>
		/// Updates the vertex buffer object.
		/// Also calculates if fire particles get hit by water particles. If true, fire particles get deletes
		/// </summary>
		protected override void UpdateVBOs ()
		{
			bool gelb = true;
			ParticlePositions = new Vector2d[Particles.Count]; 
			ParticleColours = new Vector3d[Particles.Count];

			// To check if the fire particles touch the water particles in changing order
			// To do so we take the first fire particle and check it with every water particle. If they touch, the water will be removed.
			// Every water particle is being checked in this way
			for (int i = 0; i < Particles.Count - 1; i += 2) {
				Vector2d fire = Particles.ElementAt (i).GetPosition ();
				//We only want to check the particles that are in the range of the waterfall on the x-axys 
				if (fire.X <= maxX + range && fire.X >= minX - range) {
					for (int x = 0; x < Particles.Count - 1; x += 2) {
						Vector2d water = Particles.ElementAt (x + 1).GetPosition ();
						if (Math.Abs ((int)fire.X - (int)water.X) <= range && Math.Abs ((int)fire.Y - (int)water.Y) <= range) {
							//remove matching particles
							Particles.ElementAt (i).SetExpired ();
							Particles.ElementAt (i + 1).SetExpired ();
							break;
						}
					}
				}
			}

			// to set the right colors for fire and water particles
			for (int i = 0; i < Particles.Count; i++) {
				
				ParticlePositions [i] = Particles.ElementAt (i).GetPosition ();
				double yellow = 1;

				if (gelb == true) {
					yellow = (yellow - ((Particles.ElementAt (i).GetPosition ().Y) / 120));
					Vector3d vec3color = new Vector3d (1, yellow, 0);
					ParticleColours [i] = vec3color;
					gelb = false;
				} else {
					Vector3d vec3colorWater = new Vector3d (0, 0, 255);
					ParticleColours [i] = vec3colorWater;
					gelb = true;
				}
			}
		}

		/// <summary>
		/// Decrease the lifetime of the particles.
		/// </summary>
		protected override void DecrementLifetime ()
		{
			LifetimeHandler.DecrementLifetime (Particles);
		}

		/// <summary>
		/// Remove expired particles from the particle list.
		/// </summary>
		protected override void RemoveExpiredParticles ()
		{
			ExpirationHandler.handleExpiration (Particles);
		}

		/// <summary>
		/// Generate new particles with a number of particles to simulate fire and water.
		/// </summary>
		protected override void GenerateNewParticles ()
		{

			for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame () * 1.0); i++) {
				Particles.Add (ParticleGenerator.GenerateParticle ());
				Particles.Add (ParticleGenerator.GenerateParticle2 (minX, maxX));
			}
		}

		/// <summary>
		/// Updates the position of the particles and sets the context
		/// </summary>
		protected override void UpdateParticlePositions ()
		{
			PositionUpdater.SetContext (Context);
			PositionUpdater.UpdatePositions (Particles);
		}

		/// <summary>
		/// Create an initial number of particles, based on the user settings.
		/// </summary>
		private void CreateInitialParticles ()
		{
			for (int i = 0; i < ParticleSettings.GetInitialNumberOfParticles (); i++) {
				Particles.Add (ParticleGenerator.GenerateParticle ());
				Particles.Add (ParticleGenerator.GenerateParticle2 (minX, maxX));
			}
		}

		/// <summary>
		/// Returns the description of the particle system
		/// </summary>
		/// <returns></returns>
		public override string GetDescription ()
		{
			return "Simulating a wall of fire being hit by a waterfall using a particle system";
		}

		/// <summary>
		/// Returns the Settings-Panel-Object of the particle system.
		/// </summary>
		/// <returns></returns>
		public override ParticleSystemSettingsPanel GetParticleSystemSettingsPanel ()
		{
			return Panel;
		}

		/// <summary>
		/// Resturns the default values for the Settings-Panel-Object
		/// </summary>
		/// <returns></returns>
		public override ParticleSettings GetParticleSettings ()
		{
			Panel = (FireUserSettings)GetParticleSystemSettingsPanel ();
			ParticleSettings.WithInitialNumberOfParticles (0);
			ParticleSettings.WithNewParticlesPerFrame (20);
			ParticleSettings.WithLifetime (125); 
			ParticleSettings.WithVelocity (5);
			ParticleSettings.WithGlBackgroundColor (Color.Gray);
			return ParticleSettings;
		}
	}
}
