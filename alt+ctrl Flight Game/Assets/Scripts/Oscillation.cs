/****
 * Created by: Bridget Kurr using Code from Black Bug on YouTube.com
 * Date Created: June 21, 2022
 * 
 * Last Edited by: Bridget Kurr
 * Last Edited: April 2024
 * 
 * Description: A class to use a PowerUp to add time to the timer in a level
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour
{

    /***VARIABLES***/
    [SerializeField] Vector3 movementVector = new Vector3(0f, 0f, 0f);

    float movementFactor;

    [SerializeField] float period = 2f; //time for 1 cycle ( 2 seconds)

    Vector3 startingPosition; //for setting starting postion for PowerUps


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; //set the start position for each PowerUp
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= 0f) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSineWave * 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
