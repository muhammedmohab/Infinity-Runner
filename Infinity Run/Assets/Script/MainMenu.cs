using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text HighscoreText;
    private void Start()
    {
        HighscoreText.text = ((int)PlayerPrefs.GetFloat ("Highscore")).ToString();
    }
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
