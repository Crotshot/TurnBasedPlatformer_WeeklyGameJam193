using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Additional : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] objects = new SpriteRenderer[0];
    [SerializeField] float[] heightOfActivation = new float[0];
    [SerializeField] float[] heightOfDeactivation = new float[0];
        
    private void FixedUpdate()
    {
        for (int i = 0; i < heightOfActivation.Length; i++) {
            if (transform.position.y > heightOfActivation[i]) {
                objects[i].enabled = true;
            }
            else if (transform.position.y < heightOfActivation[i]) {
                objects[i].enabled = false;
            }
            if (transform.position.y > heightOfDeactivation[i]) {
                objects[i].enabled = false;
            }
        }
    }
}
