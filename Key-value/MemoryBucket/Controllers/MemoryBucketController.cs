using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using MemoryBucket.Classes;

namespace MemoryBucket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemoryBucketController : ControllerBase
    {
        private static Buckets buckets = new Buckets();
        private static object locker = new object();

        public MemoryBucketController()
        {
        }

        /// <summary>
        /// Returns the contents of an existing bucket.
        /// </summary>
        [HttpGet]
        public object Get([FromQuery, BindRequired] string bucketName)
        {
            lock (locker)
            {
                Assertion.That(buckets.TryGetValue(bucketName, out Bucket bucket), $"No bucket with name {bucketName} exists.");

                return bucket.Data;
            }
        }

        /// <summary>
        /// Lists all buckets.
        /// </summary>
        [HttpGet("List")]
        public object GetBucket()
        {
            lock (locker)
            {
                return buckets.Select(b => b.Key);
            }
        }

        /// <summary>
        /// Returns the bucket itself.
        /// </summary>
        [HttpGet("Bucket")]
        public object GetBucket([FromQuery, BindRequired] string bucketName)
        {
            lock (locker)
            {
                Assertion.That(buckets.TryGetValue(bucketName, out Bucket bucket), $"No bucket with name {bucketName} exists.");

                return bucket;
            }
        }

        /// <summary>
        /// Deletes an existing bucket.
        /// </summary>
        [HttpDelete("{bucketName}")]
        public void Delete(string bucketName)
        {
            lock (locker)
            {
                Assertion.That(buckets.TryGetValue(bucketName, out Bucket bucket), $"No bucket with name {bucketName} exists.");

                buckets.Remove(bucketName);
            }
        }

        /// <summary>
        /// Creates or gets an existing bucket and replaces its data.
        /// </summary>
        [HttpPost("Set")]
        public object Post([FromQuery, BindRequired] string bucketName, [FromBody] Dictionary<string, object> data)
        {
            lock (locker)
            {
                var bucket = CreateOrGetBucket(bucketName);
                bucket.Data = data;

                return data;
            }
        }

        /// <summary>
        /// Creates or gets an existing bucket and updates the specified key with the specified value.
        /// </summary>
        [HttpPost("Update")]
        public object Post(
            [FromQuery, BindRequired] string bucketName,
            [FromQuery, BindRequired] string key,
            [FromQuery, BindRequired] string value)
        {
            lock (locker)
            {
                var bucket = CreateOrGetBucket(bucketName);

                var data = bucket.Data;
                data[key] = value;

                return data;
            }
        }

        private Bucket CreateOrGetBucket(string bucketName)
        {
                if (!buckets.TryGetValue(bucketName, out Bucket bucket))
                {
                    bucket = new Bucket();
                    bucket.Name = bucketName;
                    buckets[bucketName] = bucket;
                }

            return bucket;
        }
    }
}
