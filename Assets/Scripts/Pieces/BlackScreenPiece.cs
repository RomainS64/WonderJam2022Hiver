using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenPiece : Piece
{
    [SerializeField]
    protected float backgroundAlphaRatio = 0.6f;

    [Multiline(10)]
    [SerializeField]
    protected string pieceEnterDialogue;

    [SerializeField]
    protected string pieceChoiceLeft;

    [SerializeField]
    protected string pieceChoiceRight;

    protected Life life;

    private void Start()
    {
        life = FindObjectOfType<Life>();
        base.Start();
    }

    protected void OnEnable()
    {
        spriteRenderer.sprite = null;

        actionDone = false;

        Invoke("FadeInBackAndStartChoice", .3f);
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

    private void FadeInBackAndStartChoice()
    {
        FindObjectOfType<Choise>().StartChoise(pieceEnterDialogue, pieceChoiceLeft, pieceChoiceRight, ChoiceLeft, ChoiceRight);

        FindObjectOfType<Fade>().StartFade(0, backgroundAlphaRatio, 0.2f, -1);
    }

    private void FadeOut()
    {
        actionDone = true;
        FindObjectOfType<Fade>().StartFade(backgroundAlphaRatio, 0, 0.2f, 0.4f);
        SetThinkingSprite();
    }
}