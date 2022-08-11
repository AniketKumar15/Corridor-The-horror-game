using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorManager : MonoBehaviour
{
    public GameObject corridor01;
    public GameObject closeDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "player")
        {
            corridor01.SetActive(false);
            closeDoor.SetActive(true);

        }
    }
}
