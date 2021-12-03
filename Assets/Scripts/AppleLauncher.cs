using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleLauncher : MonoBehaviour
{   
    public GameObject GoodApple;
    public GameObject BadApple;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchGoodApple", 1f, 1f);                     //Start regularily calling the functions that will start the apple-launching process
        InvokeRepeating("LaunchBadApple", 10f, 2f);
    }

    void LaunchGoodApple()
    {   
        StartCoroutine("GoodAppleTimer");       //start a coroutine to launch a good apple
    }

    void LaunchBadApple()
    {
        StartCoroutine("BadAppleTimer");        //start a coroutine to launch a bad apple
    }

    public IEnumerator GoodAppleTimer ()
    {
         float timeToLaunch = Random.Range(1, 8);      //wait for a random amount of seconds before launch to keep it from getting boring
        yield return new WaitForSeconds(timeToLaunch);
        Instantiate(GoodApple, transform.position, transform.rotation);     //launch good apple
    }

        public IEnumerator BadAppleTimer ()
    {
         float timeToLaunch = Random.Range(3, 10);      //wait for a random amount of seconds before launch to keep it from getting boring
        yield return new WaitForSeconds(timeToLaunch);
        Instantiate(BadApple, transform.position, transform.rotation);      //launch good apple
    }

}
