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
    public bool disabled = true;
    public float damageBoost = 1;
    public int arrowNumber = 1;
    private RobertGameManager Robert;
    public int currentLevel = 0;
    void Start()
    {
        damage = 5;
        weaponCooldowns = 2f;
        weaponlvl = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkLevelUp();
        if(!disabled){
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
            for(int i = 1; i <= arrowNumber; i++){
                LaunchProjectileAt(tMin, i-1);
            }
        return tMin;
    }

    private void LaunchProjectileAt(EnemyBase target, int i)
    {
        
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);
            projectile.transform.right = projectile.transform.position - target.transform.position;
            projectile.Init(target, i);
    }

    public void LevelUp(){
        currentLevel++;
    }

    public void checkLevelUp(){
        switch (currentLevel)
        {
            case 0:
                    disabled = true;
                    break;
            case 1:
                    disabled = false;
                    break;
            case 2:
                    damageBoost = 1.25f;
                    break;
            case 3:
                    arrowNumber = 2;
                    break;
            case 4:
                    damageBoost = 1.75f;
                    break;
            case 5:
                    arrowNumber = 3;
                    break;
            default:
                    break;
        }
    }
}
