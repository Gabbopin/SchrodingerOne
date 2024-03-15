using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Fungus;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Vector2 movementInput;
    Rigidbody2D rb;

    public Fungus.Flowchart myFlowchart;

    //Sets the Ability to interact with objects
    //Should re-make into a integer store, not several bools
    public bool CanClick; //Fence
    public bool CanClickComp; //Home computer
    public bool CanClickComp2; // 2COMPUTER
    public bool CanClickComp3; //3Computer

    //Entry redesign
    public int Entry;

    //Stops movement + interaction while reading
    public bool isReading;

    //Pause Function
    public bool Paused;
    
    public GameObject PauseMenu;

    public GameObject Blanker;

    //Connecting to To-Do List
    public TextMeshProUGUI m_Object;

    public static string task1;
    public static string task2;
    public static string task3;
    public static string task4;
    public static string task5;

    //Tracking if Task is already done
    public bool Read1;
    public bool Read2;
    public bool Read3;
    public bool Read4;
    public bool Read5;

    //Task Counter
    public int TaskCount;
    public bool EndReady;
    //Timer

    //Event Tracker
    public bool knocker;


    public float moveSpeed = 2f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();

    public GameObject Fence;

    public Animator Animator;

    SpriteRenderer spriteRenderer;

    // For foosteps
    public StepManager Stepper;

    //For Ambience
    public AmbientRemote AmbienceRemote;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Entry = 0;
        CanClick = false;
        CanClickComp = false;
        CanClickComp2 = false;
        CanClickComp3 = false;
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isReading = false;
        Paused = false;

        //TODO LIST
        task1 = "Check Pressure";
        task2 = "Check Engine";
        task3 = "Check Printer";
        task4 = "Check Server";
        task5 = "Check Airlock";
        Read1 = false;
        Read2 = false;
        Read3 = false;
        Read4 = false;
        Read5 = false;

        TaskCount = 0;
        EndReady = false;

        //EventTracker
        knocker = false;

    }

    //Task Counter

    public void CountUp()
    {
        TaskCount = TaskCount + 1;
    }

    
    public void Knock()
    {
        if(knocker == true)
        {
            knocker = false;

        }else if(knocker == false)
        {
            knocker = true;
        }
    }


    public void OnBlank()
    {
        Blanker.SetActive(true);
    }

    public void NoBlank()
    {
        Blanker.SetActive(false);
    }

    //Setting up methods to call for Stopping movement

    public void ReadStart()
    {
        isReading = true;
        AmbienceRemote.IsAmbience = false;
        Debug.Log("Reading has Begun");
    }

    public void ReadReallyStart()
    {
        
    }

    public void ReadStop()
    {
        isReading = false;
        AmbienceRemote.IsAmbience = true;
        Debug.Log("Reading Stop");
    }

    public void ReadReallyStop()
    {
        
    }

    // PAUSE FUNCTION 
    public void OnMap()
    {
        if (Paused == true)
        {
            Resume();
        }
        else
        {
            Pause();
        }

        
    }

    void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Debug.Log("Resumed Game");
    }

    private void Pause()
    {
        if(isReading == false)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Paused = true;
            Debug.Log("Paused Game");
        }
        
    }
    public void Update()
    {
        if (Paused == false)
        {
            PauseMenu.SetActive(false);
        }
        else
        {
            if(isReading == false)
            {
                PauseMenu.SetActive(true);
            }
            
        }

        m_Object.text = ("To-Do: " + "\n" + "-" + task1 + "\n" + "-" + task2 + "\n" + "-" + task3 + "\n" + "-" + task4 + "\n" + "-" + task5);

        


    }


    //Check if Ending Criteria is met

    public void CheckEnd()
    {
        if (TaskCount >= 5 && EndReady == false)
        {
            Fungus.Flowchart.BroadcastFungusMessage("EndingGo");
            EndReady = true;
        }
    }


    //TODOLIST CHANGER

    public void TextChange()
    {
        if (Entry == 7)
        {
            task1 = "Completed";
            Read1 = true;
        }
        if (Entry == 10)
        {
            task2 = "Completed";
            Read2 = true;
        }
        if (Entry == 9)
        {
            task3 = "Completed";
            Read3 = true;
        }
        if (Entry == 11)
        {
            task4 = "Completed";
            Read4 = true;
        }
        if (Entry == 13)
        {
            task5 = "Completed";
            Read5 = true;
        }
    }
    

    public void OnInteract()
    {
        if (isReading == false)
        {
            Fence.GetComponent<FenceCollide>();
            if (Entry == 1)
            {

                Fungus.Flowchart.BroadcastFungusMessage("Activate Fence");
            }
            Fence.GetComponent<FenceCollide>();
            if (Entry == 2)
            {

                Fungus.Flowchart.BroadcastFungusMessage("HomeComputer");
            }
            if(Entry == 3)
            {

                Fungus.Flowchart.BroadcastFungusMessage("2Comp");
            }
            if (Entry == 4)
            {

                Fungus.Flowchart.BroadcastFungusMessage("3Comp");
            }
            if (Entry == 5)
            {
                Fungus.Flowchart.BroadcastFungusMessage("4Comp");
            }
            if (Entry == 6)
            {
                Fungus.Flowchart.BroadcastFungusMessage("NavComp");
            }
            if(Entry == 7)
            {
                if (Read1 == false)
                {
                    Fungus.Flowchart.BroadcastFungusMessage("PreComp");
                }
                
            }
            if (Entry == 8)
            {
                Fungus.Flowchart.BroadcastFungusMessage("LivComp");
            }
            if (Entry == 9)
            {
                
                if (Read3 == false)
                {
                    Fungus.Flowchart.BroadcastFungusMessage("PriComp");
                }
                else if (EndReady == true)
                {
                    Fungus.Flowchart.BroadcastFungusMessage("EndingGoFR");
                }


            }
            if (Entry == 10)
            {
                if (Read2 == false)
                {
                    Fungus.Flowchart.BroadcastFungusMessage("EngComp");
                }


            }
            if (Entry == 11)
            {
                
                if (Read4 == false)
                {
                    Fungus.Flowchart.BroadcastFungusMessage("SerComp");
                }


            }
            if (Entry == 12)
            {
                Fungus.Flowchart.BroadcastFungusMessage("StoComp");
            }
            if (Entry == 13)
            {
                
                if (Read5 == false)
                {
                    Fungus.Flowchart.BroadcastFungusMessage("DoorComp");
                }


            }
            if (Entry == 14)
            {
                Fungus.Flowchart.BroadcastFungusMessage("ClarkeBed");
                
            }
            if (Entry == 15)
            {
                Fungus.Flowchart.BroadcastFungusMessage("Chair");
            }
            if (Entry == 16)
            {
                
            }
        }
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.tag == "Fence") { 
            //Allows Interaction with Fence
            Entry = 1; Debug.Log("Hit trigger");
            }
        if (other.tag == "HomeComputer")
        {
            //Allows Interaction with Fence
            Entry = 2; Debug.Log("Hit Computer");
        }
        if (other.tag == "2Comp")
        {
            Entry = 3;
        }
        if (other.tag == "3Comp")
        {
            Entry = 4; Debug.Log("Computer 3");
        }
        if (other.tag == "4Comp")
        {
            Entry = 5; 
        }
        if (other.tag == "NavComp")
        {
            Entry = 6;
        }
        if (other.tag == "PreComp")
        {
            Entry = 7;
            

        }
        if(other.tag == "LivComp")
        {
            Entry = 8;
        }
        if (other.tag == "PriComp")
        {
            Entry = 9;
        }
        if (other.tag == "EngComp")
        {
            Entry = 10;
        }
        if (other.tag == "SerComp")
        {
            Entry = 11;
        }
        if (other.tag == "StoComp")
        {
            Entry = 12;
        }
        if (other.tag == "DoorComp")
        {
            Entry = 13;
        }
        if (other.tag == "ClarkeBed")
        {
            Entry = 14;
        }
        if(other.tag == "Chair")
        {
            Entry = 15;
        }
        if (other.tag == "Knock")
        {
            if (knocker == true)
            {
                Fungus.Flowchart.BroadcastFungusMessage("Knock");
            }
        }
    }


    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        Entry = 0;
    }

    void ExitSpace()
    {
        Entry = 0;
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Fence")
        {
            CanClick = true;
            Debug.Log("Hit");
        }
    }





    private void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero && isReading == false)
        {
            bool success = TryMove(movementInput);

            if(!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
                

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                    
                }
            }

            Animator.SetBool("IdleSwitch", success);
            



        }
        else
        {
            Animator.SetBool("IdleSwitch", false);
            Stepper.Stepping = false;
        }
        //Access Direction

        if (movementInput.x < 0 && isReading == false)
        {
            spriteRenderer.flipX = true;
            Animator.SetInteger("State", 1);
        }
        else if (movementInput.x > 0 && isReading == false)
        {
            spriteRenderer.flipX = false;
            Animator.SetInteger("State", 1);
        }
        

        if (movementInput.y < 0 && isReading == false)
        {
            Animator.SetInteger("State", 0);
        }
        else if (movementInput.y > 0 && isReading == false)
        {
            Animator.SetInteger("State", 2);
        }
    }





    private bool TryMove (Vector2 direction)
        {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollision,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if (count == 0 && isReading == false)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                Stepper.Stepping = true;
                return true;
            }
            else
            {
                Stepper.Stepping = false;
                return false;
            }
        }
        else
        {
            Stepper.Stepping = false;
            return false;
        }
            
        }
}

