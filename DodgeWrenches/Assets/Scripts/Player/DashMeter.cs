using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DashMeter : MonoBehaviour
{
    //public static Image DashMeterBar;

    [SerializeField]
    private Image dashMeterBar = null;
    [SerializeField]
    private GameObject dashMeterTextGO = null;

    private TextMeshProUGUI dashMeterText;

    private PlayerStats playerStats;

    private void Awake()
    {
        dashMeterText = dashMeterTextGO.GetComponent<TextMeshProUGUI>();
        playerStats = FindObjectOfType<PlayerStats>();
        playerStats.OnStatusChanged += ChangeMeter;
    }

    private void ChangeMeter()
    {
        switch (playerStats.Status)
        {
            case PlayerStats.PlayerStatus.Normal:
                dashMeterBar.color = new Color(1f, 1f, 0f);
                dashMeterText.fontStyle = FontStyles.Bold;
                break;

            case PlayerStats.PlayerStatus.Dashing:
                dashMeterBar.color = new Color(1f, 1f, 0f, 0.5f);
                dashMeterBar.transform.localScale = new Vector3(0f, 1f, 1f);
                break;

            case PlayerStats.PlayerStatus.Slowed:
                dashMeterBar.color = new Color(1f, 0f, 0f, 0.5f);
                dashMeterText.fontStyle = FontStyles.Bold | FontStyles.Strikethrough;
                break;

            default:
                break;
        }
    }

    private void LateUpdate()
    {
        if (dashMeterBar.transform.localScale.x < 1f)
        {
            dashMeterBar.transform.localScale +=
            new Vector3(Time.deltaTime / playerStats.ResetDashTime, 0f);

            if (dashMeterBar.transform.localScale.x >= 1)
                dashMeterBar.transform.localScale = Vector3.one;
        }
    }
}
