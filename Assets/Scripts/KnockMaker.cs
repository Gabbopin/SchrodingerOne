using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockMaker : MonoBehaviour
{
    public GameObject KnockSound;
    public bool Knocking;

    // Start is called before the first frame update
    void Start()
    {
        Knocking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Knocking == true){
            KnockSound.SetActive(true);

        }
        else if (Knocking == false)
        {
            KnockSound.SetActive(false);
        }
    }
}
