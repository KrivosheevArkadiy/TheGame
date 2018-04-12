using UnityEngine;

namespace Assets.Scripts.Objects.Entities.Enemies
{
    public sealed class Vision
    {
        private float _activeDist;
        private float _activeAngle;

        public Vision(int activeDist = 25, int activeAngle = 35)
        {
            _activeDist = activeDist;
            _activeAngle = activeAngle;
        }

        public bool VisionMath(Transform transform, Transform target)
        {
            return Dist(transform, target) && Angle(transform, target) && !CheckBlocked(transform, target);
        }

        private bool Dist(Transform transform, Transform target)
        {
            return Vector3.Distance(transform.position, target.position) <= _activeDist;
        }

        private bool Angle(Transform transform, Transform target)
        {
            return Vector3.Angle(transform.forward, target.position - transform.position) <= _activeAngle;
        }

        private bool CheckBlocked(Transform transform, Transform target)
        {
            RaycastHit hit;
            if (!Physics.Linecast(transform.forward, target.position, out hit)) return true;
            return hit.transform != target;
        }
    }
}