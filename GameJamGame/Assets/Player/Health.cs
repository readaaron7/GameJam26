using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement movementScript;
    [SerializeField] private PlayerAttack attackScript;
    [SerializeField] private CameraController cam;

    private int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentHealth = hearts.Length;
    }

    public void TakeDamage()
    {
        currentHealth--;
        
        if (currentHealth <= 0)
        {
            cam.playerIsAlive = false;
            currentHealth = 0;
            animator.speed = 0f;

            Destroy(gameObject); // gets rid of the player game object when dead

            // stop player moving
            movementScript.enabled = false;
            attackScript.enabled = false;

            GetComponent<Collider2D>().enabled = false;

            
        }

        UpdateHealth();
    }

    private void UpdateHealth()
    {
        // iterates through player hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
