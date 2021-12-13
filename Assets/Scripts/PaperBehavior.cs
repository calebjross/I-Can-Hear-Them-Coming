using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 
/// </summary>

public class PaperBehavior : MonoBehaviour
{

    #region Fields
    Light2D light2D;

    //Dialog box references
    bool isPlayerInRange;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    private string dialog;
    public int letterNumber; //use the inspector to assign an int identifer which will be referenced when assigning text below

    //indicates that the note has been read by the player
    public bool isRead;

    #endregion

    #region Properties

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        //access components for efficiency
        light2D = GetComponent<Light2D>();
        light2D.enabled = false;

        //deactivates the dialog box for switching scenes
        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
        }

        isRead = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            light2D.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            light2D.enabled = false;
        }

        //deactivates the dialog box when the player leaves the trigger area
        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Action") && isPlayerInRange == true)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            } else
            {
                dialogBox.SetActive(true);
                GetLetterText();
                dialogText.text = dialog;
                isRead = true;
            }
        }
    }

    void GetLetterText()
    {
        switch (letterNumber)
        {
            case 1:
                dialog = "I cannot succumb. I won't succumb.";
                break;
            case 2:
                dialog = "Max, if you are reading this, that means I’ve gone into hiding." +
                    " I can hear them at the door. Find me.";
                break;
            case 3:
                dialog = "Use as emergency toilet paper.";
                break;
            case 4:
                dialog = "Use as emergency regular paper.";
                break;
            case 5:
                dialog = "To do: \n" +
                    "1. Throw away the bad chili from last night. It tastes like metal. \n" +
                    "2. Find the bathroom key...very soon. Even bad chili still does chili stuff. \n" +
                    "3. Buy new pants";
                break;
            case 6:
                dialog = "Secret Yakuza Casino/Homeless Camp Entrance behind toilet. Do not flush.";
                break;
            case 7:
                dialog = "They are here.";
                break;
            case 8:
                dialog = "This way to the basement";
                break;
            case 9:
                dialog = "If you are reading this, I might be gone already.";
                break;
            case 10:
                dialog = "If you are reading this, I might be (cough) out of cough drops.";
                break;
            case 11:
                dialog = "Please hurry. They won't leave until they taken what they want.";
                break;
            case 12:
                dialog = "Sorry about all these notes on the floor. I can't find my tape.";
                break;
            case 13:
                dialog = "I found my tape!";
                break;
            case 14:
                dialog = "WET PAINT";
                break;
            case 15:
                dialog = "Chili Pot and/or Key Container Storage Hall";
                break;
            default:
                dialog = "There is no text for this letter";
                break;
        }
    }
}
    #endregion
