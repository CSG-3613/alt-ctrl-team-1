/****
 * Created by: Bridget Kurr
 * Date Created: June 13, 2022
 * 
 * Last Edited by:
 * Last Edited:
 * 
 * Description: Collectable object behaviors for counting the total amount of collectables and checking for collision with the player.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    /****VARIABLES****/

    static public int collectableCount; //counts the number of collectables in the scene

    // Awake is called on instantiation before Start
    private void Awake()
    {
        collectableCount++; //add to collectable
        Debug.Log("<color=lightblue>Number of Collectables </color>" + collectableCount);

    }//end Awake()

    //Called when a GameObject collides with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("<color=yellow>Collectable Triggered</color>");

        if (other.tag == "Player")
        {
            other.GetComponent<Collection>().AddToCollection();//call method on the Collection component of other object
            Destroy(gameObject); //destroy this gameObject (collectable object)
        }

    }//end OnTriggerEnter()

}//end class
