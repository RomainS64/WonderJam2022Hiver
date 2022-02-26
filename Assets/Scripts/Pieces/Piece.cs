using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField]protected Sprite attackSprite, thinkingSprite;
    [SerializeField]private SpriteRenderer spriteRenderer;
    protected bool actionDone = false;

    public GameObject leftDoor;
    public GameObject rightDoor;

    protected PieceManager pieceManager;
    protected void Start()
    {
        pieceManager = FindObjectOfType<PieceManager>();
    }
    protected void SetAttackSprite()
    {
        spriteRenderer.sprite = attackSprite;
    }
    protected void SetThinkingSprite()
    {
        spriteRenderer.sprite = thinkingSprite;
    }
    protected void OnEnable()
    {
        FindObjectOfType<Pensees>().StartPensee("Cette piece est vide...");
    }
    protected void Update()
    {
        if (Click.IsClickingOn(leftDoor)) pieceManager.GoNextPiece(true);
        if (Click.IsClickingOn(rightDoor)) pieceManager.GoNextPiece(false);
    }

    public void DisplayPiece()
    {
        gameObject.SetActive(true);
    }
    public void HidePiece()
    {
        gameObject.SetActive(false);
    }
}
