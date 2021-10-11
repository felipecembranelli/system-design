using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace consistent_hashing
{
    class Program
    {
        private const int numberOfQueues = 5;
        static List<string> queue1, queue2, queue3, queue4, queue5;

        static void Main(string[] args)
        {
            //ProcessTest(true);
            ConsistentHashing();
        }

        static void ConsistentHashing()
        {
            var buckets = new List<string> {"1", "2", "3"};

            ConsistentHashing<string> c = new ConsistentHashing<string>(buckets);

            byte[] bytes = {0,0,0,25};

            var ret = c.GetBucket(bytes);
        }

        private static void ProcessTest(bool defaultHashFunction)
        {
            queue1 = new List<string>();
            queue2 = new List<string>();
            queue3 = new List<string>();
            queue4 = new List<string>();
            queue5 = new List<string>();

            // arrange
            HashDistributionSample hashSample = new HashDistributionSample();

            var numberOfItems = 100;
            var count = 0;

            List<string> products = GenerateProductList(numberOfItems);

            foreach (var item in products)
            {
                count++;

                var queueId = hashSample.Process(defaultHashFunction, numberOfQueues, item);

                switch (queueId)
                {
                    case 0:
                        queue1.Add(item);
                        break;
                    case 1:
                        queue2.Add(item);
                        break;
                    case 2:
                        queue3.Add(item);
                        break;          
                    case 3:
                        queue4.Add(item);
                        break;          
                    case 4:
                        queue5.Add(item);
                        break;          
                    default:
                        throw new System.Exception("No queue defined");
                }

                Console.Clear();
                Console.WriteLine("Total Items :" + count);
                PrintQueueStatus(queue1.Count, "Queue 1");
                PrintQueueStatus(queue2.Count, "Queue 2");
                PrintQueueStatus(queue3.Count, "Queue 3");
                PrintQueueStatus(queue4.Count, "Queue 4");
                PrintQueueStatus(queue5.Count, "Queue 5");
                Thread.Sleep(250);
            }
        }

        private static void PrintQueueStatus(int queueSize, string queueName) 
        {
            StringBuilder items = new StringBuilder();
            char c = '|';

            for (int i = 0; i < queueSize; i++) items.Append(c);
            
            Console.WriteLine(String.Format("{0} : {2} [{1}]", queueName, queueSize, items.ToString()));
        }

        private static List<string> GenerateProductList(int numberOfItems) 
        {
                List<string> products = new List<string>();

                for (int i = 0; i < numberOfItems; i++)
                {
                    products.Add("SKU" + i.ToString());
                }

                return products;

        }
    }
}
