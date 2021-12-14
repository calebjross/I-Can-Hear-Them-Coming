using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class ToiletBehavior : MonoBehaviour
{

    #region Fields
    GameObject[] notes;

    Light2D light2D;

    bool isPlayerInRange;
    bool isToiletMoving;

    public VectorValue toiletPosition;

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

        transform.localPosition = toiletPosition.initialToiletPosition;  //sets the toilet position to the Vector2 stored in the scriptable object
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (Input.GetButtonDown("Action") && isPlayerInRange == true)
        {
            isToiletMoving = true;            
        }

        if (isToiletMoving == true)
        {
            //moves the toilet
            transform.Translate(Vector3.right * 0.2f * Time.deltaTime);
            toiletPosition.initialToiletPosition = new Vector2(17.6f, transform.localPosition.y);
        }

        //stops the toilet when it's moved to a specific spot
        if (transform.localPosition.x >= 17.6f)
        {
            //holds the final position of the toilet
            transform.localPosition = new Vector2(17.6f,transform.localPosition.y);

            //sets the Vector2 stored in the scriptable object to the final position of the toilet
            isToiletMoving = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //check all letters to see if the related clue letter has been read
            for (int i = 0; i < notes.Length; i++)
            {
                int ln = notes[i].GetComponent<PaperBehavior>().letterNumber;
                bool read = notes[i].GetComponent<PaperBehavior>().isRead;

                //if the related clue letter has been read, then allow the pot to be interacted with
                if (ln == 6 && read == true)
                {
                    isPlayerInRange = true;
                    light2D.enabled = true;
                }
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
