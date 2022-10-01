using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;
using System;
public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void hit(float dmg, int number, int range){
        Collider[] colliders;
        if(range == 2){
            switch(number){
                case 1:
                    colliders = Physics.OverlapBox(transform.position + new Vector3(0.25f, 0, 0), transform.localScale * 1.5f, transform.rotation, LayerMask.GetMask("Default")); 
                    break;
                case 2:
                    colliders = Physics.OverlapBox(transform.position + new Vector3(0, 0.25f, 0), transform.localScale * 1.5f, transform.rotation, LayerMask.GetMask("Default")); 
                    break;
                case 3:
                    colliders = Physics.OverlapBox(transform.position + new Vector3(-0.25f, 0, 0), transform.localScale * 1.5f, transform.rotation, LayerMask.GetMask("Default")); 
                    break;
                case 4:
                    colliders = Physics.OverlapBox(transform.position + new Vector3(0, -0.25f, 0), transform.localScale * 1.5f, transform.rotation, LayerMask.GetMask("Default")); 
                    break;
                default:
                    colliders = Physics.OverlapBox(transform.position + new Vector3(0.25f, 0, 0), transform.localScale * 1.5f, transform.rotation, LayerMask.GetMask("Default")); 
                    break;            
            }
        }else   
            colliders = Physics.OverlapBox(transform.position , transform.localScale , transform.rotation, LayerMask.GetMask("Default"));    
 
        foreach(Collider collider in colliders)
        {
            if(collider.gameObject.GetComponent<IDamageable>() != null){
                collider.gameObject.GetComponent<IDamageable>().DoDamage((int)dmg);
            }
        }
    }
}
