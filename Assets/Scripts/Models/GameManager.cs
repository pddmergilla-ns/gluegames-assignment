using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int enemiesKilled;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerController player;
    [SerializeField] private int ScoreToWin;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        uiManager.UpdateKillCount(enemiesKilled);
        if (enemiesKilled >= ScoreToWin)
        {
            EndGame(true);
        }
    }

    public void PlayerDied()
    {
        EndGame(false);
    }

    private void EndGame(bool playerWon)
    {
        player.gameObject.SetActive(false);
        uiManager.ShowEndGameScreen(playerWon);
    }
}
