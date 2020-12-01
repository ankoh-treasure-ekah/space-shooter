using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text currentScore;
    public int score;
    public GameObject startMenu;

    void Start()
    {

        score = 0;
    }
   
    
    
    public void updateLives(int currentLife)

    {
        //get current lives from player
        //update life based on what the player gives us
        //lets try to start with one life
        //to display our lives to the game we need to access the sprites in the lives variable array
        livesImageDisplay.sprite = lives[currentLife];
    }

    public void updateScore()
    {
        //similar we need to update score when enemy dies 
        //soo lets start by accessing the text

        score += 10;

        currentScore.text = "Score: " + score; 

    }

    public void hideTitleScreen()
    {

        startMenu.SetActive(false);
        currentScore.text = "Score: " + 0;
    }

    public void showTitleScreen()
    {

        startMenu.SetActive(true);
        score = 0;

    }
}
