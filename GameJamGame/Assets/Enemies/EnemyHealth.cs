using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyPatrolMovement patrolScript;
    [SerializeField] private EnemyAttack attackScript;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // tells if the enemy attached to this script is a boss or not
    [SerializeField] private bool isBoss;


    public void TakeDamage()
    {
        health--;

        if (health > 0)
        {
            StartCoroutine(FlashRed());
        }
        

        if (health <= 0)
        {
            // stop enemy moving
            patrolScript.enabled = false;
            attackScript.enabled = false;


            animator.SetTrigger("Die");
            
            GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject, 1); // gets rid of the enemy game object when dead
            

            if (isBoss)
            {
                // switches to the game completed scene
                SceneManager.LoadScene("GameComplete");
            }
        }
    }

    private IEnumerator FlashRed()

    {
        spriteRenderer.color = Color.red;

        // waits 0.1 seconds, then continues
        yield return new WaitForSeconds(0.25f);

        spriteRenderer.color = Color.white; // return back to normal color
    }
}
