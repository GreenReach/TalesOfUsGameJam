using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemiesController : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private EnemyBase enemyBasePrefab;
        [SerializeField] private Rect instantiationArea;
        [SerializeField] private EnemyLifecycleEventChannel enemyInstantiatedChannel;
        [SerializeField] private EnemyLifecycleEventChannel enemyDiedChannel;
        

        private List<EnemyBase> _instantiatedEnemies;

        private void Awake()
        {
            _instantiatedEnemies = new List<EnemyBase>();
        }

        private void OnEnable()
        {
            enemyInstantiatedChannel.OnRaise += RegisterEnemy;
            enemyDiedChannel.OnRaise += UnregisterEnemy;
        }
        
        private void OnDisable()
        {
            enemyInstantiatedChannel.OnRaise -= RegisterEnemy;
            enemyDiedChannel.OnRaise -= UnregisterEnemy;
        }

        private void Update()
        {
            foreach (var enemy in _instantiatedEnemies)
            {
                enemy.MoveTowardsPlayer(player, Time.deltaTime);
            }
        }

        public void InstantiateEnemiesAtRandomPositions(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var newEnemyPosition = new Vector3(
                    instantiationArea.x + Random.Range(0f, instantiationArea.width),
                    instantiationArea.y + Random.Range(0f, instantiationArea.height),
                    0f);
                var newEnemy = Instantiate(enemyBasePrefab, newEnemyPosition, Quaternion.identity, transform);
            }
        }

        private void UnregisterEnemy(EnemyBase enemyBase)
        {
            _instantiatedEnemies.Remove(enemyBase);
        }

        private void RegisterEnemy(EnemyBase enemyBase)
        {
            _instantiatedEnemies.Add(enemyBase);
        }
    }
}