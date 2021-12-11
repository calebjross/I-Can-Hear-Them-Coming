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
    [SerializeField] private bool baseHasBeenUsed = false;

    //Internal variables
    public bool hasBeenFound;
    public bool hasBeenUsed;
    private void OnEnable()
    {
        hasBeenFound = baseHasBeenFound;
        hasBeenUsed = baseHasBeenUsed;

        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}
