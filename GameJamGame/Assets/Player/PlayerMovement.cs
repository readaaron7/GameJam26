using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerActions controls; // get access to the player controls
    private Vector2 moveInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    // double jump logic variables
    private int jumpsRemaining;
    private const int MAX_JUMPS = 2;
    private Rigidbody2D body;

    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;

    private bool isGrounded;
    private bool wasGrounded;


    private void Awake()
    {
        controls = new PlayerActions();
        body = GetComponent<Rigidbody2D>();

        isGrounded = true;

        if (isGrounded)
        {
            jumpsRemaining = MAX_JUMPS; // initialize remaining jumps
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // reads the movement of the player
        moveInput = controls.PlayerControls.Move.ReadValue<Vector2>();

        // update position of player each frame
        body.linearVelocity = new Vector2(moveInput.x * moveSpeed, body.linearVelocity.y);

        // JUMP
        // normal jumping if the player is grounded
        // if (controls.PlayerControls.Jump.WasPressedThisFrame() && isGrounded)
        // {
        //     Jump();
        // }
        // double jumping if the player has jumps remaining
        if (controls.PlayerControls.Jump.WasPressedThisFrame() && jumpsRemaining > 0)
        {
            Jump();
            jumpsRemaining--;
        }

        // GROUND DETECTION
        groundDetection();

        if (isGrounded && !wasGrounded)
        {
            jumpsRemaining = MAX_JUMPS;
        }

        // set if the player was grounded this frame
        // need to work for double jump detection
        wasGrounded = isGrounded;

        if (controls.PlayerControls.DropThroughPlatform.WasPressedThisFrame() && isGrounded)
        {
            // create raycast to check ground
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                Vector2.down,
                groundCheckDistance,
                groundLayer
            );

            // make sure player is standing on a platform
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("OneWayPlatform"))
            {
                // performs some logic with the player dropping through the platform,
                // pauses everything in update, then continues after function finishes
                StartCoroutine(DropThroughPlatform());
            }
            
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
            (Vector2)transform.position + Vector2.down * 0.8f,
            transform.position + Vector3.down * groundCheckDistance
        );
    }

    private void groundDetection()
    {
        RaycastHit2D hit = CreateRaycast();

        if (hit.collider != null)
        {
            // player raycast shouldn't be grounded while jumping through platform
            bool isPlatform = hit.collider.gameObject.layer == LayerMask.NameToLayer("OneWayPlatform");
            if (isPlatform && body.linearVelocity.y > 0f)
            {
                isGrounded = false;
                return;
            }

            isGrounded = true;
        }
        else
        {
            // not grounded because hit collider is null
            isGrounded = false;
        }
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
    }

    private IEnumerator DropThroughPlatform()
    {
        // creates a new raycast to detect the platform to store it's collider
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );

        // if raycast doesn't hit anything
        if (hit.collider == null)
        {
            // stop the function
            yield break;
        }

        // disables the platform's collider which is what the raycast hit
        hit.collider.enabled = false;

        // waits 0.25 seconds, then continues
        yield return new WaitForSeconds(0.30f);

        // enables the platform's collider which is what the raycast hit
        hit.collider.enabled = true;


    }

    private RaycastHit2D CreateRaycast()
    {
        Vector2 rayPosition = (Vector2)transform.position + Vector2.down * 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(
            rayPosition,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );
        
        return hit;
    }
}
