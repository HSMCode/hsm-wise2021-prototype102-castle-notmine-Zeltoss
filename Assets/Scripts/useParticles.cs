using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useParticles : MonoBehaviour
{
    public ParticleSystem windEffect;
    public ParticleSystem munchEffect;

    // Key Down: The Wind Effect gets triggered
    // Key Up: The Wind Effects gets disabled
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            windEffect.Play();
        } 
        
        else if (Input.GetKeyUp(KeyCode.Space)) 
        {
            windEffect.Stop();
        }
    }

    // The Munch effect gets triggered after one of the good or bad apples collides with the bug
    public void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "AppleGood" || other.tag == "AppleBad") 
        {
            munchEffect.Emit(5);
        }
    }
}
