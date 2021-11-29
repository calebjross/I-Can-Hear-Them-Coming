using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class OpenDoor : MonoBehaviour
{

    #region Fields
    public bool isDoorCanBeOpened;
    public bool isTopDoor;

    #endregion

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        isDoorCanBeOpened = false;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (isDoorCanBeOpened == true)
        {
            if (Input.GetButtonDown("Action") && isDoorCanBeOpened == true)
            {
                GameObject go = FindParentWithTag(gameObject, "Door");
                SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
                sr.enabled = false;
                BoxCollider2D bc2d = go.GetComponent<BoxCollider2D>();

                //if the door is on a horizontal plane, the box collider needs to adjust to allow entrance
                if (isTopDoor == true)
                {
                    bc2d.size = new Vector2(bc2d.size.x, 1.04f);
                }

                //if th edoor is on a vertical plane, the box collider needs to be deactivated
                if (isTopDoor == false)
                {
                    bc2d.enabled = false;
                }
            }
        }
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
            isDoorCanBeOpened = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isDoorCanBeOpened = false;
        }
    }
}
    #endregion
