using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class PlayerSpawnController : MonoBehaviour
{
    #region Fields
    [HideInInspector]
    public string spawnPointNameString;
    Transform spawnPointTransform;
    #endregion

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        if (spawnPointNameString != null)
        {
            spawnPointTransform = GameObject.Find(spawnPointNameString).transform;
            gameObject.transform.position = spawnPointTransform.position;
        }
    }
}
    #endregion
