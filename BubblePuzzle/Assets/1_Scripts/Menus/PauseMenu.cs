using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Not implemented

    [SerializeField] GameObject pauseItems;
    private bool isPaused = false;
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isPaused = true;

        pauseItems.SetActive(true);
    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPaused = false;

        pauseItems.SetActive(false);
    }
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        if (isPaused == false && Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        if (isPaused == true && Input.GetKeyDown(KeyCode.K))
        {
            ResumeGame();
        }
    }
}
