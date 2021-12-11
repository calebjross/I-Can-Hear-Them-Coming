using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Maintains player inventory and UI between scenes
/// </summary>

public class SceneState: MonoBehaviour
{

    #region Fields
    public itemState bedroomKey;
    public itemState bathroomKey;

    //reference to the keys
    GameObject bathKey;
    GameObject bedKey;
    #endregion

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        bathKey = GameObject.Find("Bathroom Key");
        bathKey = GameObject.Find("Bedroom Key");



    }
}
    #endregion
