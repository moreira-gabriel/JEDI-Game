using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class AIFleeFromPlayer : MonoBehaviour
{
    public bool PlayerDetected { get; private set; }
    private string playerTag = "Player";
    private GameObject player;
    private Rigidbody2D rb;

    [SerializeField]
    private float maxSpeed = 1.5f;

    public float speedX = 1f;
    public float speedY = 1f;

    private Vector2 movement;
  
    private float timer;

    [SerializeField]
    private float timeToReverseMovement = 0.5f;
    private int direction = 1;
    

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
                movement = new Vector2(speedX, speedY);

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(playerTag)) {
            PlayerDetected = true;
            player = collision.gameObject;
        }
    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag(playerTag)) {
            PlayerDetected = false;
            player = null;
        }
    }
    private void Update() {
        // Only meth here ok?
        if (PlayerDetected) {
            Vector2 direction = (transform.position - player.transform.position);
            float distance = Vector2.Distance(transform.position, player.transform.position);
            direction = direction/distance;
            rb.velocity = (direction/ distance) / maxSpeed;
            
            
            Debug.Log("Velocity -->" + direction/distance);
            Debug.Log("direction -->" + direction);
            Debug.Log("distance -->" + distance);

        }
        else {
            rb.velocity = Vector2.zero;
        }
        if(!PlayerDetected){
            timer += Time.deltaTime;
            if(timer >= timeToReverseMovement){
                timer = 0;
                direction *= -1;
            }
               rb.velocity = movement * direction;
        }

        
    }


    
    
   

   
}