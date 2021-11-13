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

    #endregion

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
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
        
        //determine if character should move
        if (change != Vector3.zero)
        {
            MoveCharacter();
        }
    }
    /// <summary>
    /// Move the Character
    /// </summary>
    void MoveCharacter()
    {
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
    #endregion
