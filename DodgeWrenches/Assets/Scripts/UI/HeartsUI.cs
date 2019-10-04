using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> heartsList = null;

    private static List<GameObject> HeartsList;

    private void Awake()
    {
        HeartsList = heartsList;
    }

    public static void UpdateHearts()
    {
        HeartsList.ForEach(h => h.SetActive(false));
        for (int i = 0; i < PlayerStats.Health; i++)
        {
            HeartsList[i].SetActive(true);
        }
    }
}
