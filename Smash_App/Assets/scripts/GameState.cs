using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MatchData // Mid-match, dynamic data
{

    private static int p1score = 0;
    private static int p2score = 0;

    private static string winner;
    private static int winnerIndex;

    List<string> players = new List<string> { "Player 1", "Player 2" }; // this list is set in the 'choose your tags' screen

    List<string> characters = new List<string> { "", "" }; // keeps track of each player's current character

    // An array of two sub-arrays. Each subarray (1 or 2) corresponds to the stages on which each player has won.
    List<List<string>> stagesWon = new List<List<string>> { new List<string> { }, new List<string> { } };

    int currentPlayer;

    private string currentStage;

    private static int currentPhase = 0; // current phase helps facilitate rule creation, depending on what part of the set the players are in.
    // Ex. phase 0 is rock paper scizzors, phase 1 is initial bans, phase 2 is after first game is completed, phase 3 is after second game is completed
    // Phase 4 is after the set is completed.

    private static int stagesBanned = 0;
    private static int currentGame = 1;

    private static bool confirmCounterPick = true;

    // Reset all match data
    public void reset()
    {

        p1score = 0;
        p2score = 0;

        currentPhase = 0;
        stagesBanned = 0;
        currentGame = 1;

        confirmCounterPick = true;

        currentStage = "";

        resetStagesWon();
        resetChars();
        resetNames();

        winner = "";
        
    }

    void resetStagesWon()
    {
        for (int i = 0; i < stagesWon.Count; ++i)
        {
            stagesWon[i] = new List<string> { };
        }
    }

    void resetChars()
    {
        for (int i = 0; i < characters.Count; ++i)
        {
            characters[i] = "";
        }
    }

    void resetNames()
    {
        for (int i = 0; i < players.Count; ++i)
        {
            players[i] = "Player " + (i+1).ToString();
        }
    }


    // Add this stage the the winner's 'stagesWon' List.
    public void addStagesWon(int winner, string stage) { stagesWon[winner].Add(stage); }

    // has the given player won on the given stage? check the stagesWon List to find out
    public bool hasWonOnStage(int player, string stage) { return stagesWon[player].Contains(stage); }

    int totalGamesPlayed() { return p1score + p2score; }

    public void setWinner(string currentPlayer) { winner = currentPlayer; }

    public void setWinnerIndex(int x) { winnerIndex = x; }

    public int getWinnerIndex() { return winnerIndex; }

    public string getWinner() { return winner; }

    public void incrementPlayerScore(int score) { if (score == 0) ++p1score; else ++p2score; }

    public void incrementP2Score() { ++p2score; }

    public void resetP1Score() { p1score = 0; }

    public void resetP2Score() { p2score = 0; }

    public int getP1Score() { return p1score; }

    public int getP2Score() { return p2score; }

    public void setP1Name(string x) { players[0] = x; }

    public void setP2Name(string x) { players[1] = x; }

    public void setCurrentPlayerName(string x) { players[currentPlayer] = x; }

    public void setCurrentPlayerChar(string x) { characters[currentPlayer] = x; }

    public void setPlayerChar(int player, string x) { characters[player] = x; }

    public string getCurrentPlayerChar() { return characters[currentPlayer]; }

    public string getPlayerChar(int x) { return characters[x]; } // given an index, return the corresponding character. Used in CharSelectInfo.cs

    public string getP1Name() { return players[0]; }

    public string getP2Name() { return players[1]; }

    public string getPlayerName(int x) { return players[x]; }

    public void setCurrentPlayer (int x) { currentPlayer = x; }

    public void toggleCurrentPlayer() { currentPlayer = currentPlayer == 0 ? 1 : 0; }

    public bool isCounterPickAllowed() { return confirmCounterPick; }

    public void allowCounterPick() { confirmCounterPick = true; }

    public void preventCounterPick() { confirmCounterPick = false; }

    public string getCurrentPlayer() { return players[currentPlayer]; }

    public int getCurrentPlayerIndex() { return currentPlayer; }

    public void setCurrentStage(string name) { currentStage = name; }

    public string getCurrentStage() { return currentStage; }

    public void resetCurrentPhase() { currentPhase = 0; }

    public void incrementCurrentPhase() { ++currentPhase; }
    
    public void incrementCurrentGame() { ++currentGame; }

    public int getCurrentPhase() { return currentPhase; }

    public int getStagesBanned() { return stagesBanned; }

    public int getThisGame() { return currentGame; }

    public void setThisGame(int x) { currentGame = x; }

    public void incrementStagesBanned() { ++stagesBanned; }

    public void resetStagesBanned() { stagesBanned = 0; }
}


