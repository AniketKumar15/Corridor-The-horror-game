using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIght : MonoBehaviour
{
    

    public void lightStart()
    {
        AudioManager.instance.Play("Light");
        
    }
    public void lightStop()
    {
        AudioManager.instance.Stop("Light");
    }
}
