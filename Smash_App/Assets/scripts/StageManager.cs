using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/* Find a specific category of functions using the 'Ctrl-F' Keywords below

 FUNCTIONS CALLED ON SCREEN AWAKE
 CALLED DIRECTLY ON BUTTON CLICK
 UTILITY FUNCTIONS
 FUNCTIONS THAT PERFORM THE BACK-END STAGE BANNING LOGIC
 METHODS FOR CHANGING PLAYER LABEL DURING PICK-BANS
 METHODS FOR MANIUPLATING A BUTTON'S AESTHETIC ON CLICK
 
 */

public class StageManager : MonoBehaviour {

    // I needed to call certain methods (chooseStage) from outside the function, but couldn't make the 
    //method itself static because the Invoke() function needs to be bound to a class instance. Therefore, I made this 'instance' data member
    // to act as the class instance that persists throughout the scene
    static private StageManager instance; 

    [SerializeField] Button btn1;
    [SerializeField] Button btn2;
    [SerializeField] Button btn3;
    [SerializeField] Button btn4;
    [SerializeField] Button btn5;
    [SerializeField] Button btn6;


    static int bannedCount = 0;
    List<Button> unbannedStages = new List<Button>(); // This is where all of the buttons start at the beginning of the scene
    static int totalStages = 6;

    void Awake()
    {
        //TODO: reset screen, in case the user fucks up on the current phase of stage banning
        Instance();
        checkSetComplete(); // check to see if someone has won the set
        addStageButtons();
        enterGameLoop();
    }

    // ===================================== FUNCTIONS CALLED ON SCREEN AWAKE =================================================//

    public static StageManager Instance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(StageManager)) as StageManager;
            if (!instance)
                Debug.Log("could not find an instance of Stage Manager.");
        }
        return instance;
    }

    void checkSetComplete()
    {
        int minGamesToWin = GameState.state.matchStaticData.getMinGames();
        //print("min games: " + minGamesToWin);
        if (GameState.state.matchData.getP1Score() == minGamesToWin || GameState.state.matchData.getP2Score() == minGamesToWin)
        {
            GameState.state.matchData.setWinner(GameState.state.matchData.getPlayerName(GameState.state.matchData.getWinnerIndex()));
            SceneManager.LoadScene("Win_Screen");
        }
    }

    void addStageButtons()
    {
        unbannedStages.Add(btn1);
        unbannedStages.Add(btn2);
        unbannedStages.Add(btn3);
        unbannedStages.Add(btn4);
        unbannedStages.Add(btn5);
        unbannedStages.Add(btn6);
    }

    void enterGameLoop()
    {
        int currentPhase = GameState.state.matchData.getCurrentPhase();

        switch (currentPhase)
        {
            case 0:
                executePhase0Commands();
                break;
            //default:
            //    // During the counterpick phases of the match, the starting player will be different depending on match format
            //    // bo5, text = 'choose'     bo3, text = 'ban'
            //    PickBanScreenAwake.togglePickBanText();
            //    break;

        }
    }

    

    //===========================================================================================================================



    // ======================================= CALLED DIRECTLY ON BUTTON CLICK =================================================//
    public void phaseSpecificButtonCommands(string buttonName)
    {
        // Only want to execute a button command if the current scene isn't in the middle of transitioning
        // to the next scene. This replaces 'button.interactable = false' so that we can maintain the color changing aspect to our buttons
        if (!GameState.state.metaData.isTransitioning())
        {
            Button button = GameObject.Find(buttonName).GetComponent<Button>();
            Text currentPlayer = GameObject.Find("CurrentPlayer").GetComponent<Text>(); // retrieves the text component from the 'Current Player' Game Object
            Text pickBanText = GameObject.Find("pick_ban").GetComponent<Text>(); // retrieves the text component from the 'pick_ban' Game Object
            if (GameState.state.matchStaticData.getMaxGames() == 3)
            {
                phaseSpecificButtonCommandsBo3(button, currentPlayer, pickBanText);
            }

            else if (GameState.state.matchStaticData.getMaxGames() == 5)
            {
                phaseSpecificButtonCommandsBo5(button, currentPlayer, pickBanText);
            }
                
        }
    }

    //=============================================================================================================================//

    //================================================= UTILITY FUNCTIONS ==========================================================//

    public void checkSetBannedCount()
    {
        setBannedCount();
        checkBannedCount();
    }

    void disableStadium()
    {
        foreach (Button button in unbannedStages)
        {
            if (button.name == "Pokemon Stadium")
            {
                button.interactable = false;
                button.tag = "Banned";
            }
        }
    }

    void executePhase0Commands()
    {
        // in case we need to add additional rules to this (other games, other game types) I abstracted the 'disableStadium' method call 
        // into its own method.
        disableStadium();
    }

    public void phaseSpecificButtonCommandsBo3(Button button, Text currentPlayer, Text pickBan)
    {

        int currentPhase = GameState.state.matchData.getCurrentPhase(); // retrieve current phase
        switch (currentPhase)
        {
            case 0:
                phase0Commands(button, currentPlayer);
                break;
            default: // The only phase that differs from the others is pre-game-1 stage banning. Other phases are the same.
                phaseXCommandsBo3(button, currentPlayer, pickBan);
                break;
        }
    }


    private void phaseSpecificButtonCommandsBo5(Button button, Text currentPlayer, Text pickBan)
    {
        int currentPhase = GameState.state.matchData.getCurrentPhase();

        switch (currentPhase)
        {
            case 0:
                phase0Commands(button, currentPlayer);
                break;
            default:
                phaseXCommandsBo5(button, currentPlayer, pickBan);
                break;
        }
    }

    private void phaseXCommandsBo3(Button stageButton, Text currentPlayer, Text pickBan) // calls this function every time a stage button is pressed in phase 1 or 2
    {
        pickBanStages(stageButton, pickBan, currentPlayer);
    }

    private void phase0Commands(Button stageButton, Text currentPlayer)
    {
        banStage(stageButton); // make the chosen stage uninteractable
        checkSetBannedCount();
        checkPlayerLabel(currentPlayer); // if there are still stages to ban, make sure to display the correct player's tag
    }

    private void phaseXCommandsBo5(Button stageButton, Text currentPlayer, Text pickBan)
    {
        DansStupidRule(stageButton);
    }

    //=========================================================================================================================================//

    // ======================================== FUNCTIONS THAT PERFORM THE BACK-END STAGE BANNING LOGIC =======================================//

    void checkBannedCount()
    {
        if (totalStages - bannedCount == 1)
        {
            // search for unbanned stage, set the matchData's 'currentStage' name to this stage's tag
            findUnbannedStage();
        }
    }

    bool checkIfPlayerWonOnStage(Button button)
    {
        int currentPlayer = GameState.state.matchData.getCurrentPlayerIndex();
        return GameState.state.matchData.hasWonOnStage(currentPlayer, button.name);
    }

    // Searches the buttons on the screen until it finds the one that hasn't been banned yet. It then stores the name of that button
    // into gamestate and loads the 'game finish' scene
    void findUnbannedStage()
    {
        foreach (Button stage in unbannedStages)
        {
            if (stage.tag != "Banned")
            {
                // first, record the name of the mentioned unbanned stage, then route to the 'choosestage' method
                // read explanation in 'choosestage' for why we can't just use the below button's name to edit button appearances, and have to
                // first set the current stage's name to this button's name before routing to the 'chooseStage' method.
                GameState.state.matchData.setCurrentStage(stage.name);
                chooseStage(stage);
            }
        }
    }

    void pickBanStages(Button button, Text pickBan, Text currentPlayer)
    {
        GameState.state.matchData.setCurrentStage(button.name); // sets current stage, so Game_Finish screen can load the correct stage image
        //ffprint("Current player: " + GameState.state.matchData.getCurrentPlayer());
        if (GameState.state.matchData.getStagesBanned() == 0) // if there haven't been any stages banned...
        {
            banStage(button);
            replacePickBanText(pickBan); // updates 'ban' or 'choose' text
            checkPlayerLabel(currentPlayer); // updates the player name to reflect the counterpicking player's name
        }
        else
        {
            DansStupidRule(button);
        }
    }

    void DansStupidRule(Button b)
    {
        GameState.state.matchData.setCurrentStage(b.name); // sets current stage, so Game_Finish screen can load the correct stage image
        if (checkIfPlayerWonOnStage(b)) // if the loser has won on the chosen stage...
        {
            ModalPanel.modalPanel.Choice(); //opens the counterpick confirmation box
        }
        else
            chooseStage(b, true); // proceed to the next screen. if not, stay on this screen and wait for the next button click event.
    }

    void setBannedCount() // You're updating the banned count after every button click. We're assuming that a button click is another stage ban.
    {
        bannedCount = 0;
        foreach (Button stage in unbannedStages)
        {
            bannedCount += Convert.ToInt32((stage.tag == "Banned")); // count the number of banned stages so far, and update bannedCount's value
        }
    }

    void toGameFinish()
    {
        SceneManager.LoadScene("Game_Finish");
    }
    //=======================================================================================================================================//

    // ========================================== METHODS FOR CHANGING PLAYER LABEL DURING PICK-BANS =========================================== //


    public void checkPlayerLabel(Text currentPlayer)
    {
        if (GameState.state.matchStaticData.getMaxGames() == 3)
        {
            checkPlayerLabelBo3(currentPlayer);
        }

        else
        {
            checkPlayerLabelBo5(currentPlayer);
        }
    }

    private void checkPlayerLabelBo5(Text currentPlayer)
    {
        int currentPhase = GameState.state.matchData.getCurrentPhase();

        if (currentPhase == 0) replacePlayerLabelStage0(currentPlayer);
    }

    private void checkPlayerLabelBo3(Text currentPlayer)
    {
        int currentPhase = GameState.state.matchData.getCurrentPhase();

        if (currentPhase == 0)
        {
            // Phase 0, switch tags @ 1 stage, 3 stages banned
            replacePlayerLabelStage0(currentPlayer);
        }
        else
        {
            replacePlayerLabelStageX(currentPlayer);
        }
    }

    private static void replacePlayerLabelStage0(Text currentPlayer)
    {
        int stagesBanned = GameState.state.matchData.getStagesBanned();
        List<int> toggleNames = new List<int> { 1, 3 }; // The current player banning should switch when there are 1, 3, and 4 stages banned.
        if (toggleNames.Contains(stagesBanned))
        {
            GameState.state.matchData.toggleCurrentPlayer();
            displayCurrentPlayer.updateName(currentPlayer); // uses the displayCurrentPlayer class to update the current player's name 
        }

    }

    private void replacePlayerLabelStageX(Text currentPlayer)
    {
        int stagesBanned = GameState.state.matchData.getStagesBanned();
        // first player bans, name toggle unnecessary

        // next player 'chooses' stage
        if (stagesBanned == 1)
        {
            GameState.state.matchData.toggleCurrentPlayer();
            displayCurrentPlayer.updateName(currentPlayer); // uses the displayCurrentPlayer class to update the current player's name 
        }

        //check to see if loser is about to choose a stage that they already won on, if so, pop up a dialogue box

        // should add a 'directly choose stage' toggle checkbox
    }

    public void replacePickBanText(Text textContent) // Replace the 'pick / ban' text located immediately after the player name text field
    {
        // toggles the choose / ban label text content
        textContent.text = textContent.text.ToLower() == "ban" ? "pick" : "ban";
    }

    //=================================================================================================================================//

    //========================================= METHODS FOR MANIUPLATING A BUTTON'S AESTHETIC ON CLICK ==============================//

    void banStage(Button button)
    {
        ChangeBtnTag.changeBtnTag(button); // Changes the current stage's tag to 'banned'
        colorChange.changeColor.banStage(button); // Changes the color of the stage to red
        GameState.state.matchData.incrementStagesBanned(); // increments the number of stages banned
    }

    static public void chooseStage(Button button, bool switchChars = false)
    {
        GameState.state.metaData.toggleTransition(); // Tells the backend that we're transitioning scenes, so we shouldn't accept button presses.
        /* issue here is that the way I'm approaching this, I call this function from the 'confirm' button click that's located within the modal
         * panel, so the greenness of the button
        that I am using in the parameter is no bueno. Workaround would be to 'find component by name', using the current stage name stored in
         gamestate, and just turn that button green instead of turning green the button passed as the 'button' param.*/
        Button stageButton = GameObject.Find(GameState.state.matchData.getCurrentStage()).GetComponent<Button>();
        colorChange.changeColor.chooseStage(stageButton); // Changes the color of the clicked button to green

        // Going to replace this 'invoke' with a 'pop up the character select window', and from the character select window
        // the app will either route to the character select screen or the game finish screen.
        if (switchChars)
        {
            print(switchChars);
            ToCharSelect.modalPanel.openCharSelectWindow();
        }
            
        else
            instance.Invoke("toGameFinish", .5f); // wait .5 seconds before loading the next screen
    }

    //======================================================================================================================================//

    

}
