using System.Linq;
using OpenTK;
using System;
using System.Drawing;
using ParticleSystems.PositionUpdate;
using ParticleSystems.ParticleGeneration;
using ParticleSystems.SettingsPanels;

namespace ParticleSystems.Systems {
	class FireParticleSystem : ParticleSystem {
		private PositionUpdater PositionUpdater = new FirePositionUpdater();
		private LifetimeHandler LifetimeHandler = new LifetimeHandler();
		private ExpirationHandler ExpirationHandler = new ExpirationHandler();
		private Random Rand = new Random();

		private FireUserSettings Panel = new FireUserSettings();

		private FireParticleGenerator ParticleGenerator;

		private int minX = 280;
		private int maxX = 320;
        private int einflussbereich = 5;

		public FireParticleSystem() {

			//Panel = new AirFlowUserSettings();
		}

		protected override void Initialise() {
			ParticleGenerator = new FireParticleGenerator(
				Context.GetIdHolder().Width,
				Context.GetIdHolder().Height,
				ParticleSettings.GetLifetime(),
				ParticleSettings.GetAgingVelocity(),
				ParticleSettings.GetVelocity()
			);

            minX = Panel.GetXMin();
            maxX = Panel.GetXMax();
            einflussbereich = Panel.GetRange();

			CreateInitialParticles();

			//TODO: create stuff from settings
			//TODO: generate initial particles
		}

		protected override void UpdateVBOs() {
			bool gelb = true;
			ParticlePositions = new Vector2d[Particles.Count]; 
			ParticleColours = new Vector3d[Particles.Count];

			for (int i = 0; i < Particles.Count-1; i+=2) {
				Vector2d fire = Particles.ElementAt (i).GetPosition ();
				if(fire.X <=maxX+einflussbereich && fire.X >= minX-einflussbereich){
					for (int x = 0; x < Particles.Count-1; x+=2) {
						Vector2d water = Particles.ElementAt (x+1).GetPosition ();
						if (Math.Abs((int)fire.X-(int)water.X) <= einflussbereich && Math.Abs((int)fire.Y-(int)water.Y) <= einflussbereich) {

							//	System.Diagnostics.Debug.WriteLine ("Position: " + Particles.ElementAt(i).GetPosition()+ ", Position i+1: " + Particles.ElementAt(i+1).GetPosition());

							Particles.ElementAt (i).SetExpired ();
							Particles.ElementAt (i + 1).SetExpired ();
							break;
						}

				}

			

				}

			}

			int removed = ExpirationHandler.handleExpiration (Particles);
			for (int i = 0; i < Particles.Count; i++) {
				
				ParticlePositions[i] = Particles.ElementAt(i).GetPosition();

				double yellow = 1;

				if (gelb == true ) {
					yellow = (yellow - (( Particles.ElementAt(i).GetPosition().Y) /120 ));
					Vector3d vec3color = new Vector3d (1, yellow, 0);
					ParticleColours[i] = vec3color;

					//LifetimeHandler.DecrementLifetime (Particles);
					//ExpirationHandler.handleExpiration (Particles);


						//ParticlePositions [x];
						//for (int y = 0; y < Particles.Count; y++) {
								



					gelb = false;
				}   else {
					//blue = (blue - ((Particles.ElementAt(i).GetPosition().Y)/120));
					Vector3d vec3colorWater = new Vector3d (0, 0, 255);
					ParticleColours[i] = vec3colorWater;



					gelb = true;
				}




				/**Vector3d vec3color = new Vector3d(1, yellow, 0);
				Vector3d vec3colorWater = new Vector3d (50, blue, 100);
				ParticleColours[i] = vec3colorWater; 
				ParticleColours[i] = vec3color;**/

			}
		}
			

		protected void UpdateVBOs(Color color) {
			ParticlePositions = new Vector2d[Particles.Count]; 
			ParticleColours = new Vector3d[Particles.Count];
			for (int i = 0; i < Particles.Count; i++) {
				ParticlePositions[i] = Particles.ElementAt(i).GetPosition();
				Vector3d vec3color = new Vector3d(color.R, color.G, color.B);
				ParticleColours[i] = vec3color; //TODO: change accordingly
			}
		}

		/**protected override void UpdateVBOs2() {
			ParticlePositions2 = new Vector2d[Particles2.Count]; 
			ParticleColours2 = new Vector3d[Particles2.Count];
			for (int i = 0; i < Particles2.Count; i++) {
				Panel = (FireUserSettings)GetParticleSystemSettingsPanel();
				ParticlePositions2[i] = Particles2.ElementAt(i).GetPosition();
				Color color = Panel.getColor();

				double yellow = 1;

				yellow = (yellow - (( Particles2.ElementAt(i).GetPosition().Y) /100 ));

				Vector3d vec3color = new Vector3d(1, yellow, 0);
				ParticleColours2[i] = vec3color; 
			}
		}


		protected void UpdateVBOs2(Color color) {
			ParticlePositions2 = new Vector2d[Particles2.Count]; 
			ParticleColours = new Vector3d[Particles2.Count];
			for (int i = 0; i < Particles2.Count; i++) {
				ParticlePositions2[i] = Particles2.ElementAt(i).GetPosition();
				Vector3d vec3color = new Vector3d(color.R, color.G, color.B);
				ParticleColours[i] = vec3color; //TODO: change accordingly
			}
		}
            **/


		protected override void DecrementLifetime() {
			LifetimeHandler.DecrementLifetime(Particles);
		}

		protected override void RemoveExpiredParticles() {
			ExpirationHandler.handleExpiration(Particles);
		}

		protected override void GenerateNewParticles() {

			for (int i = 0; i < (ParticleSettings.GetNumberOfNewParticlesPerFrame() * 1.0); i++)
			{
				Particles.Add(ParticleGenerator.GenerateParticle());
				Particles.Add(ParticleGenerator.GenerateParticle2(minX, maxX));
			}
		}

		protected override void UpdateParticlePositions() {
			PositionUpdater.SetContext(Context);
			PositionUpdater.UpdatePositions(Particles);
		}

		private void CreateInitialParticles() {
			for (int i = 0; i < ParticleSettings.GetInitialNumberOfParticles(); i++) {
				Particles.Add(ParticleGenerator.GenerateParticle());
				Particles.Add (ParticleGenerator.GenerateParticle2 (minX, maxX));
			}
		}

		public override string GetDescription() {
			return "Simulating a wall of fire using a particle system";
		}

		public override ParticleSystemSettingsPanel GetParticleSystemSettingsPanel() {
			return Panel;
		}

		public override ParticleSettings GetParticleSettings() {
			Panel = (FireUserSettings)GetParticleSystemSettingsPanel();
			ParticleSettings.WithInitialNumberOfParticles(0);
			ParticleSettings.WithNewParticlesPerFrame(20);
			ParticleSettings.WithLifetime(110); 
			ParticleSettings.WithVelocity(5);
			ParticleSettings.WithGlBackgroundColor (Color.Gray);
			return ParticleSettings;
		}
	}
}
