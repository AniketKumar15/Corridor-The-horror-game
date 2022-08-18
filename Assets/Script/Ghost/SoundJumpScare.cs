using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundJumpScare : MonoBehaviour
{
    public AudioSource ScareSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="player")
        {
            ScareSound.Play();

        }
    }
}
