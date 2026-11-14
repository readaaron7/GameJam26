using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float roomWidth;
    [SerializeField] private float roomHeight;
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
        // calcules both room indexes based on the player's position
        int roomX = Mathf.FloorToInt(player.position.x / roomWidth);
        int roomY = Mathf.FloorToInt(player.position.y / roomHeight);

        // calcultes the target position for the camera to move
        float targetX = roomX * roomWidth + roomWidth / 2f;
        float targetY = roomY * roomHeight + roomHeight / 2f;

        targetPosition = new Vector3(targetX, targetY, transform.position.z);
        
        
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }
}
