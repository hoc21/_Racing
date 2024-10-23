using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseOn;
    [SerializeField] private GameObject resumeGame;
    [SerializeField] private GameObject startGame;
    [SerializeField] private GameObject optionsGame;
    [SerializeField] private GameObject quitGame;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        pauseOn.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseOn.SetActive(false);
        Time.timeScale = 1f;
    }
    public void StartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void OptionsGame()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
