using System;
using Commons;
using UnityEngine;

namespace Enemies.Stone
{
    public class StoneController : MonoBehaviour, IDamageable
    {
        public Action<StoneController> OnStoneDestroyed;
        
        [SerializeField] private int level0Health = 100;
        [SerializeField] private float healthIncreasePerLevel = 0.5f;

        [SerializeField] private int currentHealth;

        private int _fullHealth;
        private int _level;
        private HealthBar _healthBar;

        private void Awake()
        {
            _healthBar = GetComponentInChildren<HealthBar>();
        }

        private void Start()
        {
            SetLevel(_level);
        }

        public void DoDamage(int amount)
        {
            currentHealth -= amount;
            if(_healthBar != null)
                _healthBar.SetHealth(1f * currentHealth / _fullHealth);
                
            if (currentHealth <= 0)
            {
                OnStoneDestroyed?.Invoke(this);
                Destroy(gameObject);
            }
        }

        public void SetLevel(int level)
        {
            _level = level;
            currentHealth = level0Health * (int) Mathf.Pow((1f + healthIncreasePerLevel), _level);
            _fullHealth = currentHealth;
        }
        
    }
}