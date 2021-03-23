using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpForce = 2f;

    private float horizontalInput = 0f;
    private float verticalInput = 0f;


    Rigidbody2D rb2d = null;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public float getHorizontalInput(){
        return horizontalInput;
    }
    public float getVerticalInput(){
        return verticalInput;
    }
    void FixedUpdate()
    {
        //Horizontal Movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(horizontalInput * speed, verticalInput * jumpForce)  * Time.deltaTime);


    }

}

