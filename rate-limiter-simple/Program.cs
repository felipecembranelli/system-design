using System;
using System.Threading;

namespace rate_limiter_simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var rateLimiter = new TokenBucket(20,1);
            

            while (true)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine(String.Format("Request accepted : {0}" ,rateLimiter.AllowRequest(5).ToString()));
                Console.WriteLine("------------------------");
                Thread.Sleep(3000);
            }
        }
    }
}
