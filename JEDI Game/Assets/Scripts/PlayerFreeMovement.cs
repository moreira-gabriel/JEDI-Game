using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeMovement : MonoBehaviour
{
    public Vector2 speed;

    private double verticalCameraLimit = 4.45;
    private double horizontalCameraLimit = 7.45;

    [SerializeField]   private Rigidbody2D rb;

    Vector2 movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    private void FixedUpdate(){
        rb.velocity = movement * speed;
    }

    void MovementInput () {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;

    }
}
