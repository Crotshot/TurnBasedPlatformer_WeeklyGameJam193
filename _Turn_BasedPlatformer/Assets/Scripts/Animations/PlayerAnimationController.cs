using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimationController : MonoBehaviour
{
    private PlayerController playerController = null;
    private Animator playerAnimator = null;
    private SpriteRenderer playerSpriteRender = null;
    [SerializeField] private SpriteRenderer[] adds = new SpriteRenderer[0];

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
            foreach(SpriteRenderer sp in adds) {
                if (sp.enabled) {
                    sp.flipX = false;
                }
            }
        }
        //playerRunningRight
        else if(playerController.getHorizontalInput() < 0){
            playerAnimator.SetBool("isRunning",true);
            playerSpriteRender.flipX = true;
            foreach (SpriteRenderer sp in adds) {
                if (sp.enabled) {
                    sp.flipX = true;
                }
            }
        }
        //playerIdle
        else if(playerController.getHorizontalInput() == 0 && playerController.getVerticalInput() == 0){
            playerAnimator.SetBool("isRunning",false);
            playerAnimator.SetBool("isJumping",false);
            playerSpriteRender.flipX = false;
            foreach (SpriteRenderer sp in adds) {
                if (sp.enabled) {
                    sp.flipX = false;
                }
            }
        }
        
        //playerJumpLeft
        if(playerController.getHorizontalInput() <= 0 && playerController.getVerticalInput() > 0){
            playerAnimator.SetBool("isRunning",false);
            playerAnimator.SetBool("isJumping",true);
        }
        //playerJumpRight
        else if(playerController.getHorizontalInput() > 0 && playerController.getVerticalInput() > 0){
            playerAnimator.SetBool("isRunning",false);
            playerAnimator.SetBool("isJumping",true);
        }
        //Jump Idle
        else if (playerController.getHorizontalInput() == 0 && playerController.getVerticalInput() > 0){
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetBool("isJumping", true);
        }
        //playerNotJumping
        if(playerController.getVerticalInput() == 0){
             playerAnimator.SetBool("isJumping",false);
        }
    }
}
