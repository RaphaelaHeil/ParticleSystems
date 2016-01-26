using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystems.Strategies
{
    class GaussianRandomHelper
    {
        private static Random random = new Random();

        public static double GetRandomValue(double mean = 0.0, double standardDeviation = 0.6)
        {
            double u1 = random.NextDouble();
            double u2 = random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal = mean + standardDeviation * randStdNormal; //random normal(mean,stdDev^2)
            return randNormal;
        }

        //http://stackoverflow.com/questions/218060/random-gaussian-variables 



        //public double GetRandomValue()
        //{
        //    Random rand = new Random(); //reuse this if you are generating many
        //    double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
        //    double u2 = rand.NextDouble();
        //    double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
        //                 Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        //    double randNormal =
        //                 mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
        //}


    }
}
