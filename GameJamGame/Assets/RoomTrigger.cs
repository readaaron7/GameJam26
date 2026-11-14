using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private Transform roomCenter;
    [SerializeField] private CameraController cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        cam = GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.MoveToRoom(roomCenter.position);
        }
    }
}
