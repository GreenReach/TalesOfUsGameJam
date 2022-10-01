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
        public float delay1;

        public void Init(EnemyBase target, int delay)
        {
            delay1 = delay*0.1f;
            transform.SetParent(null);
            _target = target;
            _direction = (target.transform.position - transform.position).normalized;
            Destroy(gameObject, timeUntilDestroy);
        }

        private void Update()
        {
            if(delay1 < 0){
                transform.position += _direction * speed * Time.deltaTime;
                check();
            }
            delay1 -= Time.deltaTime;
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
