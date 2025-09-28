using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject loseScreen;
    private bool screenShown;

    public void LoseScreen()
    {
        if (!screenShown)
        {
            screenShown = true;
            Time.timeScale = 0;
            loseScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        screenShown = false;
    }
}
