using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class PlayerMovement : MonoBehaviour
{

    #region Fields
    public float speed;

    Rigidbody2D myRigidBody;

    Vector3 change; //holds the change based on input axis

    public Animator animator;

    public VectorValue startingPosition;

    #endregion

    #region Methods

    private void Awake()
    {

    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        transform.position = startingPosition.initialValue;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        change = Vector3.zero;

        //read player input
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();

    }

    void UpdateAnimationAndMove()
    {
        //determine if character should move
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    /// <summary>
    /// Move the Character
    /// </summary>
    void MoveCharacter()
    {
        myRigidBody.MovePosition(transform.position + change.normalized * speed * Time.fixedDeltaTime);
    }
}
    #endregion
