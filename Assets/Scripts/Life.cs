using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField] private int maxLife;
    [SerializeField] private Slider slider;
    private int currentLife;
   
    void Start()
    {
        currentLife = maxLife;
        slider.maxValue = maxLife;
        slider.value = maxLife;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) TakeDamage(1);
    }
    public int GetLife()
    {
        return currentLife;
    }
    public int GetMaxLife()
    {
        return maxLife;
    }
    public void TakeDamage(int damage)
    {
        currentLife -= damage;
        slider.value = currentLife;
    }
}
