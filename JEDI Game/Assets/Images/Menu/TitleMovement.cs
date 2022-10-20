using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TitleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    private Vector2 topPosition;
    private Vector2 botPosition;
    private Vector2 nextPosition;

    private void Start()
    {
        topPosition = new Vector2(transform.position.x, 2.75f);
        botPosition = new Vector2(transform.position.x, 1.25f);
        nextPosition = botPosition;
    }

    private void FixedUpdate()
    {
        if(transform.position.y >= topPosition.y){
            nextPosition = botPosition;
        }else if(transform.position.y <= botPosition.y){
            nextPosition = topPosition;
        }

        Movement(nextPosition);
    }

    void Movement(Vector2 nextPosition){
        transform.position = Vector2.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }
}