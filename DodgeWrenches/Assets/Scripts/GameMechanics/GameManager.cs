using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;

    [SerializeField]
    private GameObject gameOverScreen = null;

    private void Start()
    {
        isGameOver = false;
    }

    private void Update()
    {
        if (PlayerStats.Health == 0)
        {
            isGameOver = true;
            gameOverScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        //SceneManager.LoadScene(0);
        Debug.Log("Go To Menu");
    }
}
