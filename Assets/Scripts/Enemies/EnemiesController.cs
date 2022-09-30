using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemiesController : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private EnemyBase enemyBasePrefab;
        [SerializeField] private Rect instantiationArea;

        private List<EnemyBase> _instantiatedEnemies;

        private void Awake()
        {
            _instantiatedEnemies = new List<EnemyBase>();
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

                _instantiatedEnemies.Add(newEnemy);
                newEnemy.OnPlayerBeingDestroyed += RemoveEnemyFromList;
            }
        }

        private void RemoveEnemyFromList(EnemyBase enemyBase)
        {
            _instantiatedEnemies.Remove(enemyBase);
        }
    }
}