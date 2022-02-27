using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceShop : Piece
{
    private Life life;
    private Mental mental;
    private PlayerTestForInventory inventory;
    private void Start()
    {
        inventory = FindObjectOfType<PlayerTestForInventory>();
        life = FindObjectOfType<Life>();
        mental = FindObjectOfType<Mental>();
        base.Start();
    }
    protected void OnEnable()
    {
        if(inventory.Inventory.)
        FindObjectOfType<Choise>().StartChoise(DIALOGUES.squeletteQuestion, DIALOGUES.squeletteRep2, DIALOGUES.squeletteRep1, DontTake, Take);
    }
    private void Update()
    {
        if (!actionDone) return;
        base.Update();
    }
    public void Take()
    {
        
    }
    public void DontTake()
    {
        
    }
}
