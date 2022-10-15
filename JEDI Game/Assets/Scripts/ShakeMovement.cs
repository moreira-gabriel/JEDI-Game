using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMovement : MonoBehaviour
{
    public float speedX = 10f;
    public float speedY = 10f;

    [SerializeField]
    private enum Axis{
        Horizontal,
        Vertical,
        Diagonal
    }

    private Vector2 movement;
    private Rigidbody2D rb;

    private float timer;

    [SerializeField]
    private float timeToReverseMovement = 0.5f;

    private int direction = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeToReverseMovement){
            timer = 0;
            direction = direction * -1;
        }

    }

    private void FixedUpdate(){
        movement = new Vector2(speedX * direction, speedY);
        rb.velocity = movement * speedX;
    }

    

}
