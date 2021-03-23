using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float timeBetweenSteps = 1f;
    [SerializeField] GameObject feet;

    bool isTouchingGround = true;

    float timeSinceLastStep = Mathf.Infinity;

    Rigidbody2D rb2d = null;

    private void Awake()
    {
        //init!?
        rb2d = GetComponent<Rigidbody2D>();
        FindObjectOfType<AudioManager>().Play("Song");
    }

    void FixedUpdate()
    {
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


    }

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

}

