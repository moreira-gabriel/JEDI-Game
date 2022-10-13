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

        private void PlayFirstAnimation(){
            // PLAY THE FIRST ANIMATION/CUTSCENE
            HandlingPlayerInput = true;
        }

        private void PlayNextAnimation(){
            HandlingPlayerInput = false;
            // Play the current Animation and make assign the next Animation
            HandlingPlayerInput = true;
        }
    private void HandlePlayerInput(){
        switch(CurrentValidArrowInput){
            case ArrowInput.Right:
                if(Input.GetKeyDown(KeyCode.RightArrow)){
                    PlayNextAnimation();
                }
                break;
            case ArrowInput.Down:
                if(Input.GetKeyDown(KeyCode.DownArrow)){
                    PlayNextAnimation();
                }
                break;
            case ArrowInput.Left:
                if(Input.GetKeyDown(KeyCode.LeftArrow)){
                    PlayNextAnimation();
                }
                break;
            case ArrowInput.Up:
                if(Input.GetKeyDown(KeyCode.UpArrow)){
                    PlayNextAnimation();
                }
                break;
        }
    }
    void Start() {
        CurrentValidArrowInput = ArrowInput.Right;
        HandlingPlayerInput = false;
        PlayFirstAnimation();
    } 
    
    void Update()
    {
        if(HandlingPlayerInput){
            HandlePlayerInput();
        }
    }
}
