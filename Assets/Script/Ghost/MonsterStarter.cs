using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStarter : MonoBehaviour
{
    public GameObject monster;
    public bool isStart = false;
    public PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        //it check is player here or not if player here then the Monster is coming
        if (other.gameObject.tag=="player")
        {
            if (isStart==true)
            {
                playerMovement.speed = 7f; // if monster is coming then the player speed will be increase
                monster.SetActive(true);
            }
            else
            {
                playerMovement.speed = 5f;  // if monster is gone then the player speed will be normal
                monster.SetActive(false);
            }
            
        }
    }
}
