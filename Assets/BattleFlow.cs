using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFlow : MonoBehaviour
{
    bool isGameEnded = false;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public PlayerHealth playerHealth;
    public GameObject bgMusic;
    public EnemySpawner spawner;

    private void Start()
    {
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);

        playerHealth.onDead += OnGameOver;
    }

    private void Update()
    {
        if (!isGameEnded
            && spawner.isFinished
            && EnemyHealth.LivingEnemyCount <= 0)
        {
            isGameEnded = true;
            OnGameWin();
        }
    Debug.Log("EnemyCount = " + EnemyHealth.LivingEnemyCount);
Debug.Log("SpawnerFinished = " + spawner.isFinished);
}

    private void OnGameOver()
    {
        gameOverUI.SetActive(true);
        bgMusic.SetActive(false);
    }

    private void OnGameWin()
    {
        gameWinUI.SetActive(true);
        bgMusic.SetActive(false);

        if (playerHealth != null)
        {
            playerHealth.gameObject.SetActive(false);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}