using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    private PlayerActions controls;

    private int currentHealth;

    private void Awake()
    {
        controls = new PlayerActions();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentHealth = hearts.Length;
        Debug.Log(currentHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (controls.PlayerControls.TakeDamage.WasPressedThisFrame())
        {
            TakeDamage();
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void TakeDamage()
    {
        
        if (currentHealth > 0)
        {
            currentHealth--;
        }
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("player dead");
        }

        UpdateHealth();
    }

    private void UpdateHealth()
    {
        hearts[currentHealth].enabled = false;
    }
}
