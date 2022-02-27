using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [TextArea]
    [SerializeField]
    private string finLamainVousDemandeLes6Artefacts;

    [TextArea]
    [SerializeField]
    private string finChoixDonnerArtefact;

    [TextArea]
    [SerializeField]
    private string finChoixRefuserDonnerArtéfact;

    [TextArea]
    [SerializeField]
    private string finJrefuseDeDonnerArtefact;

    [TextArea]
    [SerializeField]
    private string finPasAssezArtefact;

    [TextArea]
    [SerializeField]
    private string[] finAssezArtefact;

    [SerializeField]
    private ItemObject grenouilleItemObject;

    [SerializeField]
    private GameObject mainGeanteObject;

    private int currentIniniteRoomIndex;
    private DoorDirection nextInfiniteDoorDirection;

    public override void StartDialogues()
    {
        currentIniniteRoomIndex = 0;

        FindObjectOfType<PlayerTestForInventory>().Inventory.AddItem(ItemObject.ItemType.JoyauxIncandescent);
        FindObjectOfType<PlayerTestForInventory>().Inventory.AddItem(ItemObject.ItemType.DoigtDeRobot);
        FindObjectOfType<PlayerTestForInventory>().Inventory.AddItem(ItemObject.ItemType.StatuetteGuide);
        FindObjectOfType<PlayerTestForInventory>().Inventory.AddItem(ItemObject.ItemType.OrbeEtrange);
        FindObjectOfType<PlayerTestForInventory>().Inventory.AddItem(ItemObject.ItemType.HoloparcheminEndommage);
        FindObjectOfType<PlayerTestForInventory>().Inventory.AddItem(ItemObject.ItemType.PelucheEtrange);


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
            ScreenShake.Shake(0.3f, 1f);
            StartGaucheDroiteChoice();
        }
    }
   
    private void GoToUltimateRoom()
    {
        //base.ChoiceLeft();//FADE OUT
        ShowMain();

        FindObjectOfType<Choise>().StartChoise(
            finLamainVousDemandeLes6Artefacts, finChoixDonnerArtefact, finChoixRefuserDonnerArtéfact, RefuserDonnerArtefacts, DonneArtefacts
        );
    }

    private void DonneArtefacts()
    {
        if (FindObjectOfType<PlayerTestForInventory>().Inventory.IsInvenrotyFullArtefactsFound())
        {
            HideMain();
            FindObjectOfType<Pensees>().StartPensee(finAssezArtefact, () => {
                FindObjectOfType<PlayerTestForInventory>().Inventory.ClearInventory();
                FindObjectOfType<PlayerTestForInventory>().Inventory.AddItem(grenouilleItemObject);
                mental.TakeMentalDamage(100000);
            });
        }
        else
        {
            FindObjectOfType<Pensees>().StartPensee(finPasAssezArtefact, () => {
                HideMain();
                base.ChoiceLeft();
            });
        }
    }

    private void RefuserDonnerArtefacts()
    {
        FindObjectOfType<Pensees>().StartPensee(finChoixRefuserDonnerArtéfact, () => {
            HideMain();
            base.ChoiceLeft();
        });
    }

    private void ShowMain()
    {
        mainGeanteObject.SetActive(true);
    }

    private void HideMain()
    {
        mainGeanteObject.SetActive(false);
    }
}
