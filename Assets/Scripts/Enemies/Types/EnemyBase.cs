﻿using Commons;
using Player;
using UnityEngine;

namespace Enemies.Types
{
    public abstract class EnemyBase : MonoBehaviour, IDamageable
    {
        [SerializeField] protected int hp = 10;
        [SerializeField] protected float movementSpeed = 1f;
        [SerializeField] protected int damage = 3;
        [SerializeField] protected float attackRange = .5f;
        [SerializeField] protected float attackCooldown = 0.3f;
        [SerializeField] private GameObject[] dropoutItemsPrefabs;
        
        [Header("Dependencies")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private EnemyLifecycleEventChannel enemyInstantiatedChannel;
        [SerializeField] private EnemyLifecycleEventChannel enemyDiedChannel;


        private float _lastAttackTime = -100f;
        private float _maxHp;

        private void Awake()
        {
            _maxHp = hp;
            enemyInstantiatedChannel.RaiseEvent(this);
        }

        public void DoDamage(int amount)
        {
            Debug.Log($"Do damage: {amount}", this);
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

            if (!IsPlayerInAttackRange(targetPosition))
            {
                characterController.Move(moveVector);
            }

            if (IsPlayerInAttackRange(targetPosition) && !HaveAttackCooldown())
            {
                Attack(target);
                _lastAttackTime = Time.time;
            }
        }

        protected abstract void Attack(PlayerController target);

        private void UpdateHealthBar()
        {
            var health = 1f * hp / _maxHp;
            healthBar.SetHealth(health);
        }
        
        private void Kill()
        {
            enemyDiedChannel.RaiseEvent(this);
            DropLoot();
            Destroy(gameObject);
        }

        private void DropLoot()
        {
            if (dropoutItemsPrefabs == null)
                return;

            foreach (var dropoutItemPrefab in dropoutItemsPrefabs)
            {
                var randomPosition = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                var dropoutItem = Instantiate(dropoutItemPrefab, randomPosition, Quaternion.identity);
            }
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