using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunchController : MonoBehaviour
{   
    public Collider foodCollider;       //create a public collider variable, the collider of "kopfunten" needs to be attached here
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
    }
}
