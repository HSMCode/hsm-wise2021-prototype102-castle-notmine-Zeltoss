using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{   
    public Vector3 goalPosition;     //position of the bug will be used to determine launch-direction of apples 
    public Vector3 bugPosition;

    Rigidbody thisApple;            //define a variable for this apples rigidbody
    
    private float idlePower = 0.06f;
    private float eatPower = 0.2f;
    
    private Vector3 directionIdle;
    private Vector3 directionEat;
    
    // Start is called before the first frame update
    void Start()
    {
        goalPosition  = GameObject.Find("appleGoal").transform.position;        //determine position of invisible goal on startup
        bugPosition  = GameObject.Find("Kaefer").transform.position;        //determine position of bug on startup
        //Debug.Log(bugPosition);
        thisApple = GetComponent<Rigidbody>();
        directionIdle = goalPosition - transform.position;
        directionEat = bugPosition - transform.position;
        
        thisApple.AddForce(directionIdle * idlePower, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.Space))
        {
            thisApple.AddForce(directionEat * eatPower, ForceMode.Force);
        }
        else
            thisApple.AddForce(directionIdle * idlePower, ForceMode.Force);
        
    }
}
