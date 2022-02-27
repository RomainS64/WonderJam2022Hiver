using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenPiece : Piece
{
    [SerializeField]
    protected float backgroundAlphaRatio = 0.6f;

    [TextArea]
    [SerializeField]
    protected string[] pieceEnterDialogue;

    [SerializeField]
    protected string pieceChoiceLeft;

    [SerializeField]
    protected string pieceChoiceRight;

    protected Life life;
    protected Mental mental;

    protected int currentMessageDisplayed;

    private void Start()
    {
        life = FindObjectOfType<Life>();
        mental = FindObjectOfType<Mental>();
        base.Start();
    }

    protected void OnEnable()
    {
        spriteRenderer.sprite = null;
        currentMessageDisplayed = 0;

        actionDone = false;

        Invoke("StartDialogues", .3f);
    }
    protected void Update()
    {
        if (!actionDone) return;

        base.Update();
    }

    public virtual void ChoiceLeft()
    {
        FadeOut();
    }

    public virtual void ChoiceRight()
    {
        FadeOut();
    }

    public virtual void StartDialogues()
    {
        FindObjectOfType<Fade>().StartFade(0, backgroundAlphaRatio, 0.2f, -1);

        FindObjectOfType<Choise>().StartChoise(pieceEnterDialogue[0], pieceChoiceLeft, pieceChoiceRight, ChoiceLeft, ChoiceRight);
    }

    private void DisplayNextMessage()
    {
        FindObjectOfType<Pensees>().StartPensee(pieceEnterDialogue[currentMessageDisplayed]);
    }

    private void FadeOut()
    {
        actionDone = true;
        FindObjectOfType<Fade>().StartFade(backgroundAlphaRatio, 0, 0.2f, 0.4f);
        SetThinkingSprite();
    }
}
