using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimationController : MonoBehaviour
{
    private PlayerController playerController = null;
    private Animator playerAnimator = null;
    private SpriteRenderer playerSpriteRender = null;

    void Start(){
        playerController = gameObject.GetComponent<PlayerController>();
        playerAnimator = gameObject.GetComponent<Animator>();
        playerSpriteRender = gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        //playerRunningLeft
        if(playerController.getHorizontalInput() > 0){
            playerAnimator.SetBool("isRunning",true);
            playerSpriteRender.flipX = false;
        }
        //playerRunningRight
        if(playerController.getHorizontalInput() < 0){
            playerAnimator.SetBool("isRunning",true);
            playerSpriteRender.flipX = true;
        }
        //playerIdle
        if(playerController.getHorizontalInput() == 0 && playerController.getVerticalInput() == 0){
            playerAnimator.SetBool("isRunning",false);
            playerAnimator.SetBool("isJumping",false);
            playerSpriteRender.flipX = false;
        }
        
        //playerJumpLeft
        if(playerController.getHorizontalInput() <= 0 && playerController.getVerticalInput() > 0){
            playerAnimator.SetBool("isRunning",false);
            playerAnimator.SetBool("isJumping",true);
            playerSpriteRender.flipX = true;
        }
        //playerJumpRight
        if(playerController.getHorizontalInput() > 0 && playerController.getVerticalInput() > 0){
            playerAnimator.SetBool("isRunning",false);
            playerAnimator.SetBool("isJumping",true);
            playerSpriteRender.flipX = false;
        }
        //playerNotJumping
        if(playerController.getVerticalInput() == 0){
             playerAnimator.SetBool("isJumping",false);
        }

        
    }


}
