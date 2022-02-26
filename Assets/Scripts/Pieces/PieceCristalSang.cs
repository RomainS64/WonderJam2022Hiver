using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCristalSang : Piece
{
    [SerializeField] private float lifeStolenRatioFromCurrentHealth;
    [SerializeField] private float lifeGaveBackRatio;

    [SerializeField] private GameObject cristalObject;
    [SerializeField] private Sprite cristalEnabledSprite;
    [SerializeField] private Sprite cristalDisabledSprite;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private Life life;

    private float totalLifeStolenFromCristal;
    private bool isCristalActivated;
    private bool hasCristalBeenTouched;

    private bool isClickedPopupShowing = false;

    private void Start()
    {
        life = FindObjectOfType<Life>();

        base.Start();
    }

    protected void OnEnable()
    {
        hasCristalBeenTouched = false;
        isClickedPopupShowing = false;
        actionDone = true;

        UpdateCristalIllumination();
    }
    private void Update()
    {
        if (isClickedPopupShowing) return;

        if (Click.IsClickingOn(cristalObject) && !hasCristalBeenTouched)
        {
            isClickedPopupShowing = true;

            if(isCristalActivated)
            {
                FindObjectOfType<Choise>().StartChoise(DIALOGUES.cristalTrouveEnabled, DIALOGUES.cristalRep1, DIALOGUES.cristalRep2, DontTouch, Touch); ;
            }
            else
            {
                FindObjectOfType<Choise>().StartChoise(DIALOGUES.cristalTrouveDisabled, DIALOGUES.cristalRep1, DIALOGUES.cristalRep2, DontTouch, Touch); ;
            }
        }

        if (Click.IsClickingOn(leftDoor))
        {
            pieceManager.GoNextPiece(true);

        }
        if (Click.IsClickingOn(rightDoor))
        {
            pieceManager.GoNextPiece(false);
        }
    }

    private void DontTouch()
    {
        isClickedPopupShowing = false;
    }

    private void Touch()
    {
        isClickedPopupShowing = false;
        hasCristalBeenTouched = true;

        if (isCristalActivated)
        {
            life.Heal(Mathf.CeilToInt(totalLifeStolenFromCristal * lifeGaveBackRatio));

            FindObjectOfType<Pensees>().StartPensee(DIALOGUES.cristalToucheToDisable);

            isCristalActivated = false;
            totalLifeStolenFromCristal = 0;
        }
        else
        {
            totalLifeStolenFromCristal = life.CurrentLife * lifeStolenRatioFromCurrentHealth;
            life.TakeDamage(Mathf.CeilToInt(totalLifeStolenFromCristal));

            FindObjectOfType<Pensees>().StartPensee(DIALOGUES.cristalToucheToEnable);

            isCristalActivated = true;
        }

        UpdateCristalIllumination();
    }

    private void UpdateCristalIllumination()
    {
        if(isCristalActivated)
        {
            spriteRenderer.sprite = cristalEnabledSprite;
        }
        else
        {
            spriteRenderer.sprite = cristalDisabledSprite;
        }
    }
}
