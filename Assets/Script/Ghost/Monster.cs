using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject gameOver;

    private void Start()
    {
        gameOver.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="player")
        {
            gameOver.SetActive(true);
        }
    }

}
