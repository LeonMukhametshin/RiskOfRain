using UnityEngine;

namespace SmoothCamera
{
    public class FollowerFixedUpdate : Follower
    {
        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }
    }
}