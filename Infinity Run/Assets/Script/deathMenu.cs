using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class deathMenu : MonoBehaviour
{
    public Image BgImage;
    public Text scoreText;
    public bool shown = false;

    private float trans = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false); //Makes sure that the death menu is turned off when we start up game

    }

    // Update is called once per frame
    void Update()
    {
        if (!shown)
            return;

        trans += Time.deltaTime;
        BgImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, trans);
        
    }

    public void startEndMenu(float score) //function starts the End menu
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        shown = true;
    }
    public void tryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Restarting the Game Scene.
    }
    public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
