using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private string firstLevelName = "GameLevel";
    [SerializeField]
    private SceneFader sceneFader = null;

    private void Start()
    {
        GameManager.isGameOver = false;
    }

    public void StartGame()
    {
        sceneFader.FadeTo(firstLevelName);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
