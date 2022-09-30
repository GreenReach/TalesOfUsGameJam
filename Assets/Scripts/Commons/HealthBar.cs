using UnityEngine;

namespace Commons
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Transform healthImage;

        public void SetHealth(float amount)
        {
            var newScale = healthImage.localScale;
            newScale.x = amount;
            healthImage.localScale = newScale;
        }
    }
}