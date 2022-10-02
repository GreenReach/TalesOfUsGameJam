using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
public class ExperiencePickerController : MonoBehaviour
{

    public PlayerController playerController;
    public GameObject player;
    private void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "XP/Normal")
        {
            playerController.GetXP();
            Destroy(collision.gameObject);
        }
    }
}
