using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;

    protected PieceManager pieceManager;
    protected void Start()
    {
        pieceManager = FindObjectOfType<PieceManager>();
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
