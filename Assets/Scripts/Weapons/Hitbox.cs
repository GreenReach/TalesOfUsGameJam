using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;
public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D collider;
    void Start()
    {
        
    }

    public void hit(int dmg){
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale/2, transform.rotation, LayerMask.GetMask("Default"));
 
        foreach(Collider collider in colliders)
        {
            collider.gameObject.GetComponent<IDamageable>().DoDamage(dmg);
            Debug.Log("aaa");
        }
    }
}
