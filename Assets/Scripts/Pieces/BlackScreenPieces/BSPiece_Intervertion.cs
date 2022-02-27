using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPiece_Intervertion : BlackScreenPiece
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

    public override void ChoiceLeft()
    {
        Debug.Log("Mon mental et ma vie s'intervertissent");

        int currentHeal = life.GetLife();
        int currentMental = mental.GetMental();

        ScreenShake.Shake(0.3f, 0.3f);
        life.SetHealth(currentMental);
        mental.SetMental(currentHeal);

        FindObjectOfType<Pensees>().StartPensee(choiceLeftDialogue, () => {
            base.ChoiceLeft();
        });
    }

    public override void ChoiceRight()
    {
        Debug.Log("J'fais rieng");

        base.ChoiceRight();

        //FindObjectOfType<Pensees>().StartPensee(choiceRightDialogue, () => {
        //    base.ChoiceRight();
        //});
    }

    public override void StartDialogues()
    {
        FindObjectOfType<Fade>().StartFade(0, backgroundAlphaRatio, 0.2f, -1);

        //FindObjectOfType<Pensees>().StartPensee(pieceEnterDialogue, () => { StartFinalChoice(); });
        StartFinalChoice();
    }

    private void StartFinalChoice()
    {
        FindObjectOfType<Choise>().StartChoise(finalChoiceString, pieceChoiceLeft, pieceChoiceRight, ChoiceRight, ChoiceLeft);
    }
}
