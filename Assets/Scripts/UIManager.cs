using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Image energy;
    public GameObject energyBar;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject pauseGameMenu;
    [SerializeField] private GameObject winGameMenu;
    public GameObject fightBoss;

    [SerializeField] private AudioManger audioManger;
    // Start is called before the first frame update
    void Start()
    {
        gameManager.currentEnergy = 0;
        UpdateEnergyBar();
        MainMenu();
    }

    public void UpdateEnergyBar()
    {
        if (energyBar != null)
        {
            float fillAmount = (float)gameManager.currentEnergy / (float)gameManager.energyThreshold;
            energy.fillAmount = fillAmount;
        }
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOver.SetActive(false);
        pauseGameMenu.SetActive(false);
        winGameMenu.SetActive(false);
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        mainMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        winGameMenu.SetActive(false);
        fightBoss.SetActive(false);
        Time.timeScale = 0;
    }
    /*public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        pauseGameMenu.SetActive(false);
        winGameMenu.SetActive(false);
        Time.timeScale = 0;
    }*/
    public void PauseGameMenu()
    {
        pauseGameMenu.SetActive(true);
        gameOver.SetActive(false);
        mainMenu.SetActive(false);
        winGameMenu.SetActive(false);
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        pauseGameMenu.SetActive(false);
        gameOver.SetActive(false);
        mainMenu.SetActive(false);
        winGameMenu.SetActive(false);
        Time.timeScale = 1;
        audioManger.PlayDefaultAudio();
    }
    public void CountinueGame()
    {
        pauseGameMenu.SetActive(false);
        gameOver.SetActive(false);
        mainMenu.SetActive(false);
        winGameMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackGameMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void WinGame()
    {
        winGameMenu.SetActive(true);
        pauseGameMenu.SetActive(false);
        gameOver.SetActive(false);
        mainMenu.SetActive(false);
        Time.timeScale = 0;
    }
}
