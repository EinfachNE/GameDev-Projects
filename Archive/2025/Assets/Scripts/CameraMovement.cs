using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform player;

    private void Update()
    {
        cam.transform.position = new Vector3(player.position.x, player.position.y ,-10f);  
    }
}
