using Enemies.Types;
using UnityEngine;

namespace Enemies.PrefabPicker
{
    public abstract class EnemyPickerSO : ScriptableObject
    {
        public abstract EnemyBase PickNext();
    }
}