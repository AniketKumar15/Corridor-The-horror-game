using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    private bool checker = false;
    public Text interactText;

    [Header("Door")]
    private Animator anim;
    public bool isLocked = false;

    [Header("Light")]
    private Animator lightAnim;

    [Header("Keys")]

    public GameObject keyHolder;

    public GameObject fire;

    [Header("piller")]
    public bool isFireBurn = false;
    public Animator keyPillerAnimation;
    

    void Update()
    {

        InteractText();

        //This will tell the player press F on the Keyboard.
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pressed();
            
        }

        KeyPiller();
    }
    void InteractText()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit hit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, MaxDistance))
        {

            // if raycast hits, then it checks if it hit an object with the tag Door.
            if (hit.transform.tag == "Door")
            {
                if (isLocked == false)
                {
                    interactText.text = "[F] Open/Close"; 
                }
                else
                {
                    interactText.text = "Door Is Locked";
                }
                
            }
            
            // if raycast hits, then it checks if it hit an object with the tag Switch.
            if (hit.transform.tag == "Switch")
            {
                interactText.text = "[F] On/Off";
            }
            
            // if raycast hits, then it checks if it hit an object with the tag Key.
            if (hit.transform.tag == "Key")
            {
                interactText.text = "[F] Pick Up";
            }
            // if raycast hits, then it checks if it hit an object with the tag Piller.
            if (hit.transform.tag == "Piller")
            {
                interactText.text = "[F] to burn fire";
            }

            if (hit.transform.tag == "NonText")
            {
                interactText.text = "";

            }


        }

    }

    void Pressed()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit hit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, MaxDistance))
        {

            // if raycast hits, then it checks if it hit an object with the tag Door.
            if (hit.transform.tag == "Door")
            {

                //This line will get the Animator from  Parent of the door that was hit by the raycast.
                anim = hit.transform.GetComponentInParent<Animator>();

                //This will set the bool the opposite of what it is.
                checker = !checker;

                if (isLocked == false)
                {
                    //This line will set the bool true or false so it will play the animation.
                    if (checker == true)
                    {
                        anim.SetBool("CanOpen", true);
                        AudioManager.instance.Play("Door");
                        
                        GameObject key = keyHolder.transform.GetChild(0).gameObject; //Get key in the KeyHolder gameobject.
                        Destroy(key); //Destory key after door is unlock.
                        isLocked = true;

                    }
                    else
                    {
                        anim.SetBool("CanOpen", false);
                        AudioManager.instance.Play("Door");
                    }
                }
                

            }
            // if raycast hits, then it checks if it hit an object with the tag Switch.
            if (hit.transform.tag == "Switch")
            {

                //This line will get the Animator from Children of the Switch that was hit by the raycast.
                lightAnim = hit.transform.GetComponentInChildren<Animator>();

                //This will set the bool the opposite of what it is.
                checker = !checker;

                //This line will set the bool true or false so it will play the animation.
                if (checker == true)
                {
                    lightAnim.SetBool("CanOpen", true);
                    
                }

                else if (checker == false)
                {
                    lightAnim.SetBool("CanOpen", false);
                   
                }
                   

            }
            // if raycast hits, then it checks if it hit an object with the tag Switch.
            if (hit.transform.tag == "Key")
            {
                //Make key child of Keyholder gameobject.
                hit.transform.parent = PlayerCamera.GetChild(0).transform;
                hit.transform.localPosition = Vector3.zero;
                hit.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
                hit.transform.localScale = new Vector3(5f, 5f, 5f);

                //Check is key is pickUp Or Not, if pickUp then the door is unlock.
                if (hit.transform.parent == PlayerCamera.GetChild(0).transform)
                {
                    isLocked = false;
                }
                else
                {
                    isLocked = true;
                }

            }
            // if raycast hits, then it checks if it hit an object with the tag Piller.
            if (hit.transform.tag=="Piller")
            {
                checker = true;

                if (checker==true) //If Checker is true, then the fire is burn
                {
                    fire = hit.transform.GetChild(1).gameObject; //This line will get the Fire GameObject from Children of the Piller that was hit by the raycast.
                    fire.SetActive(true); 
                    isFireBurn = true;
                    AudioManager.instance.Play("Danger");
                }
            }


        }
    }

    void KeyPiller()
    {
        if (isFireBurn == true) //If fire is burn, then the key piller move upWard and the player is able to get key
        {
            keyPillerAnimation.SetTrigger("keyPiller");
        }
    }
}
