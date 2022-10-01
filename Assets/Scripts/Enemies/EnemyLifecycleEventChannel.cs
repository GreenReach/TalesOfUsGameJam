using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(fileName = "EnemyEvent", menuName = "ScriptableObjects/EnemyLifecycleEvent")]
    public class EnemyLifecycleEventChannel : ScriptableObject
    {
        public delegate void ActionInvokedHandler(EnemyBase enemy);

        public event ActionInvokedHandler OnRaise;

        public void RaiseEvent(EnemyBase enemy) => OnRaise?.Invoke(enemy);
    }
}