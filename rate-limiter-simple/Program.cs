using System;

namespace rate_limiter_simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var rateLimiter = new TokenBucket(10,1);
            
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());
            Console.WriteLine(rateLimiter.AllowRequest(1).ToString());

        }
    }
}
