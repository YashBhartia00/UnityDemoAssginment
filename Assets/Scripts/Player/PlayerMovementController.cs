using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpVelocity = 5f;

    private bool isJumping = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Subscribe to the Space key event (observer pattern for input manager)
        InputManager.instance.OnSpacePressed += Jump;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);
    }

    void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isJumping = false;
    }


    void OnDestroy()
    {
        //unsubscribe to event when object destroyed to avoid duplicating
        if (InputManager.instance != null)
            InputManager.instance.OnSpacePressed -= Jump;
    }

}
