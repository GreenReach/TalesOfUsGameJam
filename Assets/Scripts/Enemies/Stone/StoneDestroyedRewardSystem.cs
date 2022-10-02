using System;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Stone
{
    public class StoneDestroyedRewardSystem : MonoBehaviour
    {
        [SerializeField] private float damageIncreaseFactor = 1f / 100f;
        [SerializeField] private int hpIncreaseRate = 2;
        [SerializeField] private NotificationEventChannel notificationChannel;

        private int _currentHpIncrease;

        private void Awake()
        {
            _currentHpIncrease = hpIncreaseRate;
        }

        public void StoneDestroyed(StoneController _) => StoneDestroyed();
        
        public void StoneDestroyed()
        {
            var probability = Random.Range(0f, 1f);
            
            if(probability <= 0.1f)
                IncreaseDamage();
            else
                IncreaseHp();
        }

        private void IncreaseDamage()
        {
            var currentFactor = PlayerPrefs.GetFloat(GameStructures.DamageIncreaseFactorKey);
            currentFactor += damageIncreaseFactor;
            PlayerPrefs.SetFloat(GameStructures.DamageIncreaseFactorKey, currentFactor);
            
            if(notificationChannel)
                notificationChannel.Invoke($"Damage was increased permanently by {(damageIncreaseFactor * 100f):F0}%");
        }

        private void IncreaseHp()
        {
            if(notificationChannel)
                notificationChannel.Invoke($"Player will always have {_currentHpIncrease} more HP");
            
            var currentAmount = PlayerPrefs.GetFloat(GameStructures.HpIncreaseAmountKey);
            currentAmount += _currentHpIncrease;
            _currentHpIncrease += hpIncreaseRate;
            PlayerPrefs.SetFloat(GameStructures.HpIncreaseAmountKey, currentAmount);
        }
        
    }
}