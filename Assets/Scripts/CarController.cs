using UnityEngine;
using UnityEngine.UI;


public class CarController : MonoBehaviour
{
    public GameObject[] cars; //car models

    private Rigidbody rb; //vehicle rigidbody
    private GameObject car; //current car object

    //wheels obcjects and components
    private GameObject wheels; //car wheels
    private GameObject wheelsMeshs; //wheel mesh
    private WheelCollider[] front_wheels = new WheelCollider[2];
    private WheelCollider[] back_wheels = new WheelCollider[2];
    private GameObject[] wheelMesh = new GameObject[4];

    public float _steer = 50f; //steer angle
    public float motorForce = 1000f; // motor power
    public float brakeForce = 900000f; //brake powe

    //car lights and components
    private Renderer lights; 
    public Material BrakelightOn;
    public Material BrakelightOff;
    public Material BackLight;
    public Light lightLeft;
    public Light lightRight;
    public Text lightText;

    public float KPH; //vehclee speed

    // Start is called before the first frame update
    void Start()
    {
        getCar();//get cuurent car
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        Drive();
        Steer();
        braking();
        AnimateWheels();
        lightControl();
    }

 
    void Drive()
    {
        //set motor power 
        foreach (WheelCollider wheel in back_wheels)
        {
            if (ButtonController.accel != 0)
            {
                wheel.motorTorque = ButtonController.accel * motorForce;
            }
            else wheel.motorTorque = 0;

        }
        //BlackLight on if back accel
        if (ButtonController.accel == -1)
        {
            lights.material = BackLight;
        }
     
        KPH = rb.velocity.magnitude * 3.6f;//update speed

      
    }

    void Steer()
    {

            
            var _steerAngle = ButtonController.steer * _steer; // direction of steer
            if (ButtonController.steer !=0 )
            {
               
                front_wheels[0].steerAngle = _steerAngle ;
                front_wheels[1].steerAngle = _steerAngle;
                
            }
          
            else
            {
                front_wheels[0].steerAngle =0;
                front_wheels[1].steerAngle = 0;
            }

        
          
            


    }


    // correctly applies the transform
    private void AnimateWheels()
    {
        Vector3 position = Vector3.zero;
        Quaternion rotation = Quaternion.identity;
        int i = 0;
        foreach (WheelCollider wheel in front_wheels)
        {
            wheel.GetWorldPose(out position, out rotation);

            wheelMesh[i].transform.position = position;
            wheelMesh[i].transform.rotation = rotation;
            i++;
        }
        foreach (WheelCollider wheel in back_wheels)
        {
            wheel.GetWorldPose(out position, out rotation);

            wheelMesh[i].transform.position = position;
            wheelMesh[i].transform.rotation = rotation;
            i++;
        }

    }

    //brake car
    private void braking()
    {
        if (ButtonController.brake == 1)
        {
            foreach (WheelCollider wheel in back_wheels)
            {
                 
                wheel.brakeTorque = brakeForce; 
                wheel.motorTorque = 0;
                lights.material = BrakelightOn;

            }
        }
        else
        {
            foreach (WheelCollider wheel in back_wheels)
            {
                wheel.brakeTorque = 0;
               if(ButtonController.accel != -1)
                {
                    lights.material = BrakelightOff;
                }
               
            }
        }
       
    }
    //getting gameobjects and components runtime
    private void getCar()
    {
        rb = GetComponent<Rigidbody>();
        car = cars[CarSelection.currentCar];
        car.SetActive(true);
        wheels = car.transform.Find("wheels").gameObject;
        front_wheels[0] = wheels.transform.Find("wheels_FL").gameObject.GetComponent<WheelCollider>();
        front_wheels[1] = wheels.transform.Find("wheels_FR").gameObject.GetComponent<WheelCollider>();
        back_wheels[0] = wheels.transform.Find("wheels_RL").gameObject.GetComponent<WheelCollider>();
        back_wheels[1] = wheels.transform.Find("wheels_RR").gameObject.GetComponent<WheelCollider>();
        wheelsMeshs = car.transform.Find("wheelsMesh").gameObject;
        wheelMesh[0] = wheelsMeshs.transform.Find("wheels_FL").gameObject;
        wheelMesh[1] = wheelsMeshs.transform.Find("wheels_FR").gameObject;
        wheelMesh[2] = wheelsMeshs.transform.Find("wheels_RL").gameObject;
        wheelMesh[3] = wheelsMeshs.transform.Find("wheels_RR").gameObject;

        lights = car.transform.Find("Lights").GetComponent<Renderer>();
        lightLeft = lights.transform.Find("SpotLightLeft").GetComponent<Light>();
        lightRight = lights.transform.Find("SpotLightRight").GetComponent<Light>();


    }
    //lights control function
    private void lightControl()
    {
        if (ButtonController.lights == true)
        {
            lightLeft.intensity = 8f;
            lightRight.intensity = 8f;
            lightText.text = "On";
        }
        else
        {
            lightLeft.intensity = 0f;
            lightRight.intensity = 0f;
            lightText.text = "Off";
        }
            
    }
}
