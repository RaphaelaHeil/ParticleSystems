using System.Linq;
using OpenTK;
using System;
using System.Drawing;
using ParticleSystems.PositionUpdate;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.SettingsPanels;

namespace ParticleSystems.Systems
{
	class FireParticleSystem : ParticleSystem
	{
		private PositionUpdater PositionUpdater = new FirePositionUpdater();
		private LifetimeHandler LifetimeHandler = new LifetimeHandler();
		private ExpirationHandler ExpirationHandler = new ExpirationHandler();
		private Random Rand = new Random();

		//private FireUserSettings Panel = new FireUserSettings();

		private AirFlowParticleGenerator ParticleGenerator;

		public FireParticleSystem ()
		{
		}

		/// <summary>
		/// Gets the system's particle settings, i.e. default values to fill the GUI with and whether certain elements are enabled or not. 
		/// </summary>
		/// <returns></returns>
		public override ParticleSettings GetParticleSettings() {
			return new ParticleSettings();
		}

		/// <summary>
		/// Gets the system's settings panel to be displayed in the UI.
		/// </summary>
		/// <returns>The system's settings panel</returns>
		public override ParticleSystemSettingsPanel GetParticleSystemSettingsPanel(){
			return new ParticleSystemSettingsPanel();
		}

		/// <summary>
		/// Gets the particle system's description.
		/// </summary>
		/// <returns>Particle system description</returns>
		public override String GetDescription(){
			return "";
		}

		/// <summary>
		/// Will be called upon initialisation of the base class. Can be used to perform implementation specific initialisations.
		/// </summary>
		protected override void Initialise(){

		}

		/// <summary>
		/// Method representing the lifecycle step in which the lifetime of particles is decremented.
		/// </summary>
		protected override void DecrementLifetime(){

		}

		/// <summary>
		/// Method representing the lifecycle step in which expired particles are removed from the system.
		/// </summary>
		protected override void RemoveExpiredParticles(){

		}

		/// <summary>
		/// Method representing the lifecycle step in which new particles are generated.
		/// </summary>
		protected override void GenerateNewParticles(){

		}

		/// <summary>
		/// Method representing the lifecycle step in which the particle positions are updated.
		/// </summary>
		protected override void UpdateParticlePositions(){

		}

		/// <summary>
		/// Retrieve the particle positions and intended colours for rendering and prepare the two arrays ParticlePositions and ParticleColours.
		/// </summary>
		protected override void UpdateVBOs(){

		}

		protected override void GetDefaultGUIValues()
		{
			// max Lifetime default = 100;
			// Input xyz deaktiviert
			// 
		}


	}
}

