using Enemies;
using Player;
using UnityEngine;

namespace Weapons.MagicBook
{
    public class MagicBookDamageGiver : MonoBehaviour
    {
        public int Damage
        {
            get => damage;
            set => damage = value;
        }
        
        [SerializeField] private int damage = 3;
        [SerializeField] private float hitCooldown = 0.3f;

        private float _lastHitTime = -100f;
        private PlayerController _playerController;

        public void Init(PlayerController playerController)
        {
            _playerController = playerController;
        }

        private void OnTriggerEnter(Collider col)
        {
            Debug.Log($"Book collided with {col.name}");
            if (Time.time - _lastHitTime <= hitCooldown)
                return;
            
            var damageable = col.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.DoDamage((int)(damage * _playerController.DamageModifier));
                _lastHitTime = Time.time;
            }
        }
    }
}