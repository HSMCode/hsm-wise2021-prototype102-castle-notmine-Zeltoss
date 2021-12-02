using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunchCollider : MonoBehaviour
{   
    public Collider foodCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foodCollider.enabled = true;
        }
        else
        {
            foodCollider.enabled = false;
        }
    }
}
