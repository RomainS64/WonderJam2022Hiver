using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mental : MonoBehaviour
{
    [SerializeField] private int maxMental;
    [SerializeField] private Slider slider;
    private int currentMental;

    void Start()
    {
        currentMental = maxMental;
        slider.maxValue = maxMental;
        slider.value = maxMental;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) TakeMentalDamage(1);
    }
    public int GetMental()
    {
        return currentMental;
    }
    public int GetMaxMental()
    {
        return maxMental;
    }
    public void RecoverMental(int mental)
    {
        currentMental += mental;
        slider.value = currentMental;
    }
    public void TakeMentalDamage(int damage)
    {
        currentMental -= damage;
        slider.value = currentMental;
        if(currentMental <= 0)
        {
            FindObjectOfType<Mort>().DisplayMort(false);
        }
    }
}
