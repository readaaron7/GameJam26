using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerActions controls;
    public EnemyHealth enemyInRange;
    [SerializeField] private Animator slashAnimator;
    [SerializeField] private float attackCooldown;
    private float attackTimer;
    private bool canAttack;

     

    private void Awake()
    {
        controls = new PlayerActions();
        slashAnimator.speed = 0;
        canAttack = true;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    private void Update()
    {
        if (controls.PlayerControls.StandardAttack.WasPressedThisFrame() && canAttack)
        {
            slashAnimator.speed = 1; // changes speed back to normal so that animation
            // didn't run at the start of the game
            slashAnimator.Play("AttackSlash", 0, 0);
            
            if (enemyInRange != null)
            {
                enemyInRange.TakeDamage();
            }

            canAttack = false;
        }

        // tracks if the player can't attack (resets their attack cooldown)
        if (!canAttack)
        {
            attackTimer += Time.deltaTime;
            
            if (attackTimer >= attackCooldown)
            {
                canAttack = true;
                attackTimer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyInRange = collision.GetComponent<EnemyHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyInRange = null;
        }
    }
}
