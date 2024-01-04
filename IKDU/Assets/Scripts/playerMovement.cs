using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D myBody;
    private Animator myAnimator;

    [SerializeField] private int speed = 5;

    /// <summary>
    /// on awake, which happens before start, 
    /// we get the components needed for the script to work (if we didnt do it in the script we would have to do it manually in Unity)
    /// </summary>
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    /// <summary>
    /// we get the value of vector2 (which we get from playerinputs) and see if our x or y is not 0
    /// if the statement is true, we set the animaters values and set the bool isWalking to true
    /// this will trigger the correct animations
    /// if the statement is false, we will stop the animation
    /// </summary>
    /// <param name="value"></param>
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

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

    /// <summary>
    /// our movement speed
    /// </summary>
    private void FixedUpdate()
    {
        myBody.velocity = movement * speed;
    }
}