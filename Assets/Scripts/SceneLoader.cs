using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float autoLoadNextLevelAfter;

    private void Start()
    {
        if (autoLoadNextLevelAfter > 0)
        {
            Invoke("LoadNextScene", autoLoadNextLevelAfter);
        }
        else
        {
            Debug.Log("Load auto level disabled - use a positive number in seconds");
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void LoadLevelOne()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(3);
    }


    public void LoadStart()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene((SceneManager.sceneCountInBuildSettings - 2));
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene((SceneManager.sceneCountInBuildSettings - 1));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
