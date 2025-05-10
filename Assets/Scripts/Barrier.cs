using UnityEngine;

public class Barrier : MonoBehaviour
{
    private Player player;
    private GameOverManager gameOverManager;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        gameOverManager = GameObject.FindObjectOfType<GameOverManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.Die(); // Player dies, triggers Game Over

            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySound("GameOver"); // Play Game Over sound
            }
            else
            {
                Debug.LogWarning("AudioManager instance not found.");
            }

            // Show the Game Over screen
            if (gameOverManager != null)
            {
                gameOverManager.ShowGameOver();
            }
            else
            {
                Debug.LogWarning("GameOverManager not found.");
            }
        }
    }
}
