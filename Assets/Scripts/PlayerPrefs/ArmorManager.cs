using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorManager : MonoBehaviour
{

    public static int GetArmor()
    {
        int armorValue;
        armorValue = PlayerPrefs.GetInt("ArmorValue", 1);
        return armorValue;
    }

    public static void AddArmor(int addAmount)
    {
        int newArmorValue;
        newArmorValue = GetArmor() + addAmount;
        PlayerPrefs.SetInt("ArmorValue", newArmorValue);
    }

    public static void RemoveArmor(int removeAmount)
    {
        int newArmorValue;
        newArmorValue = GetArmor() - removeAmount;
        PlayerPrefs.SetInt("ArmorValue", newArmorValue);
    }
}
