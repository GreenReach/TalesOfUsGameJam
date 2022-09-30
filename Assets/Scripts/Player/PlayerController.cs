using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float DamageModifier { get; set; }
        public float SpeedModifier { get; set; }

        public void TakeDamage(int amount)
        {
            Debug.Log($"Took damage: {amount}");
        }

        public void Heal(int amount)
        {
            Debug.Log($"Heal: {amount}");
        }

        public void IncreaseHealth(int amount)
        {
            Debug.Log($"Increase health by: {amount}");
        }
    }
}