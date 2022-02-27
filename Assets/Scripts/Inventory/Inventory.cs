using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<ItemObject> items;

    public Inventory()
    {
        items = new List<ItemObject>();
    }

    public void AddItem(ItemObject.ItemType itemType)
    {
        ItemObject newItem = ItemAssets.Instance.GetItemObjectOfType(itemType);
        if (newItem != null)
        {
            items.Add(newItem);
        }

        DisplayInventoryInConsole();
    }

    public void RemoveItem(ItemObject item)
    {
        if (items.Contains(item))
        {
            Debug.Log("Je Remove");
            items.Remove(item);
        }
    }

    public bool RemoveItemOfType(ItemObject.ItemType itemType)
    {
        foreach (var item in items)
        {
            if(item.type == itemType)
            {
                RemoveItem(item);
                return true;
            }
        }

        return false;
    }

    public ItemObject FindItemOfType(ItemObject.ItemType itemTypeToFind)
    {
        foreach (ItemObject item in items)
        {
            if (item.type == itemTypeToFind)
            {
                return item;
            }
        }

        return null;
    }

    public ItemObject FindRandomItem()
    {
        int randomIntemIndex = Random.Range(0, items.Count);

        return items[randomIntemIndex];
    }

    public void ClearInventory()
    {
        Debug.Log("Clearing inventory...");
        items.Clear();
    }

    public void DisplayInventoryInConsole()
    {
        Debug.Log("====== INVENTORY ======");
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log("Item n" + i + ": " + items[i].type.ToString());
        }
    }
}
