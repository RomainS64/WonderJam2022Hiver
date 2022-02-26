using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


static public class Shuffle
{
    public static void ShuffleList<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
public enum ActionType
{
    Attack,
    Charge,
    Defence
}
[Serializable]
public class EnemyAction
{
    public ActionType type;
    public EnemyButton linkedButton;
}
public class EnemyBehaviour : MonoBehaviour
{
    public int baseArmor = 1;
    public int bigArmor = 2;
    public int attack=1;

    public float EnemyArmor { get; set; }
    public float EnemyAttack { get; set; }

    private bool enemyIsCharged = false;
    [SerializeField] public List<EnemyAction> enemyActions;
    public EnemyAction tempEnemyAction;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle.ShuffleList(enemyActions);
    }
    

    public void SetAction(EnemyAction enemyAction)
    {
        enemyAction.linkedButton.ClickOnTheButton();
        switch (enemyAction.type)
        {
            case ActionType.Attack:
                EnemyArmor = baseArmor;
                EnemyAttack = attack;
                if (enemyIsCharged)
                {
                    EnemyAttack *= 2;
                    enemyIsCharged = false;
                }
                break;
            case ActionType.Charge:
                EnemyArmor = baseArmor;
                EnemyAttack = 0;
                enemyIsCharged = true;
                break;
            case ActionType.Defence:
                EnemyArmor = bigArmor;
                EnemyAttack = 0;
                if (enemyIsCharged)
                {
                    EnemyArmor *= 2;
                    enemyIsCharged = false;
                }
                break;
        }
    }
}
