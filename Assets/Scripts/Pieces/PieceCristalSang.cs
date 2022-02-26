using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCristalSang : Piece
{
    [SerializeField] private Transform tresorSpawnTransform;
    [SerializeField] private Sprite cristalEnabledSprite;
    [SerializeField] private Sprite cristalDisabledSprite;

    private Life life;
    private SpriteRenderer spriteRenderer;

    private float lifeStolen;
    private bool isCristalActivated;

    private bool isClicked = false;

    private void Start()
    {
        life = FindObjectOfType<Life>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        base.Start();
    }

    //Le joueur arrive dans une salle. Un objet est étendue sur le sol. Le joueur peut l'ignorer, on bien cliquer dessus pour savoir ce que c'est.
    //Choix : description de l'item. Le prendre ?
    protected void OnEnable()
    {
        if(isCristalActivated)
        {
            spriteRenderer.sprite = cristalEnabledSprite;
        }
        else
        {
            spriteRenderer.sprite = cristalDisabledSprite;
        }

        actionDone = true;

        FindObjectOfType<Pensees>().StartPensee(DIALOGUES.tresorParTerre);
    }
    private void Update()
    {
        //if (itemWorldInThePiece.isClicked) return;

        if (Click.IsClickingOn(gameObject) && !isClicked)
        {
            isClicked = true;
            //FindObjectOfType<Choise>().StartChoise(itemComp.choosingDialogue, DIALOGUES.tresorRep1, DIALOGUES.tresorRep2, DontTake, Take);
        }

        if (Click.IsClickingOn(leftDoor))
        {
            pieceManager.GoNextPiece(true);

        }
        if (Click.IsClickingOn(rightDoor))
        {
            pieceManager.GoNextPiece(false);
        }
    }

    private void DontTake()
    {
        isClicked = false;

        //FindObjectOfType<Pensees>().StartPensee(DIALOGUES.tresorLaisser);
    }

    private void Take()
    {
        isClicked = false;

        //FindObjectOfType<Pensees>().StartPensee(itemComp.pickUpDialogue);

        //FindObjectOfType<PlayerTestForInventory>().Inventory.AddItem(itemComp.type);

        MakeAnEffect();

        Destroy(gameObject);
    }

    private void MakeAnEffect()
    {

    }
}
