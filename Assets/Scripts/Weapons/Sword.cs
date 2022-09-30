using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : GeneralWeapon
{
    public GameObject target;
    public float start =45;
    public float finish=135;
    public int dir = 0;
    float angle;
    void Start()
    {
        angle = start;
        transform.RotateAround(target.transform.position, Vector3.forward, angle);
    }


    void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        angle += 20 * Time.deltaTime * dir;
        if (angle >= finish)
        {
            dir = -1;
            Debug.Log(transform.rotation.z);
        }
        if (angle <= start)
        {
            dir = +1;
        }
        transform.RotateAround(target.transform.position, Vector3.forward, 20 * Time.deltaTime * dir);
    }

}
