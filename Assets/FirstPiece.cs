using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPiece : Piece
{
    protected void OnEnable()
    {
        FindObjectOfType<Pensees>().StartPensee(DIALOGUES.firstPiece);
    }
    private void Update()
    {
        base.Update();
    }
}
