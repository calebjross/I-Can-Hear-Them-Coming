using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class AuntTalkScript : MonoBehaviour
{

    PlayerMovement pm;
    public Animator animator;
    Timer idleTimer;
    Rigidbody2D playerRigidBody;

    bool isArrivedAtAunt;

    private void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        playerRigidBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        isArrivedAtAunt = false;

        //configure idle timer
        idleTimer = gameObject.AddComponent<Timer>();
        idleTimer.Duration = 1f;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pm.enabled = false;
            animator.SetBool("moving", false);
            idleTimer.Run();
            pm.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (other.tag == "Aunt")
        {
            isArrivedAtAunt = true;
            //queue dialog exchange
        }
    }

    private void Update()
    {
        if (idleTimer.Finished && isArrivedAtAunt == false)
        {
            pm.transform.GetChild(0).gameObject.SetActive(false);
            animator.SetBool("moving", true);
            animator.speed = 0.75f;
            float moveSpeed = 4;
            playerRigidBody.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}
