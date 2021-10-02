using System;
using System.Threading.Tasks;

namespace rate_limiter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            LeakyBucket leakyBucket = new LeakyBucket(new BucketConfiguration
            {
                LeakRate = 1, 
                LeakRateTimeSpan = TimeSpan.FromSeconds(5), 
                MaxFill = 4
            });

            while (true)
            {
                await leakyBucket.GainAccess();
                Console.WriteLine("Hello World! " + DateTime.Now);
            }
        }
    }
}
