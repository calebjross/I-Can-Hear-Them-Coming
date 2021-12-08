using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

[CreateAssetMenu(menuName = "Scriptable Objects/Door State")]
public class DoorState : ScriptableObject
{
    //Editor value
    [SerializeField] private bool baseDoorHasBeenOpened = false;

    //internal variables
    public bool doorHasBeenOpened;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;

        doorHasBeenOpened = baseDoorHasBeenOpened;
    }

}
