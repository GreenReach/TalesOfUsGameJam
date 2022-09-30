using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Sword : GeneralWeapon
{
    public GameObject target;
    public float timer = 0;
    public bool first = true;
    public bool stop = false;
    void Start()
    {
        damage = 5;
        weaponCooldowns = 1.5f;
    }

    void Update()
    {
        if(!stop){
            hit();
            timer = weaponCooldowns; 
            stop = true;   
        }
        if(timer < 0){
            stop = false;
        }
        timer -= Time.deltaTime;
    }

    void hit(){
        switch (target.gameObject.GetComponent<PlayerController>().Direction)
        {   
            case GameStructures.Direction.Right:
                            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Hitbox>().hit(damage);
                            this.gameObject.transform.GetChild(4).gameObject.GetComponent<Animation>().Play("HitBoxRight");
                            break;
            case GameStructures.Direction.Up:
                            this.gameObject.transform.GetChild(1).gameObject.GetComponent<Hitbox>().hit(damage);
                            this.gameObject.transform.GetChild(4).gameObject.GetComponent<Animation>().Play("HitBoxUp");
                            break; 
            case GameStructures.Direction.Left:
                            this.gameObject.transform.GetChild(2).gameObject.GetComponent<Hitbox>().hit(damage);
                            this.gameObject.transform.GetChild(4).gameObject.GetComponent<Animation>().Play("HitBoxLeft");
                            break;
            case GameStructures.Direction.Down:
                            this.gameObject.transform.GetChild(3).gameObject.GetComponent<Hitbox>().hit(damage);
                            this.gameObject.transform.GetChild(4).gameObject.GetComponent<Animation>().Play("HitBoxDown");
                            break;
            default: 
                            break;
        }
    }

}
