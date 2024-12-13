using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI killCountText;
    [SerializeField] private GameObject endGameScreen;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthBar.value = (float)currentHealth / maxHealth;
    }

    public void UpdateKillCount(int killCount)
    {
        killCountText.text = $"Kills: {killCount}";
    }

    public void ShowEndGameScreen(bool playerWon)
    {
        Debug.Log("game finished");
        endGameScreen.SetActive(true);
        endGameScreen.GetComponentInChildren<TextMeshProUGUI>().text = playerWon ? "You Win!" : "You Dieded";
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
