using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientRemote : MonoBehaviour
{
    public GameObject Ambience;
    public AudioSource AmbienceOne;

    public bool IsAmbience;
    public bool ShouldAmbient;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAmbience == true)
        {
            Ambience.SetActive(true);
        }
        else
        {
            Ambience.SetActive(false);
        }


        //This isn't necesary, but it makes sense to me.

        if (ShouldAmbient == true)
        {
            
        }
        else
        {
            
        }


    }


    public void AmbienceLeverOn()
    {
        IsAmbience = true;
    }
    public void AmbienceLeverOff()
    {
        IsAmbience = false;
    }
}
