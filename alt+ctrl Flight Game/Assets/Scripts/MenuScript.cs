/****
 * Created by: Bridget Kurr
 * Date Created: June 5, 2022
 * 
 * Last Edited by:
 * Last Edit:
 * 
 * Description: Manages the UI elements for the menu scenes
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //libraries for UI components
using TMPro; //libraries for TextMeshPro componenets

public class MenuScript : MonoBehaviour
{

    GameManager gm; //reference to game manager

    [Header("Text Boxes")]
    public TMP_Text titleTextbox; //textbox for the title
    public TMP_Text creditsTextbox; //textbox for the credits
    public TMP_Text copyrightTextbox; //textbox for the copyright
    public TMP_Text messageTextbox; //textbox for end message
    public TMP_Text message2Textbox; //textbox for secondary end message

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM; //reference to game manager

        //if textboxes exist set the value 
        if (titleTextbox) { titleTextbox.text = gm.gameTitle; }
        if (creditsTextbox) { creditsTextbox.text = gm.gameCredits; }
        if (copyrightTextbox) { copyrightTextbox.text = gm.copyrightDate; }
        if (messageTextbox) { messageTextbox.text = gm.endMsg; }
        if (message2Textbox) { message2Textbox.text = gm.defaultEndMessage; }
    } //end Start()

    public void OnGameStart()
    {
        Debug.Log("Game Started");
        gm.SetTargetState(GameState.gamePlaying);

    } //end OnGameStart()

    public void OnGameExit()
    {
        Debug.Log("Exited Game");
        gm.SetTargetState(GameState.gameExited);

    } //end OnGameExit()


} //end MenuScript class
