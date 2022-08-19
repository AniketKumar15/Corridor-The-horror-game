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
        footStepsStart();
        FootStepsStop();
        
    }
    //If player press the these button then footstep sound start
    void footStepsStart()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.instance.Play("footsteps");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.instance.Play("footsteps");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManager.instance.Play("footsteps");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.instance.Play("footsteps");
        }

    }
    //If player leave these button then the footstep sound stop
    void FootStepsStop()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            AudioManager.instance.Stop("footsteps");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            AudioManager.instance.Stop("footsteps");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            AudioManager.instance.Stop("footsteps");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            AudioManager.instance.Stop("footsteps");
        }
    }
    
}
