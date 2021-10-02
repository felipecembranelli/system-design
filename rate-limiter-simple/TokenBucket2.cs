using System;

public class TokenBucket {

    private long _maxBucketSize;
    private long _refillRate; // per second
    private long _currentBucketSize;
    private long _lastRefillTimestamp;

    public TokenBucket(long maxBucketSize, long refillRate)
    {
        _maxBucketSize = maxBucketSize;
        _refillRate = refillRate;
    }

    public bool AllowRequest(int token) {
        refill();
        if (_currentBucketSize >= token) {
            _currentBucketSize -= token;
            return true;
        }
        return false;
    }

    private void refill() {
        long now = System.DateTime.Now.Ticks;
        double add = (now - _lastRefillTimestamp) / 1e9 * _refillRate;
        _currentBucketSize = Math.Min(_currentBucketSize + (long)add, _maxBucketSize);
        _lastRefillTimestamp = now;
    }

}