using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public enum PlayerStatus
    {
        Normal = 1,
        Dashing,
        Slowed
    }

    public static readonly string PLAYER_TAG = "Player";

    public PlayerStatus Status { get; set; }
    public float MoveSpeed { get; set; }
    public bool CanDash { get; set; }
    public int Health { get; set; }
    public float ResetDashTime { get; set; }

    public Action OnStatusChanged;
    public Action OnPlayerHealthChanged;

    [SerializeField]
    public float initialMoveSpeed = 8f;
    [SerializeField]
    private int startingHealth = 2;
    [SerializeField]
    private float initialResetDashTime = 3f;
    [SerializeField]
    private GameObject mainCamera = null;

    private readonly int MAX_HEALTH = 4;
    private static CamShake camShake;

    private void Awake()
    {
        Status = PlayerStatus.Normal;
        camShake = mainCamera.GetComponent<CamShake>();
        MoveSpeed = initialMoveSpeed;
        CanDash = true;
        Health = startingHealth;
        ResetDashTime = initialResetDashTime;
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

    public void SetDashStatus()
    {
        Status = PlayerStatus.Dashing;
        OnStatusChanged?.Invoke();
    }

    public void SetNormalStatus()
    {
        Status = PlayerStatus.Normal;
        OnStatusChanged?.Invoke();
    }

    public void SlowDown(float slowFactor, float seconds)
    {
        Status = PlayerStatus.Slowed;
        OnStatusChanged?.Invoke();

        float speed = initialMoveSpeed * slowFactor;

        StartCoroutine(ChangeSpeed(speed, seconds));
    }

    private IEnumerator ChangeSpeed(float speed, float seconds)
    {
        MoveSpeed = speed;
        yield return new WaitForSeconds(seconds);

        MoveSpeed = initialMoveSpeed;
        Status = PlayerStatus.Normal;
        OnStatusChanged?.Invoke();
    }
}
