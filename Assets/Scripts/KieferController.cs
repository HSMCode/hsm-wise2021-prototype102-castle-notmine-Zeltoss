using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KieferController : MonoBehaviour
{
    public Quaternion startupRotation;

    // Start is called before the first frame update
    void Start()
    {
        startupRotation = transform.rotation; //get rotation of the upper head on startup
        //Debug.Log(startupRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.rotation = startupRotation * Quaternion.Euler(-50f, 0f, 0f);      //if key is pressed, bug opens mouth, else mouth is closed
        }
        else
        {
            transform.rotation = startupRotation;
        }

    }
}
