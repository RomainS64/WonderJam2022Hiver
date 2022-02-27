using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPiece_1 : BlackScreenPiece
{
    public override void ChoiceLeft()
    {
        Debug.Log("Doing something leftAAAAAAAAAAAAAAAAAAAA");

        base.ChoiceLeft();
    }

    public override void ChoiceRight()
    {
        Debug.Log("Doing something rightAAAAAAAAAAAAA");

        base.ChoiceRight();
    }
}
