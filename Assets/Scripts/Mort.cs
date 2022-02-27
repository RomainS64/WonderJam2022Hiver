using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mort : MonoBehaviour
{
    static public bool isDead = false;

    [SerializeField] private GameObject mortCanvas;
    [SerializeField] private Image bg,fg;
    [SerializeField] private Text vieTxt, mentalTxt,continueTxt;
    private void Start()
    {
        mortCanvas.SetActive(false);
        isDead = false;
    }

    public void DisplayMort(bool isLifeDeath = true)
    {
        
        isDead = true;
        mortCanvas.SetActive(true);
        StartCoroutine(LifeDeathCoroutine(isLifeDeath));
    }
    IEnumerator LifeDeathCoroutine(bool isLifeDeath)
    {
        bg.color = new Color(bg.color.r, bg.color.g, bg.color.b,0);
        fg.color = new Color(fg.color.r, fg.color.g, fg.color.b, 0);

        vieTxt.color = new Color(vieTxt.color.r, vieTxt.color.g, vieTxt.color.b, 0);
        mentalTxt.color = new Color(mentalTxt.color.r, mentalTxt.color.g, mentalTxt.color.b, 0);
        continueTxt.color = new Color(continueTxt.color.r, continueTxt.color.g, continueTxt.color.b, 0);
        Color step = new Color(0,0,0,1/50f);

        for (int i = 0; i < 50; i++)
        {
            bg.color += step;
            yield return new WaitForSeconds(1f / 50f);
        }
        for (int i = 0; i < 50; i++)
        {
            if (isLifeDeath) vieTxt.color += step;
            else mentalTxt.color += step;
            continueTxt.color += step;
            yield return new WaitForSeconds(1f / 50f);
        }
        while (true)
        {
            if (Input.anyKeyDown) break;
            yield return null;
        }
        for (int i = 0; i < 50; i++)
        {
            fg.color += step;
            yield return new WaitForSeconds(1f / 50f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
