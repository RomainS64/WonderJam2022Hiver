using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public bool isClicked = false;
    public SpriteRenderer spriteRenderer;

    private ItemObject itemComp;
    public ItemObject ItemComp {
        get { return itemComp; }
        set
        {
            itemComp = value;
        } 
    }

    public static ItemWorld SpawnItemWorld(Transform transformSpawnPoint, ItemObject.ItemType itemToSpawnType)
    {
        
        Transform transf = Instantiate(
            ItemAssets.Instance.itemWorldPrefab,
            transformSpawnPoint.position,
            Quaternion.identity,
            transformSpawnPoint);

        ItemWorld itemWorld = transf.GetComponent<ItemWorld>();
        itemWorld.ItemComp = ItemAssets.Instance.GetItemObjectOfType(itemToSpawnType);

        itemWorld.spriteRenderer = itemWorld.GetComponent<SpriteRenderer>();
        itemWorld.spriteRenderer.sprite = itemWorld.ItemComp.sprite;

        return itemWorld;
    }

    private void Update()
    {
        if (Click.IsClickingOn(gameObject) && !isClicked)
        {
            isClicked = true;
            FindObjectOfType<Choise>().StartChoise(itemComp.choosingDialogue, DIALOGUES.tresorRep1, DIALOGUES.tresorRep2, DontTake, Take);
        }
    }
    private void DontTake()
    {
        isClicked = false;

        //FindObjectOfType<Pensees>().StartPensee(DIALOGUES.tresorLaisser);
    }

    private void Take()
    {
        isClicked = false;

        FindObjectOfType<Pensees>().StartPensee(itemComp.pickUpDialogue);

        FindObjectOfType<PlayerTestForInventory>().Inventory.AddItem(itemComp.type);

        MakeAnEffect();

        Destroy(gameObject);
    }

    private void MakeAnEffect()
    {
        switch (itemComp.type)
        {
            case ItemObject.ItemType.Bandage:
                break;
            case ItemObject.ItemType.Veste:
                break;
            case ItemObject.ItemType.OrbeEtrange:
                break;
            default:
                Debug.Log("No effect assigned to object in ItemWorld.cs MakeAnEffect() !");
                break;
        }
    }

}
