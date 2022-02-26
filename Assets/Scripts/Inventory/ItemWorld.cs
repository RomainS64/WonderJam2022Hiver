using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private bool hasBeenClicked = false;
    public SpriteRenderer spriteRenderer;

    private ItemObject itemComp;
    public ItemObject ItemComp {
        get { return itemComp; }
        set
        {
            itemComp = value;
        } 
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, ItemObject.ItemType itemToSpawnType)
    {
        Transform transf = Instantiate(
            ItemAssets.Instance.itemWorldPrefab,
            position,
            Quaternion.identity);

        ItemWorld itemWorld = transf.GetComponent<ItemWorld>();
        itemWorld.ItemComp = ItemAssets.Instance.GetItemObjectOfType(itemToSpawnType);

        itemWorld.spriteRenderer = itemWorld.GetComponent<SpriteRenderer>();
        itemWorld.spriteRenderer.sprite = itemWorld.ItemComp.sprite;

        return itemWorld;
    }

    private void OnMouseDown()
    {
        if(!hasBeenClicked)
        {
            hasBeenClicked = true;

            FindObjectOfType<PlayerTestForInventory>().Inventory.AddItem(itemComp.type);
            spriteRenderer.sprite = null;
            //TODO : Display dialogue
            //Destroy(gameObject);
        }
    }
}
