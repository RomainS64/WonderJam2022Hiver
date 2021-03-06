using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceShop : Piece
{
    public int vitalityBuffValue, mentalBuffValue;
    private Life life;
    private Mental mental;
    private PlayerTestForInventory inventory;
    private ItemObject itemToTrade;
    private bool isVitalityBuff;
    private void Start()
    {
        inventory = FindObjectOfType<PlayerTestForInventory>();
        life = FindObjectOfType<Life>();
        mental = FindObjectOfType<Mental>();
        base.Start();
    }
    protected void OnEnable()
    {
        if (inventory != null)
        {
            if (inventory.Inventory.items.Count > 0)
            {
                isVitalityBuff = Random.Range(0, 2) > 0;
                itemToTrade = inventory.Inventory.FindRandomItem();
                string beginningSentence = itemToTrade.nomEstFeminin ? "Mmmh... Ta " + itemToTrade.itemName : "Hoohoo... Ton " + itemToTrade.itemName;
                FindObjectOfType<Choise>().StartChoise(beginningSentence +" m'int?resse beaucoup... \n Je te l'?change... Contre un peu de "+(isVitalityBuff?"vitalit?":"mental")+ ". Deal ?","Echanger","Ne pas l'?changer", DontTake, Take);
            }
            else
            {
                FindObjectOfType<Pensees>().StartPensee("Je n'ai rien pour toi.");
                actionDone = true;
            }
        }
        else
        {
            FindObjectOfType<Pensees>().StartPensee("Je n'ai rien pour toi.");
            actionDone = true;
        }
        
        
    }
    private void Update()
    {
        if (!actionDone) return;
        base.Update();
    }
    public void Take()
    {
        if (isVitalityBuff) life.Heal(vitalityBuffValue);
        else mental.RecoverMental(mentalBuffValue);
        inventory.Inventory.RemoveItem(itemToTrade);
        actionDone = true;
    }
    public void DontTake()
    {
        actionDone = true;
    }
}
