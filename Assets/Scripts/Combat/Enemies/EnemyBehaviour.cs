using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private bool enemyIsCharged = false;
    private bool enemyIsCountering = false;
    public bool EnemyIsCountering { get { return enemyIsCountering; } set { enemyIsCountering = value; } }
    private float enemyArmor, enemyAttack;
    public float EnemyArmor { get { return enemyArmor; } set { enemyArmor = value; } }
    public float EnemyAttack { get { return enemyAttack; } set { enemyAttack = value; } }
    public EnemyAction[] enemyActions;
    public EnemyAction tempEnemyAction;

    // Start is called before the first frame update
    void Start()
    {
        enemyActions = new EnemyAction[5] { EnemyAction.BigAttack, EnemyAction.SmallAttack, EnemyAction.Charge, EnemyAction.Defence, EnemyAction.Counter };
        Debug.Log(enemyActions[0] + " " + enemyActions[1] + " " + enemyActions[2] + " " + enemyActions[3] + " " + enemyActions[4]);
        Shuffle(EnemyAction.Counter, 2);
        Debug.Log(enemyActions[0] + " " + enemyActions[1] + " " + enemyActions[2] + " " + enemyActions[3] + " " + enemyActions[4]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shuffle(EnemyAction actionFixe, int position)
    {
        for(int i = 0; i < enemyActions.Length - 1; i++)
        {
            int rnd = Random.Range(i, enemyActions.Length);
            tempEnemyAction = enemyActions[rnd];
            enemyActions[rnd] = enemyActions[i];
            enemyActions[i] = tempEnemyAction;
        }
        for (int i = 0; i < enemyActions.Length; i++)
        {
            if (enemyActions[i] == actionFixe)
            {
                tempEnemyAction = enemyActions[position];
                enemyActions[position] = enemyActions[i];
                enemyActions[i] = tempEnemyAction;
            }
        }
    }

    public void SetAction(EnemyAction enemyAction)
    {
        switch (enemyAction)
        {
            case EnemyAction.BigAttack:
                enemyArmor = 1;
                enemyAttack = 3;
                if (enemyIsCharged)
                {
                    enemyAttack *= 2;
                    enemyIsCharged = false;
                }
                break;
            case EnemyAction.SmallAttack:
                enemyArmor = 1;
                enemyAttack = 2;
                if (enemyIsCharged)
                {
                    enemyAttack *= 2;
                    enemyIsCharged = false;
                }
                break;
            case EnemyAction.Charge:
                enemyArmor = 1;
                enemyAttack = 0;
                enemyIsCharged = true;
                break;
            case EnemyAction.Defence:
                enemyArmor = 2;
                enemyAttack = 0;
                if (enemyIsCharged)
                {
                    enemyArmor *= 2;
                    enemyIsCharged = false;
                }
                break;
            case EnemyAction.Counter:
                enemyArmor = 1;
                enemyAttack = 0;
                enemyIsCountering = true;
                break;
        }
    }

    public enum EnemyAction
    {
        BigAttack,
        SmallAttack,
        Charge,
        Defence,
        Counter
    }

    public enum EnemyType
    {
        Alien,
        Robotector,
        Curseby
    }
}
