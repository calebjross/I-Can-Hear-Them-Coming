using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class GameManager : MonoBehaviour
{

    #region Fields

    #endregion

    #region Properties

    #endregion

    #region Methods


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }
    }
}
    #endregion
