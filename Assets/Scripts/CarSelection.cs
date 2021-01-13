using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    public Button  next; //buuton for next car
    public Button prev; //button for prev car
    static public int currentCar; //current car index
    public Text tx; // car name text
    private string[] carName = { "Chevrolet", "Porche" }; //our car names

    public void Awake()
    {
        selectCar(0);  //current car index=0;
        tx.text = carName[0];
    }

    public void selectCar(int _index)
    {
        prev.interactable = (_index != 0);  //if index not 0  allow button 
        next.interactable = (_index != transform.childCount - 1); //if  index not at the end  allow next button
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index); //set true or false
           
        }
    }
    public void changeCar(int change)
    {
        currentCar += change; //cahnge current car
        tx.text = carName[currentCar]; //show car name
        selectCar(currentCar); //select current car

    }
}
