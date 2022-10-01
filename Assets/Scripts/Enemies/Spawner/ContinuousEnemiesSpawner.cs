using System.Collections;
using UnityEngine;

namespace Enemies.Spawner
{
    public class ContinuousEnemiesSpawner : EnemiesSpawner
    {
        [SerializeField] private float enemiesPerSecond = 1f;

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
            Debug.Log($"Instantiate once in {amount}");
            while (true)
            {
                Debug.Log("Instantiate");
                InstantiateEnemies(1);
                yield return new WaitForSeconds(amount);
            }
        }
    }
}