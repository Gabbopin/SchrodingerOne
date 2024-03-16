using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{

    public GameObject Footstepper;
    public AudioSource Footsteps;

    public bool Stepping;


    // Start is called before the first frame update
    void Start()
    {
        Footsteps = GetComponent<AudioSource>();
        Footstepper.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stepping == true )
        {
            Footstepper.SetActive(true);

        }
        else
        {
            
            Footstepper.SetActive(false);
            
            
        }
    }
}
