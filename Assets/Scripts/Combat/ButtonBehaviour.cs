using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private bool isDefense, isAttack;
    public bool IsDefense { get { return isDefense; } }
    public bool IsAttack { get { return isAttack; } }
    [SerializeField] private Sprite spriteBoutonUtilise;
    private SpriteRenderer spriteBouton;
    private int playerArmor, playerAttack;
    public int PlayerArmor { get { return playerArmor; } set { playerArmor = value; } }
    public int PlayerAttack { get { return playerAttack; } set { playerAttack = value; } }

    private bool isActive = true;
    public bool IsActive { get { return isActive; } set { isActive = value; } }

    private bool isCharging = false;
    public bool IsCharging { get { return isCharging; } set { isCharging = value; } }

    // Start is called before the first frame update
    void Start()
    {
        spriteBouton = gameObject.GetComponentInParent<SpriteRenderer>();
    }


    public void ClickOnTheButton()
    {
        //Debug.Log("La capacité est en train de charger " + isCharging);
        if (isDefense)
        {
            playerArmor = ArmorManager.GetArmor();
            playerAttack = 1;
            Debug.Log("Defense");
        }
        else if (isAttack)
        {
            playerArmor = 1;
            playerAttack = AttackManager.GetAttack();
            Debug.Log("Attaque");
        }
        else
        {
            playerArmor = 1;
            playerAttack = 1;
            isCharging = true;
            Debug.Log("La prochaine capacité sera multipliée par 2 !!!");
        }
        Debug.Log("La capacité est en train de charger " + isCharging);
        spriteBouton.sprite = spriteBoutonUtilise;
        this.isActive = false;
    }
    
}
