using UnityEngine;

namespace Enemies
{
    public class EnemiesControllerEditorUtil : MonoBehaviour
    {
        [SerializeField] private int amountOfEnemies = 10;
        
        private EnemiesController _enemiesController;

        private void Awake()
        {
            _enemiesController = GetComponent<EnemiesController>();
        }

        [ContextMenu("InstantiateEnemies")]
        private void InstantiateEnemies()
        {
            _enemiesController.InstantiateEnemiesAtRandomPositions(amountOfEnemies);
        }
    }
}