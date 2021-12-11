using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class OpenDoor : MonoBehaviour
{

    #region Fields
    public bool isPlayerHasKey;
    public bool isDoorRequiresKey;

    public bool isTopDoor;
    public bool isHiddenRoom;
    bool isPlayerInRange;

    public Animator animator;

    public DoorState doorState;

    public GameObject keyToTheDoor;

    #endregion

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        if (doorState.doorHasBeenOpened == true)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Action") && isPlayerInRange == true)
        {

            if (CheckIfDoorCanBeOpened() == true)
            {
                doorState.doorHasBeenOpened = true;
                GameObject go = FindParentWithTag(gameObject, "Door");
                SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
                sr.enabled = false;
                BoxCollider2D bc2d = go.GetComponent<BoxCollider2D>();

                //fades the room in if the room is a hidden room
                if (isHiddenRoom == true)
                {
                    RevealRoom();
                }

                //if the door is on a horizontal plane, the box collider needs to adjust to allow entrance
                if (isTopDoor == true)
                {
                    bc2d.size = new Vector2(bc2d.size.x, 1.04f);
                }

                //if the edoor is on a vertical plane, the box collider needs to be deactivated
                if (isTopDoor == false)
                {
                    bc2d.enabled = false;
                }
            }
        }
    }

    public bool CheckIfDoorCanBeOpened()
    {
        OpenDoor od = GetComponent<OpenDoor>();
        if (od.isDoorRequiresKey == true && od.isPlayerHasKey == true)
        {
            return true;
        } else if (od.isDoorRequiresKey == false)
        {
            return true;
        }
        return false;
    }

    public static GameObject FindParentWithTag(GameObject childObject, string tag)
    {
        Transform t = childObject.transform;
        while (t.parent != null)
        {
            if (t.parent.tag == tag)
            {
                return t.parent.gameObject;
            }
            t = t.parent.transform;
        }
        return null; //Could not find a parent with the given tag
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }

    public void RevealRoom()
    {
        animator.SetBool("Door_opened", true);
        if (keyToTheDoor != null)
        {
            keyToTheDoor.GetComponent<KeyBehavior>().key.hasBeenUsed = true;
            keyToTheDoor.SetActive(false);
        }
    }
}
    #endregion
