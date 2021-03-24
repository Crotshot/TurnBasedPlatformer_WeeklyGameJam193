using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] private GameObject killBoxLeft = null;
    [SerializeField] private GameObject killBoxRight = null;
    [SerializeField] private GameObject GameOverPanel = null;

    private bool isOver = false;
    private Color startingColor = new Color32(22,22,22,0), EndingColor = new Color32(22,22,22,255);
    private CapsuleCollider2D playerCollider = null;
    private float timeWhileGameOver;


    void Start(){
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        GameOverPanel.SetActive(false);
    }

    void FixedUpdate(){

       if( killBoxLeft.GetComponent<BoxCollider2D>().IsTouching(playerCollider) ||  killBoxRight.GetComponent<BoxCollider2D>().IsTouching(playerCollider)){
           GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
           GameOverPanel.SetActive(true);
           isOver = true;     
       }
       if(isOver){
            timeWhileGameOver += Time.deltaTime/fadeDuration;
            GameOverPanel.GetComponent<Image>().color = Color.Lerp(startingColor, EndingColor, timeWhileGameOver);
       }

       
    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu(){
        SceneManager.LoadScene(1);
    }
}
