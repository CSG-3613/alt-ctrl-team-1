using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.SceneManagement;
using System.IO.Ports;
using UnityEngine.TextCore.Text;

public class USB : MonoBehaviour
{

    private SerialPort port;
    private Character character;
    private const int baudRate = 9600;

    public object GUILayoutButton { get; private set; }

    private void Awake()
    {
        {
            character = FindObjectOfType<Character>();
        }
    }

    private void Update()
    {
        if(port != null)
        {
            string data = port.ReadExisting();
            if(!string.IsNullOrEmpty(data))
            {
                char command = data.ToCharArray()[data.Length - 1];
                bool pressed = command == 'y';
                character.input = pressed;
            }
        }
    }

    private void OnGUI()
    {
       if(port == null)
        {
            foreach(string portName in SerialPort.GetPortNames())
            {
                if (GUILayout.Button(portName))
                {
                    port = new SerialPort(portName, baudRate);
                    port.Open();
                }
            }
        } 
    }

    private void OnDestroy()
    {
        if(port != null)
        {
            port.Close();
        }
    }
}
