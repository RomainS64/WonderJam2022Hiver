using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;

    private GameObject linkedPiece;
    void Start()
    {
        //Pour le moment le GameObject est dirrectement lié au script, on verra par la suite si on le déplace;
        linkedPiece = gameObject; 
    }
    void Update()
    {
    }

    public void DisplayPiece()
    {
        linkedPiece.SetActive(true);
    }



}
