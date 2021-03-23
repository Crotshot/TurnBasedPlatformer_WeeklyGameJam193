using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpForce = 2f;
<<<<<<< Updated upstream
    [SerializeField] float timeBetweenSteps = 1f;
    [SerializeField] GameObject feet;

    bool isTouchingGround = true;

    float timeSinceLastStep = Mathf.Infinity;
=======
    [SerializeField] float timeBetweenWalk = 0.5f;
    [SerializeField] GameObject feet = null;

    private float horizontalInput = 0f;
    private float verticalInput = 0f;
    private bool isJumping = false;
    private float timeSinceLastWalk = Mathf.Infinity;
    private bool songPlaying = false;
>>>>>>> Stashed changes

    Rigidbody2D rb2d = null;
    AudioManager audioManager = null;

    private void Start()
    {
        audioManager.Play("Song");
    }

    private void Awake()
    {
        //init!?
        rb2d = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
        FindObjectOfType<AudioManager>().Play("Song");
=======
        audioManager = FindObjectOfType<AudioManager>();
>>>>>>> Stashed changes
    }

    void FixedUpdate()
    {
<<<<<<< Updated upstream
        timeSinceLastStep += Time.deltaTime;

        //Horizontal Movement
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");


        //Should you be walking? can be negative value
        if(HorizontalInput != 0 && timeSinceLastStep > timeBetweenSteps && isTouchingGround)
        {
            FindObjectOfType<AudioManager>().Play("Walking");
            timeSinceLastStep = 0;
        }

        if (VerticalInput > 0 && isTouchingGround)
        {
            FindObjectOfType<AudioManager>().Play("Jumping");
        }


        //Movement
        transform.Translate(new Vector2(HorizontalInput * speed, VerticalInput * jumpForce)  * Time.deltaTime);
=======
        
        //Updating timer
        timeSinceLastWalk += Time.deltaTime;

        //Horizontal & Vertical Movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Will check for horizontal movement, can be -value.
        if(horizontalInput != 0 && !isJumping && timeSinceLastWalk > timeBetweenWalk)
        {
            audioManager.Play("Walking");
            //print("play sound");
            timeSinceLastWalk = 0;
        }

        //Vertical input will only play audio if going up.
        if (verticalInput > 0 && !isJumping)
        {
            audioManager.Play("Jumping");
            //print("play sound");
        }

        //Setting forces.
        transform.Translate(new Vector2(horizontalInput * speed, verticalInput * jumpForce)  * Time.deltaTime);
    }

    //Checking to see if the player has hit the ground.
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isJumping = false;
            //print(isJumping);
        }
        
    }

    //Checking to see if the player has taken a mad leap.
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isJumping = true;
            //print(isJumping);
        }
    }
>>>>>>> Stashed changes



    //Getters, used in ??
    public float getHorizontalInput()
    {
        return horizontalInput;
    }

<<<<<<< Updated upstream
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Ground") isTouchingGround = true;
        //print("enter");
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Ground") isTouchingGround = false;
        //print("exit");
    }

=======
    public float getVerticalInput()
    {
        return verticalInput;
    }
>>>>>>> Stashed changes
}

