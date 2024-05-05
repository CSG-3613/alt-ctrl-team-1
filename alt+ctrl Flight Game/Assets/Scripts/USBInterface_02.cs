using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class USBInterface_02S: MonoBehaviour
{
    private SerialPort port = new SerialPort("COM5", 38400);
    private string buttonString;
    
    
    // Start is called before the first frame update
    void Start()
    {
        port.Open();
    }

    // Update is called once per frame
    void Update()
    {
        buttonString = port.ReadLine();
        if (buttonString == "buttonDown")
        {
            //increase speed here
        }
    }
}
