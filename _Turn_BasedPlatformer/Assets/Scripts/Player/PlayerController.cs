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

    private float horizontalInput = 0f;
    private float verticalInput = 0f;
    private bool airborne = false;
    private float timeSinceLastWalk = Mathf.Infinity, timeSinceLastJump = Mathf.Infinity;
    private Rigidbody2D rb2d = null;
    private AudioManager audioManager = null;


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
        //Rays to check if on standable layer
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.2f, transform.position.y -0.1f), Vector2.down, 0.275f);
        Debug.DrawRay(new Vector2(transform.position.x + 0.2f, transform.position.y - 0.1f), Vector2.down * 0.275f, Color.green);
        Debug.DrawRay(new Vector2(transform.position.x - 0.13f, transform.position.y - 0.1f), Vector2.down * 0.275f, Color.blue);

        if (hitRight.collider != null) {
            Debug.DrawLine(new Vector2(transform.position.x + 0.2f, transform.position.y - 0.1f), hitRight.point, Color.red, 1);
            if (airborne) {
                audioManager.Play("Landing");
            }
            airborne = false;
        }
        else{ //If right ray does not collide use left ray
            RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 0.13f, transform.position.y - 0.1f), Vector2.down, 0.275f);
            if (hitLeft.collider != null) {

                Debug.DrawLine(new Vector2(transform.position.x - 0.13f, transform.position.y - 0.1f), hitLeft.point, Color.yellow, 1);

                if (airborne) {
                    audioManager.Play("Landing");
                }
                airborne = false;
            }
            else { //If left ray does not collide we are airborne
                airborne = true;
            }
        }

        //Updating timers
        timeSinceLastWalk += Time.deltaTime;
        timeSinceLastJump += Time.deltaTime;

        //Horizontal & Vertical Movement Input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Will check for horizontal movement, can be -value.
        if(horizontalInput != 0 && !airborne && timeSinceLastWalk > timeBetweenWalk)
        {
            audioManager.Play("Walking");
            timeSinceLastWalk = 0;
        }

        if(horizontalInput < 0) {
            transform.Translate(new Vector2(horizontalInput * speed * 1.2f * Time.deltaTime, 0));
        }
        else if (horizontalInput > 0) {
            transform.Translate(new Vector2(horizontalInput * speed* 0.8f * Time.deltaTime, 0));
        }
        //Left and right movement
       


        //Vertical input will only play audio if going up.
        if (verticalInput > 0 && !airborne &&  timeSinceLastJump > jumpTimer)
        {
            rb2d.velocity = Vector2.zero;
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