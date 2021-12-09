using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MunchController : MonoBehaviour
{   
    public Collider foodCollider;       //create a public collider variable, the collider of "kopfunten" needs to be attached here

    //create a variable for the score & highScore
    private int score = 0;
    private int highscore = 0;
    // assign UI fields and GameObjects for scores
    public TextMeshProUGUI score_UI;
    public TextMeshProUGUI highscore_UI;
    private GameObject highScore_Object;

    // assign UI fields of gameover screen objects
    public GameObject[] gameOverObjects;
    public TextMeshProUGUI gameOverHighScore_UI;

    // Start is called before the first frame update
    void Start()
    {
        // change UI placeholder text to current score
        score_UI.text = score.ToString();
        // hide highscore until score and highscore are different
        highScore_Object = GameObject.Find("HighScore");
        highScore_Object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))        //while space is held down, the collider defined above is activated, otherwise deactivated
        {
            foodCollider.enabled = true;
        }
        else
        {
            foodCollider.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.R))        //if R is pressed, the scene reloads again through a reloading-method (see below)
		{
			ReloadingScene();
		}
    }

    public void OnTriggerEnter(Collider other)      //if an apple enters the foodCollider while it is active:
    {
        if (other.tag == "AppleGood")       //the script checks if the apple is good or bad, if it is good, one point is added to the score
        {
            score += 1;
            score_UI.text = score.ToString();
        }

        else if (other.tag == "AppleBad")        //if it is bad, 5 points are substracted from the score
        {
            score -= 5;
            score_UI.text = score.ToString();

            //if the score drops to or below zero, the game is over and the scene restarts again via a coroutine to give the player some time to think about their mistake
            //this happens inside the bad-apple-is-eaten loop to stop the game from being over before the first apple is eaten
            //this happened before, because the score starts with zero
            if (score <= 0) {
                StartCoroutine("gameOver");
            }
        }

        // match highscore to score if highscore is lower and refresh UI
        if (highscore < score) {
            highscore = score;
            highscore_UI.text = "(Best: " + highscore.ToString() + ")";
        }
        // additionally, only display UI when score is lower and highscore GameObject is inactive 
        else if (score < highscore && !highScore_Object.activeInHierarchy) {
            highScore_Object.SetActive(true);
        }
    }
    
    void ReloadingScene()       //this is the method to reload the scene if the refresh-key ("R") is pressed, as mentioned above
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator gameOver ()      //this is the coroutine to reload the scene if the game is lost
    {
        Debug.Log("GAME OVER");
        // assigned GameOver UI Elements will be activated
        for (int i = 0; i < gameOverObjects.Length; i++) {
            gameOverObjects[i].SetActive(true);
        }
        gameOverHighScore_UI.text = "Your highest score was " + highscore + "!";


        yield return new WaitForSeconds(5);
        ReloadingScene();
    }
}
