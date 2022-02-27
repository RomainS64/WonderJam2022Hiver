using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Enemy", menuName ="Enemy")]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public int weight;
    public int attack;
    public int armor;
    public int bigArmor;
    public Sprite enemySprite;
    public RuntimeAnimatorController enemyAnimatorController;
}
