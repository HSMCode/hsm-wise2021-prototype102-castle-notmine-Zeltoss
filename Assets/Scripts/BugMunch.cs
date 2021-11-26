using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMunch : MonoBehaviour
{

    public GameObject ApplePrefab;
    int Count = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Pressed Space");
            Destroy(GameObject.FindWithTag("Apple"));
            Count++;
            Debug.Log("Score: " + Count);

        } 


    }
}
