using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familier : MonoBehaviour
{
    [SerializeField] private GameObject chienSprite, chatSprite, parrotSprite;
    private bool haveChien=false;
    public bool HaveChien
    {
        get
        {
            return haveChien;
        }
        set
        {
            haveChien = value;
            chienSprite.SetActive(value);
        }
    }
    private bool haveChat = false;
    private bool haveParrot = false;
    private void Start()
    {
        chienSprite.SetActive(haveChien);
    }

}
