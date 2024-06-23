using UnityEngine;

namespace SmoothCamera
{
    public class FollowerUpdate : Follower
    {
        private void Update()
        {
            Move(Time.deltaTime);
        }
    }
}