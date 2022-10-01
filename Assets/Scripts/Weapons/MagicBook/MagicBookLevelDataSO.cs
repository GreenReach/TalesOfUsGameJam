using System;
using UnityEngine;

namespace Weapons.MagicBook
{
    [CreateAssetMenu(fileName = "MagicBooksLevels", menuName = "ScriptableObjects/Weapons/MagicBookLevels")]
    public class MagicBookLevelDataSO : ScriptableObject
    {
        [Serializable]
        public class LevelData
        {
            public int numberOfBooks;
            public int damage;
        }

        public LevelData[] levelData;
    }
}