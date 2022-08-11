using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSen;
    public Transform player;

    float rot;

    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        

        float x = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;

        rot -= y;
        rot = Mathf.Clamp(rot, -80f, 80f);
        transform.localRotation = Quaternion.Euler(rot, 0f, 0f);
        player.Rotate(player.up * x);

    }
    

}
