using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimePlayedText : MonoBehaviour
{
    [SerializeField]
    private GameObject timePlayedTextMeshPro = null;

    private TextMeshProUGUI timePlayedText = null;

    private void Awake()
    {
        timePlayedText = timePlayedTextMeshPro.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var time = TimeSpan.FromSeconds(GameManager.timePlayed);

        timePlayedText.text = time.ToString(@"hh\:mm\:ss\.fff");
    }
}
