using System;

public class TokenBucket {

    private long _maxBucketSize;
    private long _refillRate; // per second
    private long _currentBucketSize;
    private long _lastRefillTimestamp;
    private DateTime _lastRefillDateTime;

    public TokenBucket(long maxBucketSize, long refillRate)
    {
        _maxBucketSize = maxBucketSize;
        _refillRate = refillRate;
    }

    public bool AllowRequest(int token) {

        Console.WriteLine(String.Format("Tokens requested : {0}", token.ToString()));

        refill();
        if (_currentBucketSize >= token) {
            _currentBucketSize -= token;
            return true;
        }
        return false;
    }

    private void refill() {
        DateTime now = DateTime.UtcNow;           

        Console.WriteLine("Last refill : {0}", _lastRefillDateTime.ToString());

        TimeSpan timeDiff = now - _lastRefillDateTime;
        
        var timeDiffInSeconds = Convert.ToInt64(timeDiff.TotalMilliseconds) / 1000;

        double add = timeDiffInSeconds / _refillRate;

        Console.WriteLine(String.Format("Tokens to be added {0}: {1}", System.DateTime.Now.ToString(), add.ToString()));
        
        var result = _currentBucketSize + (long)add;

        _currentBucketSize = Math.Min(result, _maxBucketSize);

        Console.Write(String.Format("New Bucket size {0} : ", result.ToString()));

        //Console.Write("Bucket size : ");

        for (int i = 0; i < _currentBucketSize; i++)
        {
            Console.Write("|");
        }

        Console.Write("\n");

        if (add > 0) _lastRefillDateTime = now;
    }

}