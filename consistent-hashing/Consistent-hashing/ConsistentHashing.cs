using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

class ConsistentHashing<T>
    {
        struct Point
        {
            public readonly UInt32 key;
            public readonly T bucket;

            public Point(UInt32 k, T v)
            {
                key = k;
                bucket = v;
            }
        }

        //MurmurHash2UInt32Hack hash = new MurmurHash2UInt32Hack();
        private MD5 hash = MD5.Create();
        private Point[] circle;

        public T GetBucket(byte[] input)
        {
            UInt32 top = (UInt32)circle.Length;
            UInt32 high = top;
            UInt32 low = 0;
            //var val = hash.ComputeHash(input);

            byte[] hashBytes = hash.ComputeHash(input);
            var val = Convert2Int(hashBytes);
            
            while(true)
            {
                UInt32 mid = (high - low)/2 + low;
                var pt = circle[mid];
                if (val > pt.key)
                    low = mid;
                else if (val < pt.key)
                    high = mid;
                if (mid == top)
                    return circle[0].bucket;
                else if (high - low <= 1)
                    return circle[mid].bucket;
            }
        }

        public ConsistentHashing(IEnumerable<T> buckets)
        {
            var lst = new SortedList<UInt32,Point>();
            var encoder = Encoding.ASCII;
            foreach (var bucket in buckets)
            {
                for (var i=0; i < 160; i++)
                {
                    var name = bucket.ToString() + i;
                    byte[] input = encoder.GetBytes(name);
                    //var key = hash.Hash(input);
                    byte[] keyBytes = hash.ComputeHash(input);
                    var key = Convert2Int(keyBytes);
                    lst.Add(key, new Point(key, bucket));
                }
            }

            circle = lst.Values.ToArray();
        }

        private UInt32 Convert2Int(byte[] input) 
        {
            return BitConverter.ToUInt32(input,0);
        }
    }