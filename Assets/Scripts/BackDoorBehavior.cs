using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class BackDoorBehavior : MonoBehaviour
{

    #region Fields
    SpriteRenderer sr;
    BoxCollider2D bc2d;

    bool isPlayerInRange;

    public DoorState doorState;

    #endregion

    #region Methods

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Action") && isPlayerInRange == true)
        {
            if (doorState.doorHasBeenOpened == false)
            {
                sr.enabled = false;
                doorState.doorHasBeenOpened = true;
                AudioManager.Play(AudioClipName.OpenDoor, 1f);
            }
        }
    }
}
    #endregion
