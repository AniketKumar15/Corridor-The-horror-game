using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autowalk : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public bool isAutoWalk = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="player")
        {
            if (isAutoWalk == true)
            {
                playerMovement.AutoWalk = true;
            }
            else
            {
                playerMovement.AutoWalk = false;
            }
            

        }
    }
}
