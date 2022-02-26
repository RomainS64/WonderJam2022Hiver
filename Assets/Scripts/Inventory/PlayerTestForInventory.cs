using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestForInventory : MonoBehaviour
{
    private Inventory inventory;
    public Inventory Inventory => inventory;
    void Start()
    {
        inventory = new Inventory();

        //Debug for testing purposes
        //ItemWorld.SpawnItemWorld(new Vector3(1, 2, 0), ItemObject.ItemType.Veste);
        //ItemWorld.SpawnItemWorld(new Vector3(3, 2, 0), ItemObject.ItemType.OrbeEtrange);
        //ItemWorld.SpawnItemWorld(new Vector3(4, 4, 0), ItemObject.ItemType.Bandage);
        //ItemWorld.SpawnItemWorld(new Vector3(1, -1, 0), ItemObject.ItemType.Bandage);
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.P))
    //    {
    //        inventory.RemoveItemOfType(ItemObject.ItemType.Bandage);
    //        inventory.DisplayInventoryInConsole();
    //    }
    //}
}
