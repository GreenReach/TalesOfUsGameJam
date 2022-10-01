using System.Collections;
using UnityEngine;

namespace Enemies.Spawner
{
    public class ContinuousEnemiesSpawner : EnemiesSpawner
    {
        [Header("ContinuousSpecific")]
        [SerializeField] private float enemiesPerSecond = 1f;
        [SerializeField] private float difficultyFactorIncreasePerMinute = 0.15f;

        private IEnumerator _instantiationCoroutine;

        protected override void OnEnable()
        {
            base.OnEnable();
            if (!Mathf.Approximately(enemiesPerSecond, 0f))
            {
                _instantiationCoroutine = InstantiateOnceIn(1f / enemiesPerSecond);
                StartCoroutine(_instantiationCoroutine);
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            StopCoroutine(_instantiationCoroutine);
        }

        private IEnumerator InstantiateOnceIn(float amount)
        {
            while (true)
            {
                InstantiateEnemies(1);
                yield return new WaitForSeconds(amount);
                DifficultyFactor += difficultyFactorIncreasePerMinute * amount / 60f;
            }
        }
    }
}