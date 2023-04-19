using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class RotaryEncoder : MonoBehaviour
{
    UduinoManager uduinoManager;

    uint counter, temp;
    void Start()
    {
        uduinoManager = UduinoManager.Instance;

        //uduinoManager.pinMode(2, PinMode.Input_pullup);
        //uduinoManager.pinMode(3, PinMode.Input_pullup);
        //uduinoManager.pinMode(AnalogPin.A2, PinMode.Input);
        //uduinoManager.pinMode(AnalogPin.A3, PinMode.Input);

        uduinoManager.OnDataReceived += DataReceived;


    }

    // Update is called once per frame
    void Update()
    {
        //int value = uduinoManager.digitalRead(2);
        //Debug.Log("Valeur 2 : " + uduinoManager.digitalRead(2));
        //Debug.Log("Valeur 3 : " + uduinoManager.digitalRead(3));

        //if (uduinoManager.digitalRead(2) == 0)
        //{
        //    //counter--;
        //}
        //else
        //{
        //    counter++;
        //}

        //if(uduinoManager.digitalRead(3) == 0)
        //{
        //    //counter++;
        //}
        //else
        //{
        //    counter--;
        //}
        //Debug.Log("compteur : " + counter);

        Debug.Log(uduinoManager.analogRead(AnalogPin.A2));
    }

    public void DataReceived(string Data, UduinoDevice board)
    {
        Debug.Log(Data);
    }
}
