using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostJumpScare : MonoBehaviour
{
    public GameObject ghost;
    public float speed = 5;
    bool isplayer = false;
    public bool isForward = false;

    private void Update()
    {
        if (isplayer == true)
        {
            if (isForward == false)
            {
                ghost.transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
                Destroy(ghost, 2f);
                Destroy(this.gameObject, 2f);
            }
            else if (isForward == true)
            {
                ghost.transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
                Destroy(ghost, 2f);
                Destroy(this.gameObject, 2f);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            AudioManager.instance.Play("JumpScare");
            isplayer = true;
        }
    }
}
