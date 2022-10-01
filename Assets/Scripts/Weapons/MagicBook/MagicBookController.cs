using System;
using Player;
using UnityEngine;
using Weapons.MagicBook;

public class MagicBookController : MonoBehaviour
{
    [SerializeField] private int startingLevel;
    [SerializeField] private float rotatingSpeed = 90f;
    [SerializeField] private float circleRadius = 1.5f;
    [SerializeField] private MagicBookDamageGiver magicBookDamageGiverPrefab;
    [SerializeField] private MagicBookLevelDataSO levelDataSO;

    private PlayerController _playerController;
    private MagicBookDamageGiver[] _currentDamageGivers;
    private int _currentLevel;
    private int _numberOfBooks;

    private void OnEnable()
    {
        _playerController = GetComponentInParent<PlayerController>();
        if (_playerController == null)
        {
            Debug.LogError("[MagicBookController] This should be a child of Player");
        }
    }

    private void Start()
    {
        _currentLevel = startingLevel;
        SetLevel(_currentLevel);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotatingSpeed * Time.deltaTime);
    }

    [ContextMenu("LevelUp")]
    public void LevelUp()
    {
        _currentLevel++;
        SetLevel(_currentLevel);
    }

    private void SetLevel(int level)
    {
        level = Mathf.Min(level, levelDataSO.levelData.Length - 1);

        var levelData = levelDataSO.levelData[level];
        SetNumberOfBooks(levelData.numberOfBooks);
        
        if(levelData.numberOfBooks > 0)
            foreach (var book in _currentDamageGivers)
                book.Damage = levelData.damage;
    }

    private void SetNumberOfBooks(int number)
    {
        if (_currentDamageGivers != null)
        {
            foreach(var damageGiver in _currentDamageGivers)
                Destroy(damageGiver.gameObject);
            _currentDamageGivers = null;
        }
        
        if (number <= 0)
            return;

        _currentDamageGivers = new MagicBookDamageGiver[number];
        for (int bookIndex = 0; bookIndex < number; bookIndex++)
        {
            var bookInstance = Instantiate(magicBookDamageGiverPrefab, transform);
            bookInstance.Init(_playerController);
            
            var rotationRadians = bookIndex * Mathf.PI * 2f / number;
            var bookPosition = new Vector2(
                Mathf.Sin(rotationRadians) * circleRadius,
                Mathf.Cos(rotationRadians) * circleRadius);
            bookInstance.transform.localPosition = bookPosition;

            _currentDamageGivers[bookIndex] = bookInstance;
        }
    }
}
