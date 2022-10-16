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
    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
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
        if (PlayerDetected) {
            Vector2 direction = (transform.position - player.transform.position);
            float distance = Vector2.Distance(transform.position, player.transform.position);
            rb.velocity = (3.5f - distance) * direction;
        }
        else {
            rb.velocity = Vector2.zero;
        }
    }
}
