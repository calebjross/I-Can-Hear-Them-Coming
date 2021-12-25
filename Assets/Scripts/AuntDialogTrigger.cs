using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class AuntDialogTrigger : MonoBehaviour
{

    #region Fields
    PlayerMovement pm;
    public Animator animator;
    Rigidbody2D playerRigidBody;

    public GameObject auntTalkTrigger;

    public GameObject dialogBox;

    bool isDialogVisible;

    LevelChanger levelChanger;
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

        isDialogVisible = false;

        levelChanger = FindObjectOfType<LevelChanger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            auntTalkTrigger.GetComponent<AuntTalkScript>().isArrivedAtAunt = true;
            pm.enabled = false;
            animator.SetBool("moving", false);
            dialogBox.SetActive(true);
            isDialogVisible = true;
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (isDialogVisible == true && Input.GetButtonDown("Action") == true)
        {
            dialogBox.SetActive(false);
            levelChanger.FadeToLevel("outro");
        }
    }
}
    #endregion
