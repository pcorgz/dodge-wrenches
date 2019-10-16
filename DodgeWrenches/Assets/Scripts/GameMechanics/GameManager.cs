using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;

    [SerializeField]
    private GameObject gameOverScreen = null;
    [SerializeField]
    private SceneFader sceneFader = null;
    [SerializeField]
    private string menuSceneName = "MainMenu";
    [SerializeField]
    private GameObject timePlayedText = null;

    public static float timePlayed;
    private TextMeshProUGUI timePlayedTextUGUI;

    private void Awake()
    {
        timePlayedTextUGUI = timePlayedText.GetComponent<TextMeshProUGUI>();

        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        FindObjectOfType<AudioManager>().Play("GameMusic");
    }

    private void Start()
    {
        isGameOver = false;
        timePlayed = 0;
    }

    private void Update()
    {
        if (PlayerStats.Health == 0)
        {
            var time = TimeSpan.FromSeconds(timePlayed);
            timePlayedTextUGUI.text = time.ToString(@"hh\:mm\:ss\.fff");

            isGameOver = true;
            gameOverScreen.SetActive(true);
        }

        if (isGameOver == false)
        {
            timePlayed += Time.deltaTime;
        }
    }

    public void Restart()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
        //SceneManager.LoadScene(0);
    }
}
