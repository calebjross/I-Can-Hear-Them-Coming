using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

[CreateAssetMenu(menuName = "Scriptable Objects/Vector Value")]
public class VectorValue : ScriptableObject
{
    public Vector2 initialPlayerPosition;

    //toilet position
    [SerializeField] private Vector2 baseInitialToiletPosition = new Vector2(16.46f, -7.66f);
    public Vector2 initialToiletPosition;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;

        initialToiletPosition = baseInitialToiletPosition;
    }

}
