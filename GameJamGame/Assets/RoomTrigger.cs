using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private Transform roomCenter;
    private CameraController cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // gets the main camera
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(roomCenter.position.x);
            Debug.Log(roomCenter.position.y);
            cam.MoveToRoom(roomCenter.position);
        }
    }
}
