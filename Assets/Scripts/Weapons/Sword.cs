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
    public float damageBoost = 1;
    public int range = 1;
    public int currentLevel = 1;
    void Start()
    {
        damage = 5;
        weaponCooldowns = 1.5f;
    }

    public void LevelUp(){
        currentLevel++;
    }

    void Update()
    {
        checkLevelUp();
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
        if (!GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play();

        switch (target.gameObject.GetComponent<PlayerController>().Direction)
        {   
            case GameStructures.Direction.Right:
                            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Hitbox>().hit(damage * damageBoost * target.transform.GetComponent<PlayerController>().DamageModifier, 1, range);
                            this.gameObject.transform.GetChild(4).gameObject.GetComponent<Animation>().Play("HitBoxRight");
                            break;
            case GameStructures.Direction.Up:
                            this.gameObject.transform.GetChild(1).gameObject.GetComponent<Hitbox>().hit(damage * damageBoost * target.transform.GetComponent<PlayerController>().DamageModifier, 2, range);
                            this.gameObject.transform.GetChild(4).gameObject.GetComponent<Animation>().Play("HitBoxUp");
                            break; 
            case GameStructures.Direction.Left:
                            this.gameObject.transform.GetChild(2).gameObject.GetComponent<Hitbox>().hit(damage * damageBoost * target.transform.GetComponent<PlayerController>().DamageModifier, 3, range);
                            this.gameObject.transform.GetChild(4).gameObject.GetComponent<Animation>().Play("HitBoxLeft");
                            break;
            case GameStructures.Direction.Down:
                            this.gameObject.transform.GetChild(3).gameObject.GetComponent<Hitbox>().hit(damage * damageBoost * target.transform.GetComponent<PlayerController>().DamageModifier, 4, range);
                            this.gameObject.transform.GetChild(4).gameObject.GetComponent<Animation>().Play("HitBoxDown");
                            break;
            default: 
                            break;
        }
    }

    public void checkLevelUp(){
        switch (currentLevel)
        {
            case 2:
                    damageBoost = 1.25f;
                    break;
            case 3:
                    range = 2;
                    break;
            case 4:
                    damageBoost = 1.75f;
                    break;
            case 5:
                    weaponCooldowns = 1f;
                    break;
            default:
                    break;
        }
    }

}
