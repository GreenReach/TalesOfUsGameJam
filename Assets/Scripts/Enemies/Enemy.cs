using System;
using Commons;
using Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    // [RequireComponent(typeof(CharacterController))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        public event Action<Enemy> OnPlayerBeingDestroyed;
        
        [SerializeField] private int hp = 10;
        [SerializeField] private float movementSpeed = 1f;
        [SerializeField] private int damage = 3;
        [SerializeField] private float attackRange;
        [SerializeField] private float attackCooldown = 0.3f;
        
        [Header("Dependencies")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] private HealthBar healthBar;

        private float _lastAttackTime = -100f;
        private float _maxHp;

        private void Awake()
        {
            _maxHp = hp;
        }

        public void DoDamage(int amount)
        {
            hp -= amount;
            UpdateHealthBar();
            if (hp <= 0)
                Kill();
        }

        public void MoveTowardsPlayer(PlayerController target, float deltaTime)
        {
            var targetPosition = target.transform.position;
            var currentPosition = transform.position;

            var newPosition = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * deltaTime);
            var moveVector = newPosition - currentPosition;

            characterController.Move(moveVector);

            if (IsPlayerInAttackRange(targetPosition) && !HaveAttackCooldown())
            {
                target.TakeDamage(damage);
                _lastAttackTime = Time.time;
            }
        }

        private void UpdateHealthBar()
        {
            var health = 1f * hp / _maxHp;
            healthBar.SetHealth(health);
        }
        
        private void Kill()
        {
            OnPlayerBeingDestroyed?.Invoke(this);
            Destroy(this);
        }
        
        private bool IsPlayerInAttackRange(Vector3 playerPosition)
        {
            var distanceToPlayer = Vector3.Distance(playerPosition, transform.position);
            return distanceToPlayer <= attackRange || Mathf.Approximately(distanceToPlayer, attackRange);
        }

        private bool HaveAttackCooldown()
        {
            var lastAttackDeltaTime = Time.time - _lastAttackTime;
            return lastAttackDeltaTime <= attackCooldown;
        }
    }
}