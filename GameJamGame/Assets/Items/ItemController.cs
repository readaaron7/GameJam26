using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour
{
    public itemdatabase item; // reference to the item database
    public TextMeshPro itemNameText; // reference to the TextMeshPro component for displaying the item name

    private void Start()
    {
        
        // set the item name text to the name of the item from the database
        itemNameText.text = item.itemName;
       itemNameText.gameObject.SetActive(false); // hide the item name text initially
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // apply the item's buffs to the player
             itemNameText.gameObject.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // hide the item name text when the player exits the trigger
            itemNameText.gameObject.SetActive(false);
        }
    }

}
