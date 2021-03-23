using UnityEngine;

public class SpinMotion : MonoBehaviour
{
    [SerializeField] float degreePerSecond = 1f;


    void Update()
    {
        transform.Rotate(0, 0, degreePerSecond * Time.deltaTime);
    }
}