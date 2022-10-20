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

    [Range(0,3)]
    public int sceneToBeLoaded;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) SceneManager.LoadScene(sceneToBeLoaded);
        
    }

}
