using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;
using Enemies.Types;
public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 10f;
        [SerializeField] private float timeUntilDestroy = 5f;
        [SerializeField] private int damage = 3;
        
        private EnemyBase _target;
        private Vector3 _direction;

        public void Init(EnemyBase target)
        {
            transform.SetParent(null);
            _target = target;
            _direction = (target.transform.position - transform.position).normalized;
            Destroy(gameObject, timeUntilDestroy);
        }

        private void Update()
        {
            transform.position += _direction * speed * Time.deltaTime;
            check();
        }

        private void check()
        {
            Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale/2, transform.rotation, LayerMask.GetMask("Default"));
            foreach(Collider collider in colliders)
            {
                if(collider.gameObject.GetComponent<IDamageable>() != null){
                    collider.gameObject.GetComponent<IDamageable>().DoDamage(damage);
                    Destroy(gameObject);
                }
            }
        }
}
