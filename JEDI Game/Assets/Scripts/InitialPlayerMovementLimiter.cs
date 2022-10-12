using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPlayerMovementLimiter : MonoBehaviour
{
    private enum ArrowInput{
        Up,
        Down,
        Right,
        Left
    }
    private ArrowInput CurrentValidArrowInput;
    public enum GameState {
        Starting,
        FirstStep,
        SecondStep,
        ThirdStep,
        EndOfLevel
    };

        private bool HandlingPlayerInput;

    // Simple State Machine to manage the player Movement and animations
    public void ChangeState(GameState nextState){

        switch(nextState){
            case GameState.Starting:
                PlayFirstAnimation();
                break;
            case GameState.FirstStep:
                HandleFirstMovement();
                break;
            case GameState.SecondStep:
                HandleSecondMovement();
                break;
            case GameState.ThirdStep:
                HandleThirdMovement();
                break;

            //Do this Until the game needs to move to the next phase (EndOfLevel)

            case GameState.EndOfLevel:
                HandleLoadNextScene();
                break;
        }
    }

    private void PlayFirstAnimation(){
        HandlingPlayerInput = false;

        // PLAY THE FIRST CUTSCENE
        ChangeState(GameState.FirstStep);

        HandlingPlayerInput = true;
    }
    private void HandleFirstPlayerInput(){
        HandlingPlayerInput = true;

        Debug.Log("Starting");
        HandlingPlayerInput = false;
        // Play First Animation/Cutscene ()
    }
    private void HandleFirstMovement(){
        ChangeState(GameState.SecondStep);
                Debug.Log("First Movement");
        // Play Second Animation
    }
    private void HandleSecondMovement(){
        ChangeState(GameState.ThirdStep);
                Debug.Log("Second Movement");
        // Play Third Animation
    }
    private void HandleThirdMovement(){
        ChangeState(GameState.EndOfLevel);
                Debug.Log("Third Movement");
        // Play Fourth Animation
    }
    private void HandleLoadNextScene(){
                Debug.Log("Changing Scenes...");
        //Load the next phase
    }

    private void HandlePlayerInput(){
        switch(CurrentValidArrowInput){
            case ArrowInput.Right:
                if(Input.GetKeyDown(KeyCode.RightArrow));
                break;
            case ArrowInput.Down:
                if(Input.GetKeyDown(KeyCode.DownArrow));
                break;
            case ArrowInput.Left:
                if(Input.GetKeyDown(KeyCode.LeftArrow));
                break;
            case ArrowInput.Up:
                if(Input.GetKeyDown(KeyCode.UpArrow));
                break;
        }
    }

    void Start() {
        ChangeState(GameState.Starting);
        CurrentValidArrowInput = ArrowInput.Right;
        HandlingPlayerInput = false;
    } 
    

    void Update()
    {
        if(HandlingPlayerInput){
            HandlePlayerInput();
        }
    }
}
