using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChienPiece : Piece
{
    [SerializeField] private int chienDamage, chienDamageMental;
    [SerializeField] GameObject spriteChien;
    private bool isDocile;
    private bool actionDone = false;
    private bool firstPenseeDone = false;

    private Life life;
    private Mental mental;
    private void Start()
    {
        life = FindObjectOfType<Life>();
        mental = FindObjectOfType<Mental>();
        base.Start();
    }
    protected void OnEnable()
    {
        actionDone = false;
        firstPenseeDone = false;
        spriteChien.SetActive(true);
        isDocile = Random.Range(0, 2)==0?true:false;
        if (isDocile) {
        FindObjectOfType<Pensees>().StartPensee(DIALOGUES.chienDocile1);
        }
        else
        {
        FindObjectOfType<Pensees>().StartPensee(DIALOGUES.chienMechant1);
        }
    }
    private void Update()
    {
        if (!actionDone && !Pensees.isInPensee && !firstPenseeDone)
        {
            Debug.Log("Jpasse par la car" + !actionDone + !Pensees.isInPensee + !firstPenseeDone);
            firstPenseeDone = true;
            FindObjectOfType<Choise>().StartChoise("Que faire ?", "Caresser", "Attaquer", Attaquer,Caresser);
        }
        else
        {
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
    public void Caresser()
    {
        if (isDocile)
        {
            int rdm = Random.Range(0, 2);
            if (rdm > 0  || FindObjectOfType<Familier>().HaveChien)
            {
                mental.RecoverMental(10);
                FindObjectOfType<Pensees>().StartPensee(DIALOGUES.chienDocileCaresse1);
            }
            else
            {
                //MORAL+++ FAMILIER+
                mental.RecoverMental(10);
                FindObjectOfType<Pensees>().StartPensee(DIALOGUES.chienDocileCaresse2);
                FindObjectOfType<Familier>().HaveChien = true;
                spriteChien.SetActive(false);
            }
            
        }
        else
        {
            ScreenShake.Shake(0.3f, 1f);
            life.TakeDamage(chienDamage);
            FindObjectOfType<Pensees>().StartPensee(DIALOGUES.chienMechantCaresse1);
            spriteChien.SetActive(false);
        }
        actionDone = true;
    }
    public void Attaquer()
    {
        if (isDocile)
        {
            int rdm = Random.Range(0, 2);
            if (rdm > 0)
            {
                ScreenShake.Shake(0.3f, 1f);
                life.TakeDamage(chienDamage);
                FindObjectOfType<Pensees>().StartPensee(DIALOGUES.chienDocileAttaque1);
                spriteChien.SetActive(false);
            }
            else
            {
                ScreenShake.Shake(0.3f, 1f);
                mental.TakeMentalDamage(chienDamageMental);
                FindObjectOfType<Pensees>().StartPensee(DIALOGUES.chienDocileAttaque2);
                spriteChien.SetActive(false);
            }
            
        }
        else
        {
            ScreenShake.Shake(0.3f, 1f);
            FindObjectOfType<Pensees>().StartPensee(DIALOGUES.chienMechantAttaque1);
            spriteChien.SetActive(false);
        }
        actionDone = true;

    }
}
