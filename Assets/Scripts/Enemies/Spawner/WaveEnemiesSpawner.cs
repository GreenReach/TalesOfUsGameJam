using System;
using Enemies.PrefabPicker;
using Enemies.Types;
using UnityEngine;

namespace Enemies.Spawner
{
    public class WaveEnemiesSpawner : EnemiesSpawner
    {
        [Serializable]
        public class WaveData
        {
            public int enemiesAmount;
            public EnemyPickerSO enemiesPicker;
        }

        [SerializeField] private WaveData[] waves;
        
        private int _currentWave = -1;

        private void Start()
        {
            StartNextWave();
        }

        protected override void UnregisterEnemy(EnemyBase enemyBase)
        {
            base.UnregisterEnemy(enemyBase);
            if (InstantiatedEnemies.Count == 0)
            {
                StartNextWave();
            }
        }

        private void StartNextWave()
        {
            _currentWave++;
            if (_currentWave >= waves.Length) return;
            
            enemyPicker = waves[_currentWave].enemiesPicker;
            InstantiateEnemies(waves[_currentWave].enemiesAmount);
        }
    }
}