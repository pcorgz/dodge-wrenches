using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> heartsList = null;

    private PlayerStats playerStats;
    private List<GameObject> HeartsList;

    private void Awake()
    {
        HeartsList = heartsList;
        playerStats = FindObjectOfType<PlayerStats>();
        playerStats.OnPlayerHealthChanged += UpdateHearts;
    }

    private void Start()
    {
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        HeartsList.ForEach(h => h.SetActive(false));
        for (int i = 0; i < playerStats.Health; i++)
        {
            HeartsList[i].SetActive(true);
        }
    }
}
