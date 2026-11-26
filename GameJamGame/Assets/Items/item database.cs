using UnityEngine;

public enum ItemSlot
{
    Head,
    Arms,
    Body,
    Legs,
   
}



[CreateAssetMenu(fileName = "itemdatabase", menuName = "Items/itemdatabase")]
public class itemdatabase : ScriptableObject
{
    
    public ItemSlot slot; 

    public string itemName;

    public int healthBuff;

    public int damageBuff;

    public float speedBuff;

    public int intelligenceBuff;

    public float visionBuff;

    public int hungerDebuff;

    public Sprite itemIcon;

    public Sprite partSprite;


}

