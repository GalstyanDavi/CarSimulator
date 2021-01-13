using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject speedometer; 
    private float startPos , endPos; //speedometr positions
    private float desirePos; //stertpos-endpos
    public float speed; //car spped
    public CarController car; //current car
    public Text speedTx; //speedometer text km/h
    // Update is called once per frame
    public void Start()
    {
        //set start and end pos;
        startPos = speedometer.transform.position.x;
        endPos = speedometer.transform.position.x + 300f;
    }
    void FixedUpdate()
    {
        speed = car.KPH;
        UpdateSpeedometer();
        speedTx.text = (int)speed + " km/h";
       
    }
    //updating speedometer position 
    private void UpdateSpeedometer()
    {
        desirePos = startPos- endPos;
        float temp = speed/200;
        if (speedometer.transform.position.x < endPos)
        {
            
                speedometer.transform.position = new Vector3((startPos - temp * desirePos), speedometer.transform.position.y, speedometer.transform.position.z);
            
        }
        else speedometer.transform.position = new Vector3((endPos), speedometer.transform.position.y, speedometer.transform.position.z);

    }
}
