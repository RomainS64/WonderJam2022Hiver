using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;

    private PieceManager pieceManager;
    void Start()
    {

        pieceManager = FindObjectOfType<PieceManager>();
    }
    void Update()
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
