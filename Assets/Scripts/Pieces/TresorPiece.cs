using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresorPiece : Piece
{
    [SerializeField] private Transform tresorSpawnTransform;

    [SerializeField] private int mimmiqueDamage;
    [SerializeField] private int artefactGainMin,artefactGainMax;
    private bool actionDone = false;
    private Life life;
    private ItemWorld itemWorldInThePiece;
    private void Start()
    {
        life = FindObjectOfType<Life>();
        base.Start();
    }

    //Le joueur arrive dans une salle. Un objet est étendue sur le sol. Le joueur peut l'ignorer, on bien cliquer dessus pour savoir ce que c'est.
    //Choix : description de l'item. Le prendre ?
    protected void OnEnable()
    {
        itemWorldInThePiece = ItemWorld.SpawnItemWorld(tresorSpawnTransform, ItemAssets.Instance.GetRandomItemType());

        actionDone = true;

        FindObjectOfType<Pensees>().StartPensee(DIALOGUES.tresorParTerre);
    }
    private void Update()
    {
        if (itemWorldInThePiece.isClicked) return;

        if (Click.IsClickingOn(leftDoor))
        {
            pieceManager.GoNextPiece(true);

        }
        if (Click.IsClickingOn(rightDoor))
        {
            pieceManager.GoNextPiece(false);
        }
    }
}
