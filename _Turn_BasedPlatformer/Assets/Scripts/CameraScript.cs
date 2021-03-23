using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player = null;
    [SerializeField] float distanceFromLevel = 20f;
    Vector3 position = new Vector3(0, 0, 0);

    void Update()
    {
        gameObject.transform.position = new Vector3(0, player.transform.position.y, distanceFromLevel * -1);
    }
}
