using UnityEngine;

namespace Commons
{
    public class ObjectiveIndicator : MonoBehaviour
    {
        [SerializeField] private float distanceToDisappear = 9f;
        [SerializeField] private GameObject arrow;
        
        private Transform _target;
        
        private void Update()
        {
            if (_target == null)
            {
                gameObject.SetActive(false);
                return;
            }
            
            PointAtTarget();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            gameObject.SetActive(true);
        }

        private void PointAtTarget()
        {
            var directionVector = _target.position - transform.position;

            if (directionVector.sqrMagnitude <= distanceToDisappear * distanceToDisappear)
            {
                arrow.SetActive(false);
            }
            else
            {
                arrow.SetActive(true);
                transform.right = directionVector;
            }
        }
    }
}