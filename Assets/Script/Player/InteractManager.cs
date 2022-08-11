using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    private bool opened = false;
    public Text interactText;

    [Header("Door")]
    private Animator anim;
    public bool isLocked = false;

    [Header("Light")]
    private Animator lightAnim;

    [Header("Keys")]

    public bool isPickUp = false;
    public GameObject keyHolder;

    public GameObject fire;

    void Update()
    {
        InteractText();

        //This will tell the player press F on the Keyboard.
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pressed();
            
        }

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
            
            // if raycast hits, then it checks if it hit an object with the tag Switch.
            if (hit.transform.tag == "Key")
            {
                interactText.text = "[F] Pick Up";
            }

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
                opened = !opened;

                if (isLocked == false)
                {
                    //This line will set the bool true or false so it will play the animation.
                    if (opened == true)
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
                opened = !opened;

                //This line will set the bool true or false so it will play the animation.
                if (opened == true)
                {
                    lightAnim.SetBool("CanOpen", true);
                    
                }

                else if (opened == false)
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

            if (hit.transform.tag=="Piller")
            {
                opened = true;

                if (opened==true)
                {
                    fire = hit.transform.GetChild(1).gameObject;
                    fire.SetActive(true);
                }
            }


        }
    }
}
