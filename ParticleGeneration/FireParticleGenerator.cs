using System;
using OpenTK;
using ParticleSystems.Particles;

namespace ParticleSystems.ParticleGeneration
{
	/// <summary>
	/// Class to generate fire particles.
	/// </summary>
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

		/// <summary>
		/// Generates fire particles and returns the fire particle list.
		/// </summary>
		/// <returns></returns>
		public Particle GenerateParticle() {
			int agingVelocity = MaxAgingVelocity;
			double velocity = Random.NextDouble() * MaxVelocity;
			return new Particle(CreateStartingPosition(), MaxLifetime, agingVelocity, velocity);
		}

	
		/// <summary>
		/// Generates water particles and returns the water particle list.
		/// </summary>
		/// <returns></returns>
		public Particle GenerateParticle2(int minX, int maxX) {
			int agingVelocity = MaxAgingVelocity;
			double velocity = Random.NextDouble() * MaxVelocity;
			return new Particle(CreateStartingPosition2(minX, maxX), MaxLifetime, agingVelocity, velocity);
		}

		/// <summary>
		/// Sets the starting position for the fire particles.
		/// </summary>
		/// <returns></returns>
		private Vector2d CreateStartingPosition() {
			double y = 0;
			double x = Random.NextDouble() * Width;
			//double x = 300 ;
			return new Vector2d(x, y);
		}

		/// <summary>
		/// Sets the starting position for the water particles. Can be manipulated by user settings panel
		/// </summary>
		/// <returns></returns>
		private Vector2d CreateStartingPosition2(int minX, int maxX) {
			double y = 595;
			//double x = Random.NextDouble() * Width;
			double x = 300 ;
			x = (double)Random.Next (minX, maxX);
			return new Vector2d(x, y);
		}
	}
}
