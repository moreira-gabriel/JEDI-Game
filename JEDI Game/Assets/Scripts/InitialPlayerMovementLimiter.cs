using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPlayerMovementLimiter : MonoBehaviour
{

    public enum GameState {
        Starting,
        FirstStep,
        SecondStep,
        ThirdStep,
        EndOfLevel
    };

    public void ChangeState(GameState nextState){

        switch(nextState){
            case GameState.Starting:
                HandleFirstPlayerInput();
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

    private void HandleFirstPlayerInput(){
        ChangeState(GameState.FirstStep);
    }
    private void HandleFirstMovement(){
        ChangeState(GameState.SecondStep);
    }
    private void HandleSecondMovement(){
        ChangeState(GameState.ThirdStep);
    }
    private void HandleThirdMovement(){
        ChangeState(GameState.EndOfLevel);
    }
    private void HandleLoadNextScene(){
        //Load the next phase
    }

    void Start() => ChangeState(GameState.Starting);
    
    void Update()
    {
        
    }
}
