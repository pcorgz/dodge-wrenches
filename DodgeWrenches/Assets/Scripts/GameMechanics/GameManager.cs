using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;

    private void Start()
    {
        isGameOver = false;
    }

    private void Update()
    {
        if (PlayerStats.Health == 0)
        {
            isGameOver = true;

        }
    }
}
