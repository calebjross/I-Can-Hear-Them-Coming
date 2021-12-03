using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 
/// </summary>

public class TutorialBehavior : MonoBehaviour
{

    #region Fields

    #endregion

    TextMeshProUGUI text;

    float elapsedTime;
    float timerAlarm;
    bool isTriggered;

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        elapsedTime = 0.0f;
        timerAlarm = 4f;
        isTriggered = false;
        text = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log(elapsedTime);

        Debug.Log(elapsedTime);

        if (elapsedTime >= timerAlarm && isTriggered == false)
        {
            isTriggered = true;
            text.enabled = true;
        }
    }
}
    #endregion
