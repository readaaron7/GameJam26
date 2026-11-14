using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerActions controls; // get access to the player controls
    private Vector2 moveInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    private Rigidbody2D body;

    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 rayStartPosition;

    private bool isGrounded;


    private void Awake()
    {
        controls = new PlayerActions();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // reads the movement of the player
        moveInput = controls.PlayerControls.Move.ReadValue<Vector2>();

        // update position of player
        body.linearVelocity = new Vector2(moveInput.x * moveSpeed, body.linearVelocity.y);

        // JUMP
        if (controls.PlayerControls.Jump.WasPressedThisFrame() && isGrounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
        }

        // GROUND DETECTION
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
    }

    private void OnEnable()
    {
        controls.Enable(); // enables the controls when the gameobject is enabled
    }

    private void OnDisable()
    {
        controls.Disable(); // disables the controles when the gameobjec is disabled
    }


    // visual raycast (for testing)
    private void OnDrawGizmos()
{
    Gizmos.color = Color.red;

    Gizmos.DrawLine(
        transform.position,
        transform.position + Vector3.down * groundCheckDistance
    );
}
}
