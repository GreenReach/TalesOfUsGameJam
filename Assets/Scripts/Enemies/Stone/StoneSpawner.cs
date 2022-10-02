using System;
using Commons;
using Player;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Enemies.Stone
{
    public class StoneSpawner : MonoBehaviour
    {
        public UnityEvent<StoneController> onStoneDestroyed;
        
        [SerializeField] private StoneController stonePrefab;
        [SerializeField] private float maxPlayerDistance = 20f;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private ObjectiveIndicator indicator;

        private StoneController _stoneInstance;
        private int _currentStoneLevel;

        private void Awake()
        {
            FillDependencies();
        }

        private void Start()
        {
            InstantiateNextStone();
        }

        private void StoneDestroyedHandler(StoneController stone)
        {
            onStoneDestroyed?.Invoke(stone);
            InstantiateNextStone();
        }

        private void InstantiateNextStone()
        {
            var stonePosition = playerController.transform.position + new Vector3(
                Random.Range(-maxPlayerDistance, maxPlayerDistance),
                Random.Range(-maxPlayerDistance, maxPlayerDistance));
            
            _stoneInstance = Instantiate(stonePrefab, stonePosition, Quaternion.identity, transform);
            _stoneInstance.SetLevel(_currentStoneLevel);
            _currentStoneLevel++;

            if(indicator != null)
                indicator.SetTarget(_stoneInstance.transform);
            
            _stoneInstance.OnStoneDestroyed += StoneDestroyedHandler;
        }

        private void FillDependencies()
        {
            playerController = playerController == null ? playerController : FindObjectOfType<PlayerController>();
        }
    }
}