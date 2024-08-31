using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public Text yourScoreText;
    public GameObject ScoreObject;
    public GameObject gameOverScreen;
    public GameObject Gold;
    public GameObject Silver;
    public GameObject Bronze;
    public GameObject pauseMenu;
    public bool isPaused=false;

    AudioManager audioManager;

    public void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    { 
        pauseMenu.SetActive(false);
        UpdateHighScoreText();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int i){
        playerScore=playerScore+i;
        scoreText.text= playerScore.ToString();
        UpdateYourScoreText();
    }
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.P))
       {
            if(isPaused)
            {
                ResumeGame();
            }
            else if(!(isPaused))
            {
                PauseGame();
            }
       }
    }
    public void PauseGame()
    {
        audioManager.PauseSFX(audioManager.pause);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused=true;
    }
    public void ResumeGame()
    {
        audioManager.ResumeSFX(audioManager.pause);

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused=false;
    }
    public void CheckScore()
    {
        if (playerScore>PlayerPrefs.GetInt("HighScore",0))
        {
            
            PlayerPrefs.SetInt("HighScore",playerScore);
            UpdateHighScoreText();
        }
     
        gameOverScreen.SetActive(true);
        ScoreObject.SetActive(false);
    }
    void UpdateHighScoreText()
    {
        highScoreText.text = $"High Score {PlayerPrefs.GetInt("HighScore", 0)}";
    }
    void UpdateYourScoreText()
    {
        yourScoreText.text = "Your Score " + playerScore.ToString();;
    }
    public void UpdateMedal()
    {

        if (playerScore >= 1 && playerScore <= 5)
        {
           Bronze.SetActive(true); 
        }
        else if (playerScore >= 6 && playerScore <= 10)
        {
            Silver.SetActive(true);
        }
        else if (playerScore > 10)
        {
            Gold.SetActive(true);
        }
    }
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void gameOver(){
        gameOverScreen.SetActive(true);
        ScoreObject.SetActive(false);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
