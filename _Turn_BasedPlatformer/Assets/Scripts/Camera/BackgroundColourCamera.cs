using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColourCamera : MonoBehaviour
{
    private Camera mainCamera = null;
    private GameObject player = null;
    private Transform playerPos = null;

    [SerializeField] private Color 
    baseColor = new Color32(132,214,214,255), spaceColor = new Color32(34,27,51,255);



    [SerializeField] private float maxHeight = 500f;

    

    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.Find("Player");
    }


    void Update()
    {
        playerPos = player.transform;
       
        
        if(playerPos.position.y > 0f && playerPos.position.y < 500f){
            mainCamera.backgroundColor = Color.Lerp(baseColor, spaceColor, (playerPos.position.y)/maxHeight);

        }
    }
}
