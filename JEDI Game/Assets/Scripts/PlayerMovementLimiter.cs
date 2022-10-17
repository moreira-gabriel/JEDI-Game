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
    [SerializeField] private List<PlayableAsset> playableAssets = new List<PlayableAsset>();

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
    }

    void PlayFirstAnimation()
    {        
        handlingPlayerInput = false;
        
        timeline.Play(playableAssets[0]);

        playableAssets.RemoveAt(0);
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