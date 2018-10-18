using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharSelectInfo : MonoBehaviour {

    // 10/7 progress. Stopped at Char_Switch screen. I need to flesh out displaying the player label and the character icon. make sure that the logic for
    // handling which player chooses when is fixed as well. Almost there...

    // 10/10 progress. made more progress with the char_switch screen. Need to make sure that when a player chooses a character, that the gamestate is updated accordingly
    // with the correct player being assigned the correct character.
    static CharSelectInfo instance;
    // when a player chooses a character, this string represents the name of that character.
    string currentChar;
    public Image charIcon;
    public Text playerLabel;

    public int currentPlayer;

    // When totalChars = 1, then hitting the 'GO' button will route to the Game Finish screen
    int totalChars = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        setCurrentPlayer();
        setCurrentChar();
        displayCurrentChar();
        displayCurrentPlayerName();
        
    }

    //void updateAllPlayerInfo()
    //{
    //    setCurrentPlayer();
    //    setCurrentChar();
    //    displayCurrentChar();
    //    displayCurrentPlayerName();
    //}

    void setCurrentPlayer()
    {
        //retrieves current player's index
        instance.currentPlayer = GameState.state.matchData.getWinnerIndex();

    }

    void setCurrentChar()
    {
        //retrieves current player's character
        instance.currentChar = GameState.state.matchData.getPlayerChar(instance.currentPlayer);
    }
    
    public void updateCurrentChar(Image i)
    {
        string name = i.name;
        print("update current char name: " + name);
        instance.currentChar = name.Substring(1, name.Length-1);
    }

    public void displayCurrentChar()
    {
        // build string for current player's character image
        // Replace the image with the player's chosen character image
        print(instance.currentChar);
        //print("Melee Character Sprites\\" + getCurrentPlayerChar());
        instance.charIcon.sprite = Resources.Load<Sprite>("Melee Character Sprites\\m" + instance.currentChar) as Sprite;
    }

    public string getCurrentPlayerChar()
    {
        return GameState.state.matchData.getPlayerChar(instance.currentPlayer);
    }

    public void displayCurrentPlayerName()
    {
        
        instance.playerLabel.text = GameState.state.matchData.getPlayerName(instance.currentPlayer);
        print(instance.playerLabel.text);
    }

    public void toggleCurrentPlayer()
    {
        // after hitting the 'GO' button, you'll route to this function. First check to see if both players have made decisions about their characters.
        // if they have, then route to the next screen.
        //update the current player's character before moving any further.
        updateGameStateCurrentChar();
        checkTotalChars();
        // switches players from winner to loser of last game, so that the loser of the last game can choose their character
        //print("current player before: "); print(instance.currentPlayer);
        transitionToNextPlayer();
    }

    void updateGameStateCurrentChar()
    {
        ChooseCharModalPanel.modalPanel.updatePlayerChar(instance.currentPlayer, 'm' + instance.currentChar);
        
    }

    void transitionToNextPlayer()
    {
        // increment the total number of players who have gone through the character switch process
        ++instance.totalChars;
        instance.currentPlayer = instance.currentPlayer == 0 ? 1 : 0;
        // refreshes the currentChar field for the next player. this is because if we don't refresh the currentChar field, then
        // it will still reflect the character that the winner just chose.
        setCurrentChar();
        displayCurrentChar();
        displayCurrentPlayerName();
    }

    void checkTotalChars()
    {
        if (instance.totalChars > 0)
        {
            SceneManager.LoadScene("Game_Finish");
        }
    }


}
