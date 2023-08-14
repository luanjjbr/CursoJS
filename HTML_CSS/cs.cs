using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class Move : MonoBehaviour
{
    public string portName = "COM4";
    public int baudRate = 9600;
    public int v = 100;
    public float rotationMultiplier = 360.0f;

    private SerialPort serialPort;

    private void Start()
    {
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();
    }

    private void Update()
    {
        if (serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            char data = (char)serialPort.ReadChar();

            if (data == 'P')
            {
                int potValue = int.Parse(serialPort.ReadLine());
                Debug.Log("Potentiometer Value: " + potValue);
                float rotationAmount = potValue / 1023.0f * rotationMultiplier;

                // Aplica a rotação ao objeto em torno do eixo Y
                transform.rotation = Quaternion.Euler(rotationAmount, 0, 0);

            }
            else if (data == '0' || data == '1' || data == '2')
            {
                Debug.Log("Button Pressed: " + data);
                if (data == '1')
                {
                    Debug.Log("Button Pressed: " + data);
                    transform.Translate(Vector3.left * Time.deltaTime * v);
                }
                if (data == '2')
                {
                    Debug.Log("Button Pressed: " + data);
                    transform.Translate(Vector3.right * Time.deltaTime * v);
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}