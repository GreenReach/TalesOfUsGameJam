using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using Weapons.MagicBook;

public class MagicBookController : MonoBehaviour
{
    [SerializeField] private int numberOfBooks = 1;
    [SerializeField] private float rotatingSpeed = 90f;
    [SerializeField] private float circleRadius = 1.5f;
    [SerializeField] private MagicBookDamageGiver magicBookDamageGiverPrefab;

    private PlayerController _playerController;
    private MagicBookDamageGiver[] _currentDamageGivers;

    private void OnEnable()
    {
        _playerController = GetComponentInParent<PlayerController>();
        if (_playerController == null)
        {
            Debug.LogError("[MagicBookController] This should be a child of Player");
        }
        
        SetNumberOfBooks(numberOfBooks);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotatingSpeed * Time.deltaTime);
    }

    public void SetNumberOfBooks(int number)
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
