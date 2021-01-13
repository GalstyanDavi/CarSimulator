using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundContorller : MonoBehaviour
{
    private float pspeed = 150f;//max speed
    private float pitch = 0f;
    public CarController car;



    // Update is called once per frame
    void Update()
    {
        pitch = car.KPH / pspeed;
        car.GetComponent<AudioSource>().pitch = pitch;
        
    }

}
