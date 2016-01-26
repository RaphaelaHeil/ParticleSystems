using System;
using OpenTK;
using ParticleSystems.Particles;

namespace ParticleSystems.ParticleGeneration
{
	class FireParticleGenerator : ParticleGenerator 
	{
		private int Width;
		private int Height;
		private int MaxLifetime;
		private int MaxAgingVelocity;
		private double MaxVelocity;

		private Random Random = new Random();

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="width">Width of the space in which to generate particles; generally equals the glControl width</param>
		/// <param name="height">Height of the space in which to generate particles; generally equals the glControl height</param>
		/// <param name="maxLifetime">Maximum lifetime of newly generated particles</param>
		/// <param name="maxAgingVelocity">Maximum velocity at which particles age</param>
		/// <param name="maxVelocity">Maximum velocity</param>
		public FireParticleGenerator(int width, int height, int maxLifetime, int maxAgingVelocity, double maxVelocity) {
			this.Width = width;
			this.Height = height;
			this.MaxLifetime = maxLifetime;
			this.MaxAgingVelocity = maxAgingVelocity;
			this.MaxVelocity = maxVelocity;
		}

		public Particle GenerateParticle() {
			Random rand = new Random();
			int lifetime = (int)(rand.NextDouble() * 1000);
			int agingVelocity = MaxAgingVelocity;
			double velocity = Random.NextDouble() * MaxVelocity;
			return new Particle(CreateStartingPosition(), MaxLifetime, agingVelocity, velocity);
		}

		/**public Particle GenerateParticle() {
			return null;
		}**/

		public Particle GenerateParticle2(int minX, int maxX) {
			Random rand = new Random();
			int lifetime = (int)(rand.NextDouble() * 1000);
			int agingVelocity = MaxAgingVelocity;
			double velocity = Random.NextDouble() * MaxVelocity;
			return new Particle(CreateStartingPosition2(minX, maxX), MaxLifetime, agingVelocity, velocity);
		}

		private Vector2d CreateStartingPosition() {
			double y = 0;
			double x = Random.NextDouble() * Width;
			//double x = 300 ;
			return new Vector2d(x, y);
		}

		private Vector2d CreateStartingPosition2(int minX, int maxX) {
			double y = 580;
			//double x = Random.NextDouble() * Width;
			double x = 300 ;
			x = (double)Random.Next (minX, maxX);
			return new Vector2d(x, y);
		}
	}
}
