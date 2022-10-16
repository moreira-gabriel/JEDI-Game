using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneOnCollision : MonoBehaviour
{
    [System.Serializable]
    public enum SceneIndex{
        FirstBallScene,
        SecondBallScene,
        ThirdBallScene
    }

    [Range(1,3)]
    public int SceneToBeLoaded;


    void OnCollisionEnter2D(Collision2D collision)
    {
        
            SceneManager.LoadScene("InitialScene");
        
    }

}
