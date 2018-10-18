using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToStageBan : MonoBehaviour{

    public void updateMatchInfo(int winner)
    {
        // Depending on the set count... if Bo3 then we want to increment the winner's score AND set current player to the winner
        // if Bo5 we want to increment the winner's score BUT set current player to the loser, because the loser will be directly chosing his/her counterpick.
        int matchFormat = GameState.state.matchStaticData.getMaxGames();
    
        updateWinnerInfo(winner, matchFormat);
       
        resetMidMatchData();
        SceneManager.LoadScene("Stage_Banning");
    }

    private void updateWinnerInfo(int winner, int matchFormat)
    {
        // if the match format is Bo3, current player is the winner of the last match. Else, current player is the opposite (1 if 0, 0 if 1) of the winner index
        int currentPlayer = matchFormat == 3 ? winner : winner == 1 ? 0 : 1;

        string winnerStage = GameState.state.matchData.getCurrentStage();
        GameState.state.matchData.setCurrentPlayer(currentPlayer); // sets the current player to the winner of the last game; prep for stage ban screen
        GameState.state.matchData.setWinnerIndex(winner); // Lets you know who won the last game
        GameState.state.matchData.incrementPlayerScore(winner); // increments winner's score
        GameState.state.matchData.addStagesWon(winner, winnerStage); // adds the current stage to the winner's stagesWon List
    }


    private void resetMidMatchData()
    {
        // Increment the current phase so that the stage banning screen knows what set of rules to enforce on a button click
        GameState.state.matchData.incrementCurrentPhase();
        // need to make sure to reset the 'stagesBanned' variable in preparation for the next wave of stage pick / bans
        GameState.state.matchData.resetStagesBanned();
        // Set isTransitioning back to false so that the buttons on the stage banning screen are interactable again
        GameState.state.metaData.toggleTransition();
        // set 'allow counterpick' back to true
        GameState.state.matchData.allowCounterPick();
        // increment current game
        GameState.state.matchData.incrementCurrentGame();
    }
}
