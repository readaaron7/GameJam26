using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    public void MoveToRoom(Vector3 roomCenter)
    {
        targetPosition = new Vector3(roomCenter.x, roomCenter.y, transform.position.z);
    }
}
