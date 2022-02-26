using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public static int GetAttack()
    {
        int armorValue;
        armorValue = PlayerPrefs.GetInt("AttackValue", 1);
        return armorValue;
    }

    public static void AddAttack(int addAmount)
    {
        int newAttackValue;
        newAttackValue = GetAttack() + addAmount;
        PlayerPrefs.SetInt("AttackValue", newAttackValue);
    }

    public static void RemoveAttack(int removeAmount)
    {
        int newAttackValue;
        newAttackValue = GetAttack() - removeAmount;
        PlayerPrefs.SetInt("AttackValue", newAttackValue);
    }
}
