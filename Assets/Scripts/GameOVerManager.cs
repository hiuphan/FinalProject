using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public void ShowGameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("GameOver UI is not assigned in the inspector!");
        }

        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    public void Quit()
    {
        Debug.Log("Quit button clicked!");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
