using UnityEngine;

public class PlayerFreeMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rig;
    Vector2 movement;
    
    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer,6);

        rig = GetComponent<Rigidbody2D>(); 
    }
   
    void Update() => MovementInput();

    void FixedUpdate()
    {
        rig.velocity = movement * speed * Time.deltaTime;
    }

    void MovementInput () 
    {
        float mx = Input.GetAxis("Horizontal");
        float my = Input.GetAxis("Vertical");

        movement = new Vector2(mx, my);
    }
}
