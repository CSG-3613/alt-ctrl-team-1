/****
 * Created by: Bridget Kurr
 * Date Created: June 17, 2022
 * 
 * Last Edited by: Bridget Kurr
 * Last Edited: April 2024
 * 
 * Description: A level timer that can be set and controlled
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    GameManager gm;
    #region Timer Singleton
    static private Timer timer; //Timer instance
    static public Timer LevelTimer { get { return timer; } } //public acces to read only timer


    //Check to make sure only Timer instance in the scene
    void CheckTimerIsInScene()
    {
        //check if instance is null
        if (timer == null)
        {
            timer = this; //set timer to this Timer instance
            Debug.Log(timer);
        }
        else //else if timer is not null a Timer must already exist
        {
            Destroy(this.gameObject); //in this case you need to delete this timer
        }
    }//end CheckTimerIsInScene
    #endregion
    [Tooltip("Start time in seconds")]
    public float startTime = 120f; //time for level (if level is timed)

    private float currentTime; //current time of the timer

    [HideInInspector]
    public bool timerStopped = false; //check if timer is stopped


    //Awake is called on instantiation before Start
    private void Awake()
    {
        gm = GameManager.GM;
        //runs the method to check for the Timer
        CheckTimerIsInScene();
    }//end Awake()


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime; //set the current time to the startTime specified  
    }//end Start()


    // Update is called once per frame
    void Update()
    {
        RunTimer();
    }//end Update()


    //Runs the timer countdown
    private void RunTimer()
    {
        if (timerStopped)
        { //check to see if timer has stopped
            LevelEnd();
        }//end if
        else
        {
            if (currentTime > 0)
            {
                //if still time, update timer countdown
                currentTime -= Time.deltaTime;
            } //end nested if
            else
            {//if the timer is less than zero
                currentTime = 0; //set time to zero
                timerStopped = true; //stop the timer
            }//end nested else

            gm.timer = DisplayTime(currentTime);
        }//end else

    } //end RunTimer()


    //Runs events for the end of the level
    private void LevelEnd()
    {
        //if (gm.endMsg != gm.winMessage) { gm.endMsg = gm.loseMessage; }
        gm.SetTargetState(GameState.gameLevelEnded);
        Debug.Log("level end");
    }//end LevelEnd()


    //Formats time as a string
    private string DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; //adds 1 to time, to accuratly reflect time in field

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //calculate timer minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //calculate timer seconds

        return string.Format("{0:00}:{1:00}", minutes, seconds); //return time as string
    }//end DisplayTime


    public void AddTime()
    {
        Debug.Log("AddTime() Accessed");

        if (currentTime > 0)
        {
            currentTime += 3;//adds 3 seconds to timer on PowerUp collection
            Debug.Log("Time added to currentTime");
        }
    }

}//end Timer() class
