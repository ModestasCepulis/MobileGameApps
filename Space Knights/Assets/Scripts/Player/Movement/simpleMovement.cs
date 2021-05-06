using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{
    Vector2 fingerPosition;
    public float movementSpeedXForward;
    public float movementSpeed;
    private Rigidbody2D rb;
    private Animator shipAnimator;

    //controller 
    private Joystick joystick;

    //ship vector2 pos
    private Vector2 shipMovement;

    //movement direction
    private Vector2 movementDirection;

    //ship in movement
    private float shipInMovement;

    //move direction for tresholds
    private float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shipAnimator = GetComponent<Animator>();

        joystick = FindObjectOfType<Joystick>();


    }

    // Update is called once per frame
    void Update()
    {
        shipMovement.x = joystick.Direction.x;
        shipMovement.y = joystick.Direction.y;


       // if(shipMovement)
        movementDirection = new Vector2(shipMovement.x, shipMovement.y);
        movementDirection.Normalize();


        shipInMovement = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);

        animateTheShip();


    }

    private void FixedUpdate()
    {
        if(movementDirection.x > 0)
        {
            rb.MovePosition(rb.position + movementDirection * movementSpeedXForward * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + movementDirection * movementSpeed * Time.deltaTime);
        }

    }

    public void animateTheShip()
    {
        if(movementDirection != Vector2.zero)
        {
            shipAnimator.SetFloat("Horizontal", movementDirection.x);
            shipAnimator.SetFloat("Vertical", movementDirection.y);
        }
        else if(shipInMovement <= 0)
        {
            shipAnimator.SetFloat("Horizontal", 0);
            shipAnimator.SetFloat("Vertical", 0);
        }

    }


}
