using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MunchController : MonoBehaviour
{   
    public Collider foodCollider;       //create a public collider variable, the collider of "kopfunten" needs to be attached here

    private int score = 0;      //create a variable fpr the score

    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log(score);
        }

        if (other.tag == "AppleBad")        //if it is bad, 5 points are substracted from the score
        {
            score -= 5;
            Debug.Log(score);

        if (score <= 0)     //if the score drops to or below zero, the game is over and the scene restarts again via a coroutine to give the player some time to think about their mistake
                                        //this happens inside the bad-apple-is-eaten loop to stop the game from being over before the first apple is eaten
                                        //this happened before, because the score starts with zero
        {
            StartCoroutine("gameOver");
        }
            
        }

    }
    
    void ReloadingScene()       //this is the method to reload the scene if the refresh-key ("R") is pressed, as mentioned above
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator gameOver ()      //this is the coroutine to reload the scene if the game is lost
    {
        Debug.Log("GAME OVER");
        yield return new WaitForSeconds(3);
        ReloadingScene();
    }
}
