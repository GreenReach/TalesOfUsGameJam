using Enemies.Spawner;
using UnityEngine;

namespace Enemies.Stone
{
    public class IncreaseEnemiesDifficultyOnStoneDestroyed : MonoBehaviour
    {
        [SerializeField] private EnemiesSpawner enemiesSpawner;
        [SerializeField] private float difficultyIncreaseFactor = 0.33f;
        
        public void IncreaseDifficulty()
        {
            enemiesSpawner.DifficultyFactor *= (1f + difficultyIncreaseFactor);
        }
    }
}