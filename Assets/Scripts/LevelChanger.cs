using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>

public class LevelChanger : MonoBehaviour
{

    #region Fields

    #endregion
    public Animator animator;

    private string levelToLoadName;

    #region Properties

    #endregion

    #region Methods

    public void FadeToLevel(string sceneName)
    {
        levelToLoadName = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoadName);

    }

    public void Update()
    {
        if (Input.GetButtonDown("Action") && SceneManager.GetActiveScene().buildIndex == 0)
        {
            FadeToLevel("house-exterior");
        }
    }
}
    #endregion
