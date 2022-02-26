using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public ItemObject[] itemObjects;

    public Transform itemWorldPrefab;

    public ItemObject GetItemObjectOfType(ItemObject.ItemType itemType)
    {
        foreach (var itemObj in itemObjects)
        {
            if (itemObj.type == itemType)
            {
                return itemObj;
            }
        }

        Debug.LogWarning("ItemAssets.cs , GetItemObjectOfType(ItemObject.ItemType) : Aucun objet de ce type !!!");
        return null;
    }
}
