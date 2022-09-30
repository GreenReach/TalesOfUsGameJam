using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyProjectile : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float timeUntilDestroy = 5f;
        [SerializeField] private int damage = 3;
        
        private PlayerController _target;
        private Vector3 _direction;

        public void Init(PlayerController target)
        {
            _target = target;
            _direction = (target.transform.position - transform.position).normalized;
            Destroy(gameObject, timeUntilDestroy);
        }

        private void Update()
        {
            transform.position += _direction * speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log($"Hit: {col.name}");
            var player = col.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}