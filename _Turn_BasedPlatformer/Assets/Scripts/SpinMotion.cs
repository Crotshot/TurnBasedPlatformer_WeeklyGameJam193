using UnityEngine;

public class SpinMotion : MonoBehaviour
{
    [SerializeField] float dgreePerSecond = 1f;


    void Update()
    {
        transform.Rotate(0, 0, dgreePerSecond * Time.deltaTime);
    }
}
