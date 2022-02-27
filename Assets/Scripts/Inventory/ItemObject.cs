using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemObject : ScriptableObject
{
    public enum ItemType
    {
        StatuetteGuide,
        Veste,
        OrbeEtrange,
        HoloparcheminEndommage,
        JoyauxIncandescent,
        DoigtDeRobot,
        PelucheEtrange
    }

    public string itemName;
    public bool nomEstFeminin;
    public ItemType type;

    [TextArea]
    public string choosingDialogue;

    [TextArea]
    public string pickUpDialogue;
    public Sprite sprite;
}
