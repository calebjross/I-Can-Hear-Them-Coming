using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

[CreateAssetMenu(menuName = "Scriptable Objects/Item State")]
public class itemState : ScriptableObject
{
    //Editor value
    [SerializeField] private bool baseHasBeenFound = false;

    //Internal variables
    public bool hasBeenFound;
    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;

        hasBeenFound = baseHasBeenFound;
    }
}
