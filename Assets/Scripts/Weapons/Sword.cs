using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Sword : GeneralWeapon
{
    public GameObject target;
    public float start =45;
    public float finish=135;
    public int dir = 1;
    public float timer = 0;
    public Direction direction = Direction.Right;
    public bool first = true;
    float angle;
    public bool stop = false;
    public List<Direction> dire= new List<Direction>();
    void Start()
    {
        transform.position = new Vector3(target.transform.position.x + 1.5f, target.transform.position.y, 0);
        checkDir();
        angle = start;
        transform.RotateAround(target.transform.position, Vector3.forward, angle);
    }


    void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        if (angle >= finish && timer < 0)
        {
            dir = -1;
            stop = true;
            timer = 100;
            checkDir();
            angle = finish;
            transform.position = new Vector3(target.transform.position.x + 1.5f, target.transform.position.y, 0);
            transform.rotation = Quaternion.identity;
            transform.RotateAround(target.transform.position, Vector3.forward, finish);
            //transform.RotateAround(target.transform.position, Vector3.forward, 180);
            //transform.RotateAround(target.transform.position, Vector3.forward, 225);
            //transform.RotateAround(target.transform.position, Vector3.forward, angle);
        }
        if (angle <= start && timer < 0)
        {
            dir = +1;
            if(first){
                first = false;
            }else{
                stop = true;
                timer = 100;
                checkDir();
                angle = start;
                transform.position = new Vector3(target.transform.position.x + 1.5f, target.transform.position.y, 0);
                transform.rotation = Quaternion.identity;
                transform.RotateAround(target.transform.position, Vector3.forward, start);
            }
        }
        timer -= Time.deltaTime * 20;
        if(timer < 0){
            angle += 20 * Time.deltaTime * dir;
            transform.RotateAround(target.transform.position, Vector3.forward, 20 * Time.deltaTime * dir);
        }
    }

    void checkDir(){
        switch (direction)
        {   
            case Direction.Up:
                            start = 45;
                            finish = 135;
                            break; 
            case Direction.Left:
                            start = 135;
                            finish = 225;
                            break;
            case Direction.Down:
                            start = 225;
                            finish = 315;
                            break;
            case Direction.Right:
                            start = 315;
                            finish = 405;
                            break;

            default: start = 45;
                            finish = 135;
                            break;
        }
    }


}
