using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static readonly string PLAYER_TAG = "Player";
    public static int Health;

    [SerializeField]
    private int startingHealth = 2;

    private void Start()
    {
        Health = startingHealth;
        HeartsUI.UpdateHearts();
    }

    public static void Heal(int amount)
    {
        Health = (Health + amount >= 4)
                ? 4
                : Health + amount;
        HeartsUI.UpdateHearts();
    }

    public static void Damage(int damage)
    {
        // Avoids negative numbers
        Health = (Health - damage >= 0)
                ? Health - damage
                : 0;
        HeartsUI.UpdateHearts();
    }
}
