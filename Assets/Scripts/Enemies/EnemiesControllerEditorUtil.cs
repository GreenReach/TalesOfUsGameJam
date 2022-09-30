using UnityEngine;

namespace Enemies
{
    public class EnemiesControllerEditorUtil : MonoBehaviour
    {
        [SerializeField] private int amountOfEnemies = 10;
        [SerializeField] private bool instantiateAtAwake;
        
        private EnemiesController _enemiesController;

        private void Awake()
        {
            _enemiesController = GetComponent<EnemiesController>();
            
            if(instantiateAtAwake)
                InstantiateEnemies();
        }

        [ContextMenu("InstantiateEnemies")]
        private void InstantiateEnemies()
        {
            _enemiesController.InstantiateEnemiesAtRandomPositions(amountOfEnemies);
        }
    }
}