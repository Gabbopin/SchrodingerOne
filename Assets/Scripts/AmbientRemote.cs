using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientRemote : MonoBehaviour
{
    public GameObject Ambience;
    public AudioSource AmbienceOne;

    public bool IsAmbience;

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
    }
}
