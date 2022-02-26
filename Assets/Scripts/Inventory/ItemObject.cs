using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemObject : ScriptableObject
{
    public enum ItemType
    {
        Bandage,
        Veste,
        OrbeEtrange
    }

    public string itemName;
    public ItemType type;
    public string pickUpDialogue;
    public Sprite sprite;
}
