﻿using System.Collections.Generic;
using Enemies.Types;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Spawner
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private EnemyBase enemyBasePrefab;
        [SerializeField] private EnemyLifecycleEventChannel enemyInstantiatedChannel;
        [SerializeField] private EnemyLifecycleEventChannel enemyDiedChannel;
        

        private List<EnemyBase> _instantiatedEnemies;

        private void Awake()
        {
            _instantiatedEnemies = new List<EnemyBase>();
        }

        protected virtual void OnEnable()
        {
            enemyInstantiatedChannel.OnRaise += RegisterEnemy;
            enemyDiedChannel.OnRaise += UnregisterEnemy;
        }
        
        protected virtual void OnDisable()
        {
            enemyInstantiatedChannel.OnRaise -= RegisterEnemy;
            enemyDiedChannel.OnRaise -= UnregisterEnemy;
        }

        protected virtual void Update()
        {
            UpdateEnemiesPosition();
        }

        private void UpdateEnemiesPosition()
        {
            foreach (var enemy in _instantiatedEnemies)
            {
                enemy.MoveTowardsPlayer(player, Time.deltaTime);
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

        
        public void InstantiateEnemies(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                InstantiateEnemyOutsideCameraView();
            }
        }

        private void InstantiateEnemyOutsideCameraView()
        {
            var cameraWorldRect = GetCameraWorldRect(Camera.main);
            var outsidePoint = RandomPointOutsideRect(cameraWorldRect, 2f);
            Instantiate(enemyBasePrefab, outsidePoint, Quaternion.identity, transform);
        }

        private static Rect GetCameraWorldRect(Camera camera)
        {
            var halfViewport = new Vector2(camera.orthographicSize * camera.aspect, camera.orthographicSize);

            return new Rect((Vector2)camera.transform.position - halfViewport, halfViewport * 2f);
        }

        private static Vector2 RandomPointOutsideRect(Rect rect, float maxDist)
        {
            var x = Random.Range(rect.x - maxDist, rect.x + rect.width + maxDist);

            float y;
            if (rect.x <= x && x <= rect.x + rect.width)
            {
                y = Random.Range(-maxDist, maxDist);
                if (y < 0f)
                    y += rect.y;
                else
                    y += rect.y + rect.height;
            }
            else
            {
                y = Random.Range(rect.y - maxDist, rect.y + rect.height + maxDist);
            }

            return new Vector2(x, y);
        }
    }
}