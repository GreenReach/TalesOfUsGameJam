using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;
using System;
public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D collider;
    void Start()
    {
        
    }

    public void hit(float dmg, int range){
        Collider[] colliders;
        if(range == 2)
            colliders = Physics.OverlapBox(transform.position + new Vector3(range, range, 0), transform.localScale/2 * Math.Abs(range), transform.rotation, LayerMask.GetMask("Default"));
        else   
            colliders = Physics.OverlapBox(transform.position , transform.localScale/2 , transform.rotation, LayerMask.GetMask("Default"));    
 
        foreach(Collider collider in colliders)
        {
            if(collider.gameObject.GetComponent<IDamageable>() != null){
                collider.gameObject.GetComponent<IDamageable>().DoDamage((int)dmg);
            }
        }
    }
}
