using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodApple : MonoBehaviour
{   

    public float speed = 10.0f;
    private Rigidbody rb;
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < screenBounds.x * 10) 
        {
            Destroy(this.gameObject);
        }
    }
}
