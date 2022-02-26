using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquelettePiece : Piece
{
    [SerializeField] private int squeletteDamageMental;
    [SerializeField] GameObject spriteArmor;
    [SerializeField] private int armorGain;

    private Mental mental;
    private void Start()
    {
        mental = FindObjectOfType<Mental>();
        base.Start();
    }
    protected void OnEnable()
    {
        actionDone = false;
        spriteArmor.SetActive(true);

        FindObjectOfType<Choise>().StartChoise("Ce squelette n'aura surrement plus besoin de son armure", "Prendre l'armure", "Laisser l'armure",DontTake,Take);
    }
    private void Update()
    {
        if (!actionDone) return;
        if (Click.IsClickingOn(leftDoor))
        {
            pieceManager.GoNextPiece(true);

        }
        if (Click.IsClickingOn(rightDoor))
        {
            pieceManager.GoNextPiece(false);

        }
    }
    public void Take()
    {
        ArmorManager.AddArmor(armorGain);
        spriteArmor.SetActive(false);
        ScreenShake.Shake(0.3f, 1f);
        
        mental.TakeMentalDamage(squeletteDamageMental);
        FindObjectOfType<Pensees>().StartPensee(DIALOGUES.squelettePrendre);

        actionDone = true;
    }
    public void DontTake()
    {
        FindObjectOfType<Pensees>().StartPensee(DIALOGUES.squeletteLaisser);
        actionDone = true;
    }
}
