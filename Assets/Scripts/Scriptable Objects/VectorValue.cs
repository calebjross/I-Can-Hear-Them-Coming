using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>

[CreateAssetMenu(menuName = "Scriptable Objects/Vector Value")]
public class VectorValue : ScriptableObject
{
    //player position
    private Vector2 baseInitialPlayerPosition = new Vector2(14f, -11.4f);
    public Vector2 initialPlayerPosition;

    //toilet position
    private Vector2 baseInitialToiletPosition = new Vector2(16.46f, -7.66f);
    public Vector2 initialToiletPosition;

    //camera position
    public Vector3 initialCameraPosition;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;

        //reset toilet position
        initialToiletPosition = baseInitialToiletPosition;

        //set player position for scene 1
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            initialPlayerPosition = baseInitialPlayerPosition;
            initialCameraPosition = new Vector3(10.18f,-8.87f, -10f);
        }
    }

}
