using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float timeBetweenWalk = 0.18f;
    [SerializeField] float jumpTimer = 0.25f;

    [SerializeField] LayerMask mask;

    private float horizontalInput = 0f;
    private float verticalInput = 0f;
    private bool airborn = false;
    private float timeSinceLastWalk = Mathf.Infinity, timeSinceLastJump = Mathf.Infinity;


    Rigidbody2D rb2d = null;
    AudioManager audioManager = null;


    private void Awake()
    {
        //init!?
        rb2d = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        audioManager.Play("Song");
    }

    void FixedUpdate()
    {
        //Ray to check if on ground
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.down * 0.25f, mask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.down * 0.25f, Color.green);

        float distance = 1f;
        if (hit.collider != null) {
            distance = Mathf.Abs(hit.point.y - transform.position.y);
        }
        if (distance < 0.3f) {
            airborn = false;
        }
        else {
            airborn = true;
        }

        //Updating timers
        timeSinceLastWalk += Time.deltaTime;
        timeSinceLastJump += Time.deltaTime;

        //Horizontal & Vertical Movement Input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Will check for horizontal movement, can be -value.
        if(horizontalInput != 0 && !airborn && timeSinceLastWalk > timeBetweenWalk)
        {
            audioManager.Play("Walking");
            timeSinceLastWalk = 0;
        }

        //Left and right movement
        transform.Translate(new Vector2(horizontalInput * speed * Time.deltaTime, 0));


        //Vertical input will only play audio if going up.
        if (verticalInput > 0 && !airborn &&  timeSinceLastJump > jumpTimer)
        {
            timeSinceLastJump = 0;
            audioManager.Play("Jumping");
            //Jump force
            rb2d.AddForce(Vector2.up * jumpForce);
        }
    }

    //Getters, used in animation controller of player
    public float getVerticalInput()
    {
        return verticalInput;
    }

    public float getHorizontalInput()
    {
        return horizontalInput;
    }
}

/*
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
*/