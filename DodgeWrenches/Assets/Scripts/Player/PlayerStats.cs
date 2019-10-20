using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static readonly string PLAYER_TAG = "Player";

    public int Health { get; set; }

    public delegate void PlayerHealthChanged();
    public event PlayerHealthChanged OnPlayerHealthChanged;

    [SerializeField]
    private int startingHealth = 2;
    [SerializeField]
    private GameObject mainCamera = null;

    private readonly int MAX_HEALTH = 4;
    private static CamShake camShake;

    private void Awake()
    {
        camShake = mainCamera.GetComponent<CamShake>();
        Health = startingHealth;
    }

    public void Heal(int amount)
    {
        // No more than max
        Health = (Health + amount >= MAX_HEALTH)
                ? MAX_HEALTH
                : Health + amount;
        
        OnPlayerHealthChanged?.Invoke();
    }

    public void Damage(int amount)
    {
        // no less than zero
        Health = (Health - amount < 0)
                ? 0
                : Health - amount;

        OnPlayerHealthChanged?.Invoke();

        camShake.Shake();
    }
}
