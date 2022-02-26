using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public bool isInCombat = false;

    [SerializeField] private GameObject[] actionButtons;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Slider slider;

    private EnemyBehaviour enemyBehaviour;
    
    private GameObject buttonPressed;
    private int roundCount = 0;
    private float balanceOfPower;
    private float playerArmor, playerAttack;
    private bool isCharged = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
    }
    private void OnEnable()
    {
        slider.value = 0;
        roundCount = 0;
    }
    public void StartCombat()
    {
        isInCombat = true;
        gameObject.SetActive(true);
    }
    public void StopCombat()
    {
        isInCombat = false;
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!isInCombat) return;
        buttonPressed = Click.IsClickingOn(actionButtons);
        if (buttonPressed == null) return;
        ButtonBehaviour buttonBehaviour = buttonPressed.GetComponent<ButtonBehaviour>();
        if (!buttonBehaviour.IsActive) return;

        buttonBehaviour.ClickOnTheButton();

        enemyBehaviour.SetAction(enemyBehaviour.enemyActions[roundCount]);

        Debug.Log("L'ennemi utilise " + enemyBehaviour.enemyActions[roundCount]);

        playerArmor = buttonBehaviour.PlayerArmor;
        playerAttack = buttonBehaviour.PlayerAttack;

        if (isCharged)
        {
            if (buttonBehaviour.IsDefense)
            {
                playerArmor *= 2;
            }
            else if (buttonBehaviour.IsAttack)
            {
                playerAttack *= 2;
            }
            isCharged = false;
        }
        Debug.Log("Armure Joueur : " + playerArmor + " Armure Ennemi : " + enemyBehaviour.EnemyArmor);
        Debug.Log("Attaque Joueur : " + playerAttack + " Attaque Ennemi : " + enemyBehaviour.EnemyAttack);
        balanceOfPower = (playerAttack /(float)enemyBehaviour.EnemyArmor) - (enemyBehaviour.EnemyAttack / (float)playerArmor);
        Debug.Log("balanceOfPower : " + balanceOfPower);
        RoundResult(balanceOfPower);
        if (buttonBehaviour.IsCharging)
        {
            isCharged = true;
            buttonBehaviour.IsCharging = false;
        }
    }

    private void RoundResult(float balanceOfPower)
    {
        if(balanceOfPower<0)ScreenShake.Shake(0.3f, 1.5f);
        if (balanceOfPower==0) ScreenShake.Shake(0.3f, 0.7f);
        float balanceOfPowerSlider;
        balanceOfPowerSlider = balanceOfPower / 3;
        
        UpdateBalanceOfPowerBarre(balanceOfPowerSlider);

        roundCount++;
        if (roundCount >= 5)
        {
            EndFight();
        }
    }

    private void EndFight()
    {
        StopCombat();
        float resultsFight = slider.value;
        if (resultsFight < -0.5)
        {
            
        }
        else if (resultsFight > 0.5)
        {

        }
        else
        {

        }
    }

    private void UpdateBalanceOfPowerBarre(float balanceOfPowerSlider)
    {
        slider.value += balanceOfPowerSlider;
    }
}
