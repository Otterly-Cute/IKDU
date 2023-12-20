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

    [SerializeField] private float speed = 1.4f;

    public void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    public void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();


        if (movement.x != 0 || movement.y != 0)
        {
            myAnimator.SetFloat("x", movement.x);
           // this.transform.Translate(new Vector3(movement.x,0), Space.World);
            myAnimator.SetFloat("y", movement.y);

            myAnimator.SetBool("isWalking", true);
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
        
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
        { Flip(); }
        else if (h < 0 && facingRight)
        { Flip(); }
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

       /* bool flipped=movement.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f)); */
    }
}
