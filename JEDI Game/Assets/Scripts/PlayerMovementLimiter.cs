using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovementLimiter : MonoBehaviour
{
    enum ArrowInput {
        Up,
        Down,
        Right,
        Left
    }
    enum GameState 
    {
        Starting,
        WaitingInput,
        EndOfMovement,
    };
    
    [SerializeField] ArrowInput currentValidArrowInput;
    [SerializeField] GameState gameState;
    bool handlingPlayerInput;
    [SerializeField] List<ArrowInput> arrowRequiredToNextState = new List<ArrowInput>();
    [SerializeField] List<float> timeToNextState = new List<float>();
    float timer;

    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private PlayableAsset asset;

    void Start() 
    {
        currentValidArrowInput = arrowRequiredToNextState[0];
        
        gameState = GameState.Starting;
        
        handlingPlayerInput = false;
        
        Invoke("PlayFirstAnimation", 5f);       
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if(handlingPlayerInput) HandlePlayerInput();

        if(Input.GetKeyDown(KeyCode.U))
        {
            timeline.Play(asset);
        }
    }

    void PlayFirstAnimation()
    {        
        handlingPlayerInput = true;
        
        Debug.Log("Pode clicar");
    }

    private void PlayNextAnimation()
    {
        handlingPlayerInput = false;
        
        Debug.Log("Nova animação");
    }

    private void HandlePlayerInput()
    {
        switch(currentValidArrowInput){
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
}