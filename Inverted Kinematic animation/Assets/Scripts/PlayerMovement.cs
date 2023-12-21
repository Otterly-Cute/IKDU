using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movement;
    public Rigidbody2D myBody;
    public Animator myAnimator;
    public bool facingRight = true;

    [SerializeField] private float speed = 1.6f;

    public void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    public void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
        { Flip(); }
        else if (h < 0 && facingRight)
        { Flip(); }

        if (movement.x != 0 || movement.y != 0)
        {
            myAnimator.SetFloat("x", movement.x);
            myAnimator.SetFloat("y", movement.y);

            myAnimator.SetBool("isWalking", true);
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
        
       
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void FixedUpdate()
    {
        myBody.velocity = movement * speed;


    }
}
