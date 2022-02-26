using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] private Piece[] typesDePieces;
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
        Debug.Log(pieceHistory.Count);
        FindObjectOfType<Zoom>().StartZoom(5, 5, 0.1f);
        FindObjectOfType<Fade>().StartFade(1, 0, 0.5f,0);
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
