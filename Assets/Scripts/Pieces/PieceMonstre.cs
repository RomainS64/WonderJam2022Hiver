using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMonstre : Piece
{
    [SerializeField] private CombatManager combatManager;
    private bool actionDone = false;
    private Life life;
    private ItemWorld itemWorldInThePiece;
    private void Start()
    {
        life = FindObjectOfType<Life>();
        base.Start();
    }
    protected void OnEnable()
    {
        SetAttackSprite();
        combatManager.StartCombat();
    }
    private void Update()
    {
        if (combatManager.isInCombat) return;
        base.Update();
    }
}
