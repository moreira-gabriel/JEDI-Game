using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
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
        PlayingScene,
    };
    
    [Header("Game Objects")]
    [SerializeField] GameObject rightArrowObject;
    [SerializeField] GameObject leftArrowObject;
    [SerializeField] GameObject upArrowObject;
    [SerializeField] GameObject downArrowObject;
    [SerializeField] PlayableDirector playableDirector;

    [Header("Cutscene Settings")]
    [SerializeField] List<ArrowInput> validArrowInputOrder = new List<ArrowInput>();
    [SerializeField] GameState gameState = GameState.Starting;

    bool acceptInput = false;

    [SerializeField]

    void Awake() 
    {
        upArrowObject.SetActive(false);
        downArrowObject.SetActive(false);
        rightArrowObject.SetActive(false);
        leftArrowObject.SetActive(false);
    }

    public void PauseTimeline()
    {
        gameState = GameState.WaitingInput;

        playableDirector.playableGraph.GetRootPlayable(0).Pause();

        switch (validArrowInputOrder[0])
        {
            //Up
            case ArrowInput.Up:
                upArrowObject.SetActive(true);
                break;
            
            //Down
            case ArrowInput.Down:
                downArrowObject.SetActive(true);
                break;

            //Right
            case ArrowInput.Right:
                rightArrowObject.SetActive(true);
                break;
            
            //Left
            case ArrowInput.Left:
                leftArrowObject.SetActive(true);
                break;

            default:
                WrongInput();                    
                break;
        }

        acceptInput = true;
        
        Debug.Log("Pause");
    }

    void PlayTimeline()
    {
        gameState = GameState.PlayingScene;
        
        acceptInput = false;

        if(upArrowObject.activeSelf) StartCoroutine(upArrowObject.GetComponent<AutoDestroy>().PlayAnimationAndDestroy());
        if(downArrowObject.activeSelf) StartCoroutine(downArrowObject.GetComponent<AutoDestroy>().PlayAnimationAndDestroy());
        if(rightArrowObject.activeSelf) StartCoroutine(rightArrowObject.GetComponent<AutoDestroy>().PlayAnimationAndDestroy());
        if(leftArrowObject.activeSelf) StartCoroutine(leftArrowObject.GetComponent<AutoDestroy>().PlayAnimationAndDestroy());

        playableDirector.playableGraph.GetRootPlayable(0).Play();

        validArrowInputOrder.RemoveAt(0);

        Debug.Log("Play");
    }

    void WrongInput()
    {
        Debug.Log("wrong");
    }
    void VerifyInput()
    {
        if(gameState == GameState.WaitingInput)
        {
            switch (validArrowInputOrder[0])
            {
                //Up
                case ArrowInput.Up:
                    if(Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        PlayTimeline();
                    }
                    break;
                
                //Down
                case ArrowInput.Down:
                    if(Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        PlayTimeline();
                    }
                    break;

                //Right
                case ArrowInput.Right:
                    if(Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        PlayTimeline();
                    }
                    break;
                
                //Left
                case ArrowInput.Left:
                    if(Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        PlayTimeline();
                    }
                    break;

                default:
                    WrongInput();                    
                    break;
            }
        }
    }

    void Update() 
    {
        if(acceptInput)
        {
            VerifyInput();
        }
    }
    

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}