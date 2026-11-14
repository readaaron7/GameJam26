using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;
    private int currencyCount;

    private PlayerActions controls;

    private void Awake()
    {
        controls = new PlayerActions();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateUI();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        if (controls.PlayerControls.TakeDamage.WasPressedThisFrame())
        {
            addCurrency();
        }
    }


    public void addCurrency()
    {
        currencyCount++;
        updateUI();
    }

    private void updateUI()
    {
        currencyText.text = currencyCount.ToString();
    }
}
