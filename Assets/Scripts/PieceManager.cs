using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PieceAndPonderation
{
    public Piece piece;
    public int ponderation;
}
public class PieceManager : MonoBehaviour
{
    [SerializeField] private Text nbSalleUI;
    [SerializeField] private PieceAndPonderation[] typesDePieces;
    private Piece leftPiece,rightPiece;
    private List<Piece> pieceHistory;
    private bool isLeftPieceSelected;

    void Start()
    {
        pieceHistory = new List<Piece>();
        GeneratePatern(GetRandomPiece());
        pieceHistory[pieceHistory.Count - 1].DisplayPiece();
    }

    public void GoNextPiece(bool isLeftPiece)
    {
        
        FindObjectOfType<Fade>().StartFade(0, 1, 0.5f, -1);
        FindObjectOfType<Zoom>().StartZoom(5, 3, 0.6f,isLeftPiece ? 
            pieceHistory[pieceHistory.Count - 1].leftDoor.transform:
            pieceHistory[pieceHistory.Count - 1].rightDoor.transform);
        isLeftPieceSelected = isLeftPiece;
        Invoke(nameof(DelayGoNextPiece), 1.5f);

    }
    private void DelayGoNextPiece()
    {
        pieceHistory[pieceHistory.Count - 1].HidePiece();
        if (isLeftPieceSelected)
        {
            leftPiece.DisplayPiece();
            GeneratePatern(leftPiece);
        }
        else
        {
            rightPiece.DisplayPiece();
            GeneratePatern(rightPiece);
        }
        FindObjectOfType<Zoom>().StartZoom(5, 5, 0.1f);
        FindObjectOfType<Fade>().StartFade(1, 0, 0.4f, 0);
        nbSalleUI.text = "" + pieceHistory.Count;
    }
    private void GeneratePatern(Piece newPiece)
    {
        pieceHistory.Add(newPiece);
        leftPiece = GetRandomPiece();
        rightPiece = GetRandomPiece();
    }

    //Retourne une piece au hasard mais qui n'est pas égale aux deux dernieres piece (sauf si c'est un monstre)
    private Piece GetRandomPiece()
    {
        int rdmValue = UnityEngine.Random.Range(1, 101);
        int currentValue = 0;
        for(int i = 0; i < typesDePieces.Length; i++)
        {
            currentValue += typesDePieces[i].ponderation;
            if (rdmValue <= currentValue) return typesDePieces[i].piece;
        }
        return typesDePieces[0].piece;

    }
}
