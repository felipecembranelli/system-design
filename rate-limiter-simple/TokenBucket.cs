// using System;
 
// public class TokenBucket
// {
//     float _capacity = 0;
//     float _tokens   = 0;
//     float _fill_rate = 0;
//     DateTime _time_stamp;
 
//     public TokenBucket(float tokens, float fill_rate)
//     {
//         _capacity  = tokens;
//         _tokens    = tokens;
//         _fill_rate = fill_rate;
//         _time_stamp = DateTime.Now;
//     }
 
//     public bool Consume(float tokens)
//     {
//         if(tokens < _capacity)
//         {
//             _tokens -= tokens;
//         }
//         else
//         {
//             return false;
//         }
//         return true;
//     }
 
//     public float GetTokens()
//     {
//         DateTime _now = DateTime.Now;
//         if(_tokens < _capacity)
//         {
//             var delta = _fill_rate * (_now - _time_stamp);

//             _tokens = Math.Min(_capacity, _tokens + (float)delta);
            
//             _time_stamp = _now;
//         }
//         return _tokens;
//     }
// }