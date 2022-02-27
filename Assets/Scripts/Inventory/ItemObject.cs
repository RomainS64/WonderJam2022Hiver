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

    [TextArea]
    public string choosingDialogue;

    [TextArea]
    public string pickUpDialogue;
    public Sprite sprite;
}
