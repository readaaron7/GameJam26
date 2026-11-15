using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float roomWidth;
    [SerializeField] private float roomHeight;
    [SerializeField] private float moveSpeed;
    private Vector3 targetPosition;
    private Vector3 originalPosition;
    private Vector3 cameraShakeOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        targetPosition = transform.position;
        cameraShakeOffset = Vector3.zero;
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
            targetPosition + cameraShakeOffset, // includes the shake effect in movement
            moveSpeed * Time.deltaTime
        );
    }

    public void CameraShake(float duration, float magnitude)
    {
        StartCoroutine(CameraShakeCoroutine(duration, magnitude));
    }

    private IEnumerator CameraShakeCoroutine(float duration, float magnitude)
    {
        originalPosition = transform.position;

        float timeElapsed = 0f;

        // while there is still a duration
        while (timeElapsed < duration)
        {
            // randomizes the camera shake offset using the magnitude of the shake
            cameraShakeOffset = new Vector3(
                Random.Range(-magnitude, magnitude),
                Random.Range(-magnitude, magnitude),
                0
            );

            // increase time
            timeElapsed += Time.deltaTime;

            yield return null; // pause, then continue to next frame
        }

        cameraShakeOffset = Vector3.zero; // resets offest back to zero after shaking is done
    }
}
