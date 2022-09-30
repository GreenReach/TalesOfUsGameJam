using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemiesController : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private Rect instantiationArea;

        private List<Enemy> _instantiatedEnemies;

        private void Awake()
        {
            _instantiatedEnemies = new List<Enemy>();
        }

        private void Update()
        {
            foreach (var enemy in _instantiatedEnemies)
            {
                enemy.MoveTowardsTarget(player.transform, Time.deltaTime);
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
                var newEnemy = Instantiate(enemyPrefab, newEnemyPosition, Quaternion.identity, transform);

                _instantiatedEnemies.Add(newEnemy);
                newEnemy.OnPlayerBeingDestroyed += RemoveEnemyFromList;
            }
        }

        private void RemoveEnemyFromList(Enemy enemy)
        {
            _instantiatedEnemies.Remove(enemy);
        }
    }
}