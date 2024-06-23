using UnityEngine;

namespace SmoothCamera
{
    public abstract class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Vector3 _offcet;
        [SerializeField] private float _smoothing = 1f;

        protected void Move(float deltaTime)
        {
            var nextPostiont = Vector3.Lerp(transform.position, _targetTransform.position + _offcet, deltaTime * _smoothing);

            transform.position = nextPostiont;
        }
    }
}