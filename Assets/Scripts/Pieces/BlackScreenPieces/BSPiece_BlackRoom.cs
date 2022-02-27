using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPiece_BlackRoom : BlackScreenPiece
{
    public enum DoorDirection
    {
        LEFT,
        RIGHT
    }

    [TextArea]
    [SerializeField]
    private string[] choiceLeftDialogues;

    [TextArea]
    [SerializeField]
    private string[] choiceRightDialogues;

    [TextArea]
    [SerializeField]
    private string finalChoiceString;

    [SerializeField]
    private float doomRoomMentalDamage;

    [SerializeField]
    private float mentalMultiplicator;

    [SerializeField]
    private float mentalMultiplicatorOfMultiplicator;

    private int currentIniniteRoomIndex;
    private DoorDirection nextInfiniteDoorDirection;

    public override void StartDialogues()
    {
        currentIniniteRoomIndex = 0;

        FindObjectOfType<Fade>().StartFade(0, backgroundAlphaRatio, 0.0025f, -1);

        StartGaucheDroiteChoice();
    }

    private void StartGaucheDroiteChoice()
    {
        SelectRandomDirectionToContinueRoom();

        switch (nextInfiniteDoorDirection)
        {
            case DoorDirection.LEFT:
                FindObjectOfType<Choise>().StartChoise(
                    choiceLeftDialogues[currentIniniteRoomIndex], pieceChoiceLeft, pieceChoiceRight, ChoiceLeft, ChoiceRight
                );

                break;
            case DoorDirection.RIGHT:
                FindObjectOfType<Choise>().StartChoise(
                    choiceRightDialogues[currentIniniteRoomIndex], pieceChoiceLeft, pieceChoiceRight, ChoiceLeft, ChoiceRight
                );
                break;
        }

    }

    public override void ChoiceLeft()
    {
        if(nextInfiniteDoorDirection == DoorDirection.LEFT)
        {
            GoToDoomedRoom();
        }
        else if(nextInfiniteDoorDirection == DoorDirection.RIGHT)
        {
            ReturnToClassicRoom();
        }
        else
        {
            Debug.Log("Wtfffff DoorDirectionChelou");
        }
    }

    public override void ChoiceRight()
    {
        if (nextInfiniteDoorDirection == DoorDirection.RIGHT)
        {
            GoToDoomedRoom();
        }
        else if (nextInfiniteDoorDirection == DoorDirection.LEFT)
        {
            ReturnToClassicRoom();
        }
        else
        {
            Debug.Log("Wtfffff DoorDirectionChelou");
        }
    }


    private void SelectRandomDirectionToContinueRoom()
    {
        int randomDirection = Random.Range(0, 2);

        switch(randomDirection)
        {
            case 0:
                nextInfiniteDoorDirection = DoorDirection.LEFT;
                break;
            case 1:
                nextInfiniteDoorDirection = DoorDirection.RIGHT;
                break;
            default:
                Debug.LogWarning("Impossible !!");
                break;
        }
    }

    private void ReturnToClassicRoom()
    {
        base.ChoiceLeft();//FADE OUT
    }

    private void GoToDoomedRoom()
    {
        currentIniniteRoomIndex++;

        if(currentIniniteRoomIndex >= choiceLeftDialogues.Length)
        {
            FindObjectOfType<Pensees>().StartPensee("AAH !", () => {
                GoToUltimateRoom();
            });
        }
        else
        {
            mental.TakeMentalDamage(Mathf.FloorToInt(doomRoomMentalDamage * mentalMultiplicator));
            mentalMultiplicator *= mentalMultiplicatorOfMultiplicator;
            StartGaucheDroiteChoice();
        }
    }
   
    private void GoToUltimateRoom()
    {
        base.ChoiceLeft();//FADE OUT

        Debug.Log("I go to the ultimate room");
    }
}
