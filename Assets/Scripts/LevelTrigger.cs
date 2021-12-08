using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>

public class LevelTrigger : MonoBehaviour
{
    public string levelToLoadName;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    LevelChanger levelChanger;

    #region Fields

    #endregion

    #region Properties

    #endregion

    #region Methods

    private void Start()
    {
        levelChanger = FindObjectOfType<LevelChanger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialPlayerPosition = playerPosition;
            levelChanger.FadeToLevel(levelToLoadName);
            
        }
    }
}
    #endregion
