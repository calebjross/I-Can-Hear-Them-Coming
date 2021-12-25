using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class KeyBehavior : MonoBehaviour
{

    #region Fields
    public itemState key;
    public GameObject doorTheKeyGoesTo;
    #endregion

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        if (key.hasBeenFound == true && key.hasBeenUsed == false)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (key.hasBeenFound == true)
        {
            doorTheKeyGoesTo.GetComponentInChildren<OpenDoor>().isPlayerHasKey = true;
        }
    }
}
    #endregion
