using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploiApples : MonoBehaviour
{

    public GameObject GoodApplePrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(GoodAppleWave());
    }

    private void spawnGoodApple(){
        GameObject a = Instantiate(GoodApplePrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -10, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator GoodAppleWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnGoodApple();
        }
        
    }


}
