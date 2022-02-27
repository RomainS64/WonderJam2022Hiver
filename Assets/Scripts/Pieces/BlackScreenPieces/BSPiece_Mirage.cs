using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPiece_Mirage : BlackScreenPiece
{
    [TextArea]
    [SerializeField]
    private string choiceLeftDialogue;

    [TextArea]
    [SerializeField]
    private string choiceRightDialogue;

    [TextArea]
    [SerializeField]
    private string finalChoiceString;

    [SerializeField]
    private int degatsPhysiques = 15;

    [SerializeField]
    private int degatsMentaux = 15;

    public override void ChoiceLeft()
    {
        Debug.Log("Je perds de la vie olala");

        life.TakeDamage(degatsPhysiques);

        FindObjectOfType<Pensees>().StartPensee(choiceLeftDialogue, () => {
            base.ChoiceLeft();
        });
    }

    public override void ChoiceRight()
    {
        Debug.Log("Je perds du mental olala");

        mental.TakeMentalDamage(degatsMentaux);

        FindObjectOfType<Pensees>().StartPensee(choiceRightDialogue, () => {
            base.ChoiceRight();
        });
    }
    public override void StartDialogues()
    {
        FindObjectOfType<Fade>().StartFade(0, backgroundAlphaRatio, 0.2f, -1);

        FindObjectOfType<Pensees>().StartPensee(pieceEnterDialogue, () => { StartFinalChoice(); });
    }

    private void StartFinalChoice()
    {
        FindObjectOfType<Choise>().StartChoise(finalChoiceString, pieceChoiceLeft, pieceChoiceRight, ChoiceRight, ChoiceLeft);
    }
}
