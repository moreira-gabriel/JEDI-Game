using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneOnCollision : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private Vector3 oldPos;
    private float travelledDistance = 0f;
    [System.Serializable]

    public enum SceneIndex{
        FirstBallScene,
        SecondBallScene,
        ThirdBallScene
    }
    [Range(0,3)]
    public int sceneToBeLoaded;

    void Start() {
        oldPos = transform.position;
    }
    void Update() {
        Vector3 distanceVector = transform.position - oldPos;
        float distanceThisFrame = distanceVector.magnitude;
        travelledDistance += distanceThisFrame;
        oldPos = transform.position;
        if (travelledDistance > 5f) {
            this.GetComponent<AIFleeFromPlayer>().enabled = false;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (Vector2.Distance(transform.position, player.transform.position) < 1.5f && travelledDistance > 5f) {
            SceneManager.LoadScene(sceneToBeLoaded);
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) SceneManager.LoadScene(sceneToBeLoaded);
    }*/

}
