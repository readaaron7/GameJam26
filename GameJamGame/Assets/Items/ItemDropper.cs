using UnityEngine;


public class ItemDropper : MonoBehaviour
{
    public itemdatabase[] allItems;
    public GameObject itemprefab;
    private EnemyHealth enemyHealth;

    [SerializeField] private float dropChance; // percentage chance of dropping an item
  

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
         
    }

   

    public void DropItem(Vector2 position)
    {
       
        // check if the enemy is dead
        if (enemyHealth.Health <= 0)
        {
            if(Random.value > dropChance / 100f)
            {
                Debug.Log("No item dropped");
                return;
            }
            if (allItems.Length == 0)
            {
                Debug.LogWarning("No items in the item database!");
                return;
            }
            else
            {
            int randomIndex = Random.Range(0, allItems.Length);
            itemdatabase item = allItems[randomIndex];
            // instantiate the item prefab at the enemy's position
            GameObject droppedItem = Instantiate(itemprefab, transform.position, 
            Quaternion.identity);

            droppedItem.GetComponent<SpriteRenderer>().sprite = item.itemIcon;
            droppedItem.GetComponent<ItemController>().item = item;
            }
        }
     
    }




   

}
