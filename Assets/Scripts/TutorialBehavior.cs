using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class TutorialBehavior : MonoBehaviour
{

    #region Fields

    #endregion

    TextMeshProUGUI text;
    TextMeshProUGUI letterText;
    Image letterImage;

    Timer tutorialTimer;

    bool isFading;
    bool isReadyToAdvance;
    bool fadeOut;
    bool fadeInComplete;

    Color imageColor;

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        //get and set the tutorial text alpha
        text = GetComponent<TextMeshProUGUI>();
        text.alpha = 0f;

        //get and set the letter text alpha
        letterText = GameObject.Find("Letter Text").GetComponent<TextMeshProUGUI>();
        letterText.alpha = 0f;

        //get and set the letter image alpha
        letterImage = GameObject.Find("Letter").GetComponent<Image>();
        imageColor = letterImage.color;
        imageColor.a = 0f;

        //create and set the letter read timer that prompts to display the tutorial text
        tutorialTimer = gameObject.AddComponent<Timer>();
        tutorialTimer.Duration = 4;
        tutorialTimer.Run();

        //controls various fades
        fadeOut = false;
        fadeInComplete = false;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //fade in the letter text and the letter image
        if (fadeInComplete == false)
        {
            letterText.alpha += .05f;

            imageColor.a += .05f;
            letterImage.color = imageColor;

            if (letterText.alpha >= 1f)
            {
                letterText.alpha = 1f;
                imageColor.a = 1f;
                fadeInComplete = true;
            }
        }

        //messages when the timer has finished
        if (tutorialTimer.Finished && fadeOut == false)
        {
            isFading = true;
        }

        //fade in the tutorial text
        if (isFading == true)
        {
            text.alpha += .2f;
            if (text.alpha >= 1f)
            {
                text.alpha = 1f;
                isFading = false;
                isReadyToAdvance = true;
            }
        }

        if (Input.GetButtonDown("Action") && isReadyToAdvance == true)
        {
            fadeOut = true;
        }

        if (fadeOut == true)
        {
            text.alpha -= .05f;
            letterText.alpha -= .05f;
            imageColor.a -= .05f;
            letterImage.color = imageColor;
        }
    }
}
    #endregion
