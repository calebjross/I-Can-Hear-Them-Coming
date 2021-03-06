using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>

public class CameraMovement : MonoBehaviour
{

    #region Fields

    public Transform target;
    public float smoothing;

    //set camera clamp limits
    public Vector2 maxPosition;
    public Vector2 minPosition;

    public VectorValue cameraPosition;


    #endregion

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Awake()
    {
        //set the position of the camera to the player at the start of the scene
        if (target != null)
        {
            transform.position = cameraPosition.initialCameraPosition;
        }

        smoothing = 0.1f;
    }

    void LateUpdate()
    {
        if (target != null)
        {

            if (transform.position != target.position)
            {
                Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

                targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
                targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

                if (Vector3.Distance(targetPosition, transform.position) >= 0.05f)
                {
                    transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
                }
                else transform.position = targetPosition;
            }
        }
    }
}
    #endregion
