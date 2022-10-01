using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;
using Enemies.Types;
public class RangeBow : GeneralWeapon
{
    // Start is called before the first frame update
    [SerializeField] private Arrow projectilePrefab;
    public GameObject target;
    public float timer = 0;
    public bool first = true;
    public bool stop = false;
    void Start()
    {
        damage = 5;
        weaponCooldowns = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop){
            closestEnemy();
            timer = weaponCooldowns; 
            stop = true;   
        }
        if(timer < 0){
            stop = false;
        }
        timer -= Time.deltaTime;
    }
    
    EnemyBase closestEnemy(){
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale, transform.rotation, LayerMask.GetMask("Default"));
        EnemyBase tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach(Collider collider in colliders)
        {
            float dist = Vector3.Distance(collider.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = collider.gameObject.GetComponent<EnemyBase>();
                minDist = dist;
            }
        }
        if(tMin != null)
            LaunchProjectileAt(tMin);
        return tMin;
    }

    private void LaunchProjectileAt(EnemyBase target)
    {
        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);
        projectile.transform.right = projectile.transform.position - target.transform.position;
        projectile.Init(target);
    }
}
