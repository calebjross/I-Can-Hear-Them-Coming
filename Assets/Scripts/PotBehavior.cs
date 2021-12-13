using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class PotBehavior : MonoBehaviour
{

    #region Fields
    GameObject[] notes;

    Light2D light2D;

    [SerializeField]
    bool isPlayerInRange;

    public GameObject key;

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

        notes = GameObject.FindGameObjectsWithTag("Readable Paper");
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (Input.GetButtonDown("Action") && isPlayerInRange == true && key.GetComponent<KeyBehavior>().key.hasBeenFound == false)
        {
            //prevent the key from being found again
            key.GetComponent<KeyBehavior>().key.hasBeenFound = true;
            light2D.enabled = false;

            //enable the key image in the UI
            key.GetComponent<Image>().enabled = true;

            //allow the door to be unlocked
            key.GetComponent<KeyBehavior>().doorTheKeyGoesTo.GetComponentInChildren<OpenDoor>().isPlayerHasKey = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "Kitchen Pot")
            {
                //check all letters to see if the related clue letter has been read
                for (int i = 0; i < notes.Length; i++)
                {
                    int ln = notes[i].GetComponent<PaperBehavior>().letterNumber;
                    bool read = notes[i].GetComponent<PaperBehavior>().isRead;

                    //if the related clue letter has been read, then allow the pot to be interacted with
                    if (ln == 5 && read == true && key.GetComponent<KeyBehavior>().key.hasBeenFound == false)
                    {
                        isPlayerInRange = true;
                        light2D.enabled = true;
                    }
                }
            } else if (key.GetComponent<KeyBehavior>().key.hasBeenFound == false)
            {
                isPlayerInRange = true;
                light2D.enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            light2D.enabled = false;
        }
    }
}
    #endregion
