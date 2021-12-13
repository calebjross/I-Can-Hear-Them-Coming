using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class BloodFound : MonoBehaviour
{

    #region Fields
    PlayerMovement pm;
    public Animator animator;
    Rigidbody2D playerRigidBody;

    public bool isArrivedAtBlood;

    Timer idleTimer;
    Timer bloodWaitTimer;

    public GameObject dialogbox;

    public itemState bloodTriggerHasBeenTriggered;

    #endregion

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        playerRigidBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        isArrivedAtBlood = false;

        //configure idle timer
        idleTimer = gameObject.AddComponent<Timer>();
        bloodWaitTimer = gameObject.AddComponent<Timer>();
        idleTimer.Duration = 0.5f;
        bloodWaitTimer.Duration = 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && bloodTriggerHasBeenTriggered.hasBeenUsed == false)
        {
            pm.enabled = false;
            animator.SetBool("moving", false);
            idleTimer.Run();
            pm.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (idleTimer.Finished && isArrivedAtBlood == false)
        {
            pm.transform.GetChild(0).gameObject.SetActive(false);
            animator.SetBool("moving", true);
            animator.speed = 1.5f;
            float moveSpeed = 6;
            playerRigidBody.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (bloodWaitTimer.Finished && isArrivedAtBlood == true)
        {
            pm.enabled = true;
            pm.speed = 5;
            animator.SetBool("moving", true);

            if (Input.GetButtonDown("Action")==true || Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") != 0)
            {
                
                dialogbox.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && bloodTriggerHasBeenTriggered.hasBeenUsed == false)
        {
            isArrivedAtBlood = true;
            animator.SetBool("moving", false);
            bloodWaitTimer.Run();
            dialogbox.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
            bloodTriggerHasBeenTriggered.hasBeenUsed = true;
        }
    }
}
    #endregion
