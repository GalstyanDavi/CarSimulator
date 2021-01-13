using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
   
    public static int accel = 0; //acceleration flag
    public static int steer = 0; //steering flag
    public static int brake = 0; //brake flag
    public static bool lights = false; //lights flag
    public bool pausee = false; //pause flag
    
    
  


    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        onPauseButton();
    }
    public void onLeftButtonUp()
    {
        ButtonController.steer = 0;  
    }
    
    public void onLeftButtonDown()
    {
        ButtonController.steer = -1; //set on left steer
    }
    public void onRightButtonUp()
    {
        ButtonController.steer = 0;
    }

    public void onRightButtonDown()
    {
        ButtonController.steer = 1; //set on right steer
    }
    public void onForwardButtonUp()
    {
        ButtonController.accel = 0;
    }

    public void onForwardButtonDown()
    {
        ButtonController.accel = 1; //set on forward accel
    }
    public void onBackButtonUp()
    {
        ButtonController.accel = 0;
    }

    public void onBackButtonDown()
    {
        ButtonController.accel = -1; //set on back accel
    }
    public void onbrakeButtonUp()
    {
        ButtonController. brake= 0;//brake off
    }

    public void onbrakeButtonDown()
    {
        ButtonController.brake = 1; //break on
    } 

    public void onRefreshButton()
    {
        SceneManager.LoadScene("CarSimulation");
    }
    public void onLightsButtonClick()
    {
        lights = !lights;
       
    }
    public void onPauseButton()
    {
        //pause off
        if (pausee == true)
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            pausee = false;

        }
        //pause on
        else
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            pausee = true;
        }
    }
  
}
