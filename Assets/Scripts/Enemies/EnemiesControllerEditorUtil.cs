using System;
using Enemies.Spawner;
using UnityEngine;

namespace Enemies
{
    public class EnemiesControllerEditorUtil : MonoBehaviour
    {
        [SerializeField] private int amountOfEnemies = 10;
        [SerializeField] private bool instantiateAtStart;
        
        private EnemiesSpawner _enemiesSpawner;

        private void Awake()
        {
            _enemiesSpawner = GetComponent<EnemiesSpawner>();
        }

        private void Start()
        {
            if(instantiateAtStart)
                InstantiateEnemies();
        }

        [ContextMenu("InstantiateEnemies")]
        private void InstantiateEnemies()
        {
            _enemiesSpawner.InstantiateEnemies(amountOfEnemies);
        }
    }
}