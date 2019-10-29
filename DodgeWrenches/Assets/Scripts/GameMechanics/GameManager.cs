﻿using System;
using System.Collections;
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
    [SerializeField]
    private Animator playerAnimator = null;

    private PlayerStats playerStats;
    public static float timePlayed;
    private TextMeshProUGUI timePlayedTextUGUI;

    private void Awake()
    {
        Pool.ResetPools();
        playerStats = FindObjectOfType<PlayerStats>();
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
        if (playerStats.Health == 0 && isGameOver == false)
        {
            playerAnimator.SetTrigger("isDead");
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
        AudioManager.instance.Stop("GameMusic");
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        AudioManager.instance.Stop("GameMusic");
        sceneFader.FadeTo(menuSceneName);
    }

    public static IEnumerator DisableGameObject(GameObject gameObject, float timeUntilDeactivate = 2f)
    {
        yield return new WaitForSeconds(timeUntilDeactivate);

        gameObject.SetActive(false);
    }

}
