using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] private Piece[] typesDePieces;
    private Piece leftPiece,rightPiece;
    private List<Piece> pieceHistory;
    

    void Start()
    {
        pieceHistory = new List<Piece>();
        GeneratePatern(GetRandomPiece());
        pieceHistory[pieceHistory.Count - 1].DisplayPiece();
    }

    public void GoNextPiece(bool isLeftPiece)
    {
        pieceHistory[pieceHistory.Count - 1].HidePiece();
        if (isLeftPiece)
        {
            leftPiece.DisplayPiece();
            GeneratePatern(leftPiece);
        }
        else
        {
            rightPiece.DisplayPiece();
            GeneratePatern(rightPiece);
        }
        Debug.Log(pieceHistory.Count);

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
        Piece randomPiece = typesDePieces[Random.Range(0, typesDePieces.Length)];
        return randomPiece;
    }
    void Update()
    {
        
    }
}
