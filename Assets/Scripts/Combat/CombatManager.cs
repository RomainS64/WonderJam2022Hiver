using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private GameObject[] actionButtons;
    [SerializeField] private GameObject enemy;
    private EnemyBehaviour enemyBehaviour;
    [SerializeField] private Slider slider;
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

    // Update is called once per frame
    void Update()
    {
        buttonPressed = Click.IsClickingOn(actionButtons);
        if (buttonPressed != null)
        {
            ButtonBehaviour buttonBehaviour = buttonPressed.GetComponent<ButtonBehaviour>();
            if (buttonBehaviour.IsActive)
            {
                buttonBehaviour.ClickOnTheButton();
                enemyBehaviour.SetAction(enemyBehaviour.enemyActions[roundCount]);
                Debug.Log("L'ennemi a " + enemyBehaviour.enemyActions[roundCount]);
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
                Debug.Log("Armure : " + playerArmor);
                Debug.Log("Attaque : " + playerAttack);
                if (enemyBehaviour.EnemyIsCountering)
                {
                    enemyBehaviour.EnemyAttack = playerAttack * 1.5f;
                    playerAttack = playerAttack/2;
                }
                balanceOfPower = (playerAttack / (1f * enemyBehaviour.EnemyArmor)) - (enemyBehaviour.EnemyAttack / (1f * playerArmor));
                Debug.Log("balanceOfPower : " + balanceOfPower);
                RoundResult(balanceOfPower);
                if (buttonBehaviour.IsCharging)
                {
                    isCharged = true;
                    buttonBehaviour.IsCharging = false;
                }
            }
        }

    }

    private void RoundResult(float balanceOfPower)
    {
        float balanceOfPowerSlider;
        balanceOfPowerSlider = balanceOfPower * 1.5f / 100;
        if (balanceOfPower < 0)
        {
            //Barre Diminue
            DecreaseBalanceOfPowerBarre(balanceOfPowerSlider);
        }
        else if (balanceOfPower > 0)
        {
            //Barre augmente
            IncreaseBalanceOfPowerBarre(balanceOfPowerSlider);
        }

        roundCount++;
        if (roundCount >= 5)
        {
            EndFight();
        }
    }

    private void EndFight()
    {
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

    private void DecreaseBalanceOfPowerBarre(float balanceOfPowerSlider)
    {
        slider.value -= balanceOfPowerSlider;
    }

    private void IncreaseBalanceOfPowerBarre(float balanceOfPowerSlider)
    {
        slider.value += balanceOfPowerSlider;
    }
}
