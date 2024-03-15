using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceCollide : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool FenceHit;

    void Start()
    {
        FenceHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        FenceHit = true;
        Debug.Log("Fence has been Touched");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
