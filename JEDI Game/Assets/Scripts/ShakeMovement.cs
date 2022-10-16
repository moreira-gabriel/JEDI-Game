using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMovement : MonoBehaviour
{
    public float speedX = 1f;
    public float speedY = 1f;

    private Vector2 movement;
  
    private Rigidbody2D rb;

    private float timer;

    [SerializeField]
    private float timeToReverseMovement = 0.5f;
    private int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(speedX, speedY);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeToReverseMovement){
            timer = 0;
            direction *= -1;
        }
    }

    private void FixedUpdate(){
       rb.velocity = movement * direction;
    }
}
