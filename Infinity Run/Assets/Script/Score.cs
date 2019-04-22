using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private float score = 0.0f;
    private int defLevel = 1;
    private int maxLevel = 10;
    private int scoreToNextLevel = 10;
    private bool isDead = false;

    public Text scoreText;
    public Text highScoreText;
    public Text coinText;
    public deathMenu DeathMenu;

    void Start()
    {
        highScoreText.text = ((int) PlayerPrefs.GetFloat("Highscore")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if(score >= scoreToNextLevel)
        {
            levelUp ();
        }
        score += Time.deltaTime * defLevel;
        //casing float to int
        scoreText.text = ((int)score).ToString();
        coinText.text = (GetComponent<PlayerMovement>().coins).ToString();
    }

    void levelUp()
    {
        if(defLevel == maxLevel)
        {
            //do nothing
            return;
        }
        scoreToNextLevel *= 2;
        defLevel++;
        //Calling the setSpeed function from PlayerMovement.cs
        //using GetComponent sence they are on the same object.
        GetComponent<PlayerMovement>().setSpeed(defLevel);
    }
    public void onDeath()
    {
        isDead = true;
        //Saving the highscore into the reg.
        if(PlayerPrefs.GetFloat("Highscore") < score)
            PlayerPrefs.SetFloat("Highscore",score);

        DeathMenu.startEndMenu(score);
    }
    public void addScore(int coins)
    {
        score += coins;
    }
}
