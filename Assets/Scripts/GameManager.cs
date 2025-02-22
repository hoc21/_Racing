using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : SingletonBehavior<GameManager>
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseOn;
    [SerializeField] private GameObject resumeGame;
    [SerializeField] private GameObject quitGame;

   
    private void Start()
    {
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
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
