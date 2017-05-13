using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI
{
    class RandomStaticProvider
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomInteger(int min, int max)
        {
            lock (syncLock)
            {
                return random.Next(min, max);
            }
        }
        public static double RandomDouble()
        {
            lock (syncLock)
            {
                return random.NextDouble();
            }
        }
    }
}
