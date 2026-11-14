using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float roomWidth;
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
        int roomIndex = Mathf.FloorToInt(player.position.x / roomWidth);

        float targetX = roomIndex * roomWidth + roomWidth / 2f;

        targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        
        
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    public void MoveToRoom(Vector3 roomCenter)
    {
        Debug.Log(roomCenter.x);
        Debug.Log(roomCenter.y);
        
        targetPosition = new Vector3(roomCenter.x, roomCenter.y, transform.position.z);
    }
}
