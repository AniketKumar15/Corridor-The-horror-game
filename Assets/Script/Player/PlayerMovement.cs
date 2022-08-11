using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>(); //Fetch the CharacterControlle from the GameObject with this script attached
    }

    private void FixedUpdate()
    {
        float x_moveMent = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float Z_moveMent = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        playerController.Move(transform.forward * Z_moveMent);
        playerController.Move(transform.right * x_moveMent);

        
    }
    private void Update()
    {
        footSteps();
    }

    void footSteps()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.instance.Play("footsteps");
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            AudioManager.instance.Stop("footsteps");
        }

    }

    
}
