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
        SetAttackSprite();
        FindObjectOfType<Choise>().StartChoise(DIALOGUES.squeletteQuestion, DIALOGUES.squeletteRep1, DIALOGUES.squeletteRep2, DontTake,Take);
    }
    private void Update()
    {
        if (!actionDone) return;
        base.Update();
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
