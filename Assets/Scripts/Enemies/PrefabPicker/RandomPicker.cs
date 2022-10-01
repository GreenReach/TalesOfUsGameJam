using Enemies.Types;
using UnityEngine;

namespace Enemies.PrefabPicker
{
    [CreateAssetMenu(fileName = "RandomPicker", menuName = "ScriptableObjects/Enemies/RandomPicker")]
    public class RandomPicker : EnemyPickerSO
    {
        [SerializeField] private EnemyBase[] options;


        public override EnemyBase PickNext()
        {
            int randomIndex = Random.Range(0, options.Length);
            return options[randomIndex];
        }
    }
}