using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleLauncher : MonoBehaviour
{   
    public Vector3 bugPosition;     //position of the bug will be used to determine launch-direction of apples
    public GameObject GoodApple;
    public GameObject BadApple;

    // Start is called before the first frame update
    void Start()
    {
        bugPosition = GameObject.Find("Kaefer").transform.position;     //bugPosition is assigned the value of the position of the bug und startup
        //Debug.Log(bugPosition);
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
        Instantiate(GoodApple, transform.position, transform.rotation);
    }

        public IEnumerator BadAppleTimer ()
    {
         float timeToLaunch = Random.Range(2, 10);      //wait for a random amount of seconds before launch to keep it from getting boring
        yield return new WaitForSeconds(timeToLaunch);
        Instantiate(BadApple, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
