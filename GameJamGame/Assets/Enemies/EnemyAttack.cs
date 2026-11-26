using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private float timeElapsed;
    private bool canAttack;
    [SerializeField] private Animator slashAnimator;

    private PlayerMovement isInvulnerable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        isInvulnerable = player.GetComponent<PlayerMovement>();
        canAttack = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!canAttack)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= attackCooldown)
            {
                canAttack = true;
                timeElapsed = 0f;
            }
        }
    }


    // when the player runs into the enemy, the player will take damage
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canAttack && !isInvulnerable.isInvulnerable)
        {
            // gets the player's health component
            Health playerHealth = collision.GetComponent<Health>();
        
            playerHealth.TakeDamage();
            slashAnimator.Play("AttackSlash", 0, 0); // play the slash attack animation once
            canAttack = false;
            
        }
    }
}
