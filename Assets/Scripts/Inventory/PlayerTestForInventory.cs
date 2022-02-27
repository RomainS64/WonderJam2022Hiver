using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestForInventory : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    public Inventory Inventory => inventory;
    void Start()
    {
        inventory = new Inventory();
    }
}
