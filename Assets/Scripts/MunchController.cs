using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MunchController : MonoBehaviour
{   
    public Collider foodCollider;       //create a public collider variable, the collider of "kopfunten" needs to be attached here

    private int score = 0;

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

        if (Input.GetKeyDown(KeyCode.R))
		{
			ReloadingScene();
		}
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AppleGood")
        {
            score += 1;
            Debug.Log(score);
        }

        if (other.tag == "AppleBad")
        {
            score -= 3;
            Debug.Log(score);
            
        }
        if (score <= 0)
        {
            StartCoroutine("gameOver");
        }
    }
    
    void ReloadingScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator gameOver ()
    {
        Debug.Log("GAME OVER");
        yield return new WaitForSeconds(3);
        ReloadingScene();
    }
}
