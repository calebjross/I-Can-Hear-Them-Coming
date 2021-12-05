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

    bool isArrivedAtBlood;

    Timer idleTimer;
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
        idleTimer.Duration = 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pm.enabled = false;
            animator.SetBool("moving", false);
            idleTimer.Run();
        }
    }

    private void Update()
    {
        if (idleTimer.Finished && isArrivedAtBlood == false)
        {
            animator.SetBool("moving", true);
            animator.speed = 5;
            float moveSpeed = 7;
            playerRigidBody.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (playerRigidBody.transform.position.x <= -7.85)
        {
            isArrivedAtBlood = true;
            pm.enabled = true;
            animator.speed = 1;
        }

    }
}
    #endregion
