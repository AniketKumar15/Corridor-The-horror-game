using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject gameCompleted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="player")
        {
            gameCompleted.SetActive(true);

        }
    }


}
