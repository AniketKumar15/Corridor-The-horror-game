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
        if (other.gameObject.tag=="player")
        {
            if (isStart==true)
            {
                playerMovement.speed = 7f;
                monster.SetActive(true);
            }
            else
            {
                playerMovement.speed = 5f;
                monster.SetActive(false);
            }
            
        }
    }
}
