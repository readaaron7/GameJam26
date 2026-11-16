using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;
    private int currencyCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateUI();
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
