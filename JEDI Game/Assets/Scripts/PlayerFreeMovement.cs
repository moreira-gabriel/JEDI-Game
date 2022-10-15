using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeMovement : MonoBehaviour
{
    public Vector2 speed;

    [SerializeField]   private Rigidbody2D rb;

    Vector2 movement;
   
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
