using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColourCamera : MonoBehaviour
{
    private Camera mainCamera = null;
    private GameObject player = null;

    [SerializeField]
    private Color
    baseColor = new Color32(132, 214, 214, 255), spaceColor = new Color32(34, 27, 51, 255), heavenColor = new Color32(255, 223, 135, 255);
    [SerializeField] private float startingOffset = 30f;
    [SerializeField] private float maxHeight = 70f;
    [SerializeField] private float heavenHeight = 107f;
    [SerializeField] private float heavenStart = 84f;
    [SerializeField] private float maxHeavenHeight = 31f;


    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.transform.position.y > 0f && player.transform.position.y < heavenStart)
        {
            mainCamera.backgroundColor = Color.Lerp(baseColor, spaceColor, (player.transform.position.y - startingOffset) / maxHeight);

        }
        else
        {
            mainCamera.backgroundColor = Color.Lerp(spaceColor, heavenColor, (player.transform.position.y - heavenHeight) / maxHeavenHeight);
        }
    }
}