// Helper class containing data about the processes within the app itself, 
//not having to do with any of the substantial match or player data
public class MetaData 
{
    // tells the backend if the app is transitioning between scenes right now
    // Used to prevent other scripts from running when they're not supposed to
    // Ex: trying to press a stage button when the current phase's banning process is already complete
    private bool isTransitioningScenes = false;

    private bool modalPanelActive = true;

    public void togglePanelActive() { modalPanelActive = modalPanelActive == true ? false : true; }

    public bool isWindowActive() { return modalPanelActive; }

    public bool isTransitioning() { return isTransitioningScenes; }

    public void toggleTransition() { isTransitioningScenes = !isTransitioningScenes; }

}

public class MatchStaticData // Matchdata that doesn't change throughout the set. Data like 'best of X', 'Sm4sh or Melee'
{
    private string[] games = { "Melee", "Sm4sh" };
    private int currentGame; // Smash 4 or Melee, either index 0 or 1 in the games array

    private int minGames; // If a player reaches 2 / 3 wins or 3 / 5 wins, this var will keep track of that. Will be set by the GameData class
    private int maxGames; // Total games possible in a bo3 or bo5.

    public void setMinGames(int x) { minGames = x; }

    public void setMaxGames(int x) { maxGames = x; }

    public int getMinGames() { return minGames; }

    public int getMaxGames() { return maxGames; }

    public void setCurrentGame(int x) { currentGame = x; }

    public string getCurrentGame() { return games[currentGame]; }
}


public class AnalyticsData // analytics / keeping track of long term player data
{
    private List<string> playerTags = new List<string>(new string[] { "P!mp Daddy", "Thirst Master", "Daddy Loy", "Dr. J", "Jr. D", "Captain Faceroll"});
    //private string[] playerTags = { "P!mp Daddy", "Thirst Master", "Daddy Loy", "Dr. J", "Jr. D", "Captain Faceroll" };

    public void addPlayerToList(string tag)
    {
        if (!playerTags.Contains(tag.Trim()))
            playerTags.Add(tag);
    }
    public List<string> getPlayerData()
    {
        return playerTags;
    }
}


public class GameState : MonoBehaviour {
    public static GameState state = null;
    public MatchData matchData = new MatchData(); // Within gamedata, the matchdata object will keep track of the current match's data.
    public MatchStaticData matchStaticData = new MatchStaticData();
    public MetaData metaData = new MetaData();
    public static AnalyticsData analyticsData = new AnalyticsData(); // Keeps track of more long term player data

    void Awake()
    {
        persistStaticMembers();
    }

    void persistStaticMembers()
    {
        if (state == null)
        {
            state = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // Reset data function, when you route back to the main menu you should save data ONLY IF YOU'VE REACHED THE GAME_WIN SCREEN
    // and try to route back to the main menu. Either way, you need to completely wipe 'matchData', 'matchStaticData' and 'metaData'
    public static void resetCache()
    {
        GameState.state = null; // resets the match-specific data
    }

    // Utility functions for altering current match data
    public void setMaxGames(int maxGames)
    {
        state.matchStaticData.setMaxGames(maxGames); // maxGames redundant, look for places it's used
        state.matchStaticData.setMinGames(maxGames / 2 + 1); // 3 for bo5 and 2 for bo3
    }
}


