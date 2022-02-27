using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public bool isInCombat = false;
    public int damage;

    [SerializeField] private GameObject[] actionButtons;
    [SerializeField] private GameObject enemyGO;
    [SerializeField] private Transform lootSpawnTransform, lootSpawnTransform2;
    [SerializeField] private Slider slider;

    [SerializeField] private Enemy[] typesEnemy;
    private Enemy enemy;

    private Life life;
    private ItemWorld itemWorldInThePiece;

    private EnemyBehaviour enemyBehaviour;

    private GameObject buttonPressed;
    private int roundCount = 0;
    private float balanceOfPower;
    private float playerArmor, playerAttack;
    private bool isCharged = false;
    // Start is called before the first frame update
    void Start()
    {
        life = FindObjectOfType<Life>();
        lootSpawnTransform = GameObject.Find("PieceMonstre/LootSpawnPoint").transform;
    }
    private void OnEnable()
    {
        damage = 0;
        slider.value = 0;
        roundCount = 0;
        enemyBehaviour = enemyGO.GetComponent<EnemyBehaviour>();
        enemy = GetRandomEnemy();
        enemyBehaviour.SetEnemy(enemy.attack, enemy.armor, enemy.bigArmor, enemy.enemySprite, enemy.enemyAnimatorController);
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
            Debug.Log("La capacité est chargée : " + isCharged);
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
            Debug.Log("La capacité est chargée : " + isCharged);
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
            Invoke(nameof(EndFight),1f);
        }
    }

    private void EndFight()
    {
        StopCombat();
        float resultsFight = slider.value;
        float spawnChance = Random.value;
        Debug.Log("Resultat du combat : " + resultsFight);
        Debug.Log("Spawn Chance = " + spawnChance);
        if (resultsFight < 0.5)
        {
            int multiplier = -10;
            if (spawnChance < 0.25 && resultsFight >= 0)
            {
                itemWorldInThePiece = ItemWorld.SpawnItemWorld(lootSpawnTransform, ItemAssets.Instance.GetRandomItemType());
            }
            if (resultsFight < 0)
            {
                if (spawnChance < 0.125 && resultsFight >= -0.5)
                {
                    itemWorldInThePiece = ItemWorld.SpawnItemWorld(lootSpawnTransform, ItemAssets.Instance.GetRandomItemType());
                }
                if (resultsFight < -0.5)
                {
                    multiplier -= 5;
                    if (resultsFight < -1)
                    {
                        multiplier -= 2;
                        if (resultsFight < -1.25)
                        {
                            multiplier -= 3;
                        }
                    }
                }
            }
            damage = (int)((slider.minValue + resultsFight) * multiplier);
            Debug.Log("Dégât prit : " + damage);
            life.TakeDamage(damage);
        }
        else
        {
            
            if (resultsFight > 1)
            {
                itemWorldInThePiece = ItemWorld.SpawnItemWorld(lootSpawnTransform, ItemAssets.Instance.GetRandomItemType());
            }
            else
            {
                if (spawnChance < 0.5)
                {
                    itemWorldInThePiece = ItemWorld.SpawnItemWorld(lootSpawnTransform, ItemAssets.Instance.GetRandomItemType());
                }
            }
            Debug.Log("aucun dégât");
        }
    }

    private void UpdateBalanceOfPowerBarre(float balanceOfPowerSlider)
    {
        slider.value += balanceOfPowerSlider;
    }

    private Enemy GetRandomEnemy()
    {
        int weightSum = 0;
        int currentWeight = 0;
        foreach (Enemy enemy in typesEnemy)
        {
            weightSum += enemy.weight;
        }
        int randomWeght = Random.Range(0, weightSum);

        foreach (Enemy randomEnemy in typesEnemy)
        {
            currentWeight += randomEnemy.weight;
            if(randomWeght <= currentWeight)
            {
                return randomEnemy;
            }
        }
        return null;
    }
}
