using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{   
    public Vector3 goalPosition;     //position of the bug will be used to determine launch-direction of apples 
    public Vector3 bugPosition;

    Rigidbody thisApple;            //define a variable for this apples rigidbody
    
    [SerializeField] private float idlePower = 0.5f;    //set powerlevels for open and closed mouth status
    //[SerializeField] private float eatPower = 1f;
    
    private Vector3 directionIdle;      //define variables for move directions
    //private Vector3 directionEat;

    private Vector2 screenBounds; //define variable for screen-bounds

    public Transform openMouth;
    public float speed;
    private float appleSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        goalPosition  = GameObject.Find("appleGoal").transform.position;        //determine position of invisible goal on startup
        bugPosition  = GameObject.Find("Kaefer").transform.position;        //determine position of bug on startup
        //Debug.Log(bugPosition);
        thisApple = GetComponent<Rigidbody>();
        directionIdle = goalPosition - transform.position;      //define direction for open-mouth movement
       // directionEat = bugPosition - transform.position;        //define direction for closed-mouth movement
        
        thisApple.AddForce(directionIdle * idlePower, ForceMode.Impulse);       //launch apple with small impulse on instantiation

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));      //set screen-bounds


    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.Space))        //push apple toward bug if mouth is open
        {
            appleSpeed = speed * Time.deltaTime;
           // thisApple.AddForce(directionEat * eatPower, ForceMode.Force);
           thisApple.transform.position = Vector3.MoveTowards(thisApple.transform.position,openMouth.position,appleSpeed); //Move apple to Bug
        }
        else
        {
            thisApple.AddForce(directionIdle * idlePower, ForceMode.Force);     //push apple to the left if mouth is closed
        }

        /*if(transform.position.x < screenBounds.x )          //destroy apple if out of bounds
        {
            Destroy(this.gameObject);
        } */
    }

    public void OnTriggerEnter(Collider other)      //destroy apple if munched (e.g. if foodcollider is active and apple enters it)
    {
        if (other.CompareTag("MunchZone"))
        {
            Destroy(gameObject);
        }
        
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }
}
