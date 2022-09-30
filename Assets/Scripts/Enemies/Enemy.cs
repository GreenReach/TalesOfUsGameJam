using System;
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
        [SerializeField] private CharacterController characterController;
        
        
        public void DoDamage(int amount)
        {
            hp -= amount;
            if (hp <= 0)
                Kill();
        }

        public void MoveTowardsTarget(Transform target, float deltaTime)
        {
            var targetPosition = target.transform.position;
            var currentPosition = transform.position;

            var newPosition = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * deltaTime);
            var moveVector = newPosition - currentPosition;

            characterController.Move(moveVector);
            // transform.position = newPosition;
        }

        private void Kill()
        {
            OnPlayerBeingDestroyed?.Invoke(this);
            Destroy(this);
        }
    }
}