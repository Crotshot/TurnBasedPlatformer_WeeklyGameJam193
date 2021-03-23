using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColourCamera : MonoBehaviour
{
    private Camera mainCamera = null;
    private GameObject player = null;

    [SerializeField] private Color 
    baseColor = new Color32(132,214,214,255), spaceColor = new Color32(34,27,51,255);
    [SerializeField] private float maxHeight = 500f;

   
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {   
        if(player.transform.position.y > 0f && player.transform.position.y < 500f){
            mainCamera.backgroundColor = Color.Lerp(baseColor, spaceColor, (player.transform.position.y)/maxHeight);

        }
    }
}
