using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresorPiece : Piece
{
    [SerializeField] private int mimmiqueDamage;
    [SerializeField] private int artefactGainMin,artefactGainMax;
    private bool actionDone = false;
    private Life life;
    private void Start()
    {
        life = FindObjectOfType<Life>();
        base.Start();
    }
    protected void OnEnable()
    {
        actionDone = false;

        FindObjectOfType<Choise>().StartChoise(DIALOGUES.tresorQuestion,DIALOGUES.tresorRep1,DIALOGUES.tresorRep2, DontTake, Take);
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
        
        
        if (Random.Range(0, 2) > 0)
        {
            ScreenShake.Shake(0.3f, 1f);
            life.TakeDamage(mimmiqueDamage);
            FindObjectOfType<Pensees>().StartPensee(DIALOGUES.tresorPrendre2);
        }
        else
        {
            FindObjectOfType<Pensees>().StartPensee(DIALOGUES.tresorPrendre1);
        }
            

        actionDone = true;
    }
    public void DontTake()
    {
        FindObjectOfType<Pensees>().StartPensee(DIALOGUES.tresorLaisser);
        actionDone = true;
    }
}
