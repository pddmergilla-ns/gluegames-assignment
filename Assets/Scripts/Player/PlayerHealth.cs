using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameManager gameManager;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        uiManager.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        uiManager.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            var player = GetComponent<PlayerController>();
            player.PlayerDiedEffect();
            player.gameObject.SetActive(false);
            gameManager.PlayerDied();
        }
    }
}
