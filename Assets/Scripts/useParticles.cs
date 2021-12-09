using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useParticles : MonoBehaviour
{
    public ParticleSystem windEffect;
    public ParticleSystem munchEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            windEffect.Play();
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            windEffect.Stop();
        }
    }
    public void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "AppleGood" || other.tag == "AppleBad") {
            munchEffect.Emit(5);
        }
    }
}
