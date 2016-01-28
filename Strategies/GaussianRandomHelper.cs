using System;

namespace ParticleSystems.Strategies
{
    /// <summary>
    /// Calculates gaussian distribution values from random number generator values. Based on the Box-Muller tranform.
    /// <seealso cref="http://stackoverflow.com/questions/218060/random-gaussian-variables "/>
    /// </summary>
    class GaussianRandomHelper
    {
        private static Random random = new Random();

        // source code taken from: http://stackoverflow.com/questions/218060/random-gaussian-variables 
        public static double GetRandomValue(double mean = 0.0, double standardDeviation = 0.6)
        {
            double u1 = random.NextDouble();
            double u2 = random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double randNormal = mean + standardDeviation * randStdNormal;
            return randNormal;
        }
    }
}
