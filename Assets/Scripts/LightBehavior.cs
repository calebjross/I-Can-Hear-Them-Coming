using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

/// <summary>
/// 
/// </summary>

public class LightBehavior : MonoBehaviour
{

    #region Fields
    Light2D light2D;

    [Range(0.001f,.01f)]
    [SerializeField]
    float growSpeed; //adjusts the speed at which the glow expands outward
    bool isGrowing; //indicates if the glow is expanding (true) or shrinking (false)
    [SerializeField]
    float growStart; //the initial size of the glow outer radius
    [SerializeField]
    float growStop; //indicates when the glow outer radius should stop expanding


    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        //access components for efficiency
        light2D = GetComponent<Light2D>();

        growSpeed = Random.Range(0.003f, 0.009f);

        isGrowing = true;

        growStart = light2D.pointLightOuterRadius;
        growStop = light2D.pointLightOuterRadius + 2f;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        GrowAndShrink();
    }

    /// <summary>
    /// Controls the growing and shrinking of the flame outer radius
    /// </summary>
    void GrowAndShrink()
    {
        if (isGrowing == true)
        {
            light2D.pointLightOuterRadius += growSpeed;
            if (light2D.pointLightOuterRadius > growStop)
            {
                isGrowing = false;
            }
        }

        if (isGrowing == false)
        {
            light2D.pointLightOuterRadius -= growSpeed;
            if (light2D.pointLightOuterRadius < growStart)
            {
                isGrowing = true;
            }
        }
    }
}
    #endregion
