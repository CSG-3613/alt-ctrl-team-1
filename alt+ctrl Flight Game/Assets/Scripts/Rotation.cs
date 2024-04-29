/****
 * Created by: Bridget Kurr
 * Date Created: June 17, 2022
 * 
 * Last Edited by: Bridget Kurr
 * Last Edited: April 2024
 * 
 * Description: A class to add constant rotation to objects
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    /****VARIABLES****/
    public float z = 0; //


    // Start is called before the first frame update
    void Start()
    {
        //z = 0.5f;  //velocity around the y axis
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, z)); //applying rotation around the y axis
    }



}//end ConstantRotation
