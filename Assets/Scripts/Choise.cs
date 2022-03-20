using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choise : MonoBehaviour
{
    public static bool isInChoise = false;
    [SerializeField] private GameObject choiseCanvas,leftChosieCollider,rightChoiseCollider;
    [SerializeField] private Image choiseBG,choiseLBG,choiseRBG;
    [SerializeField] private Text choiseTxt, choiseLTxt, choiseRTxt;
    [SerializeField] private float textSpeed, fadeSpeed;


    void Start()
    {
        choiseCanvas.SetActive(false);
        leftChosieCollider.SetActive(false);
        rightChoiseCollider.SetActive(false);
    }

    // Update is called once per frame
    public void StartChoise(string whatToDo,string leftChoise,string rightChoise,Action whatToDoLeft, Action whatToDoRight)
    {
        isInChoise = true;
        StartCoroutine(ChoiseRoutine(whatToDo, leftChoise, rightChoise, whatToDoLeft, whatToDoRight));
    }
    IEnumerator ChoiseRoutine(string text, string leftChoise, string rightChoise, Action whatToDoLeft, Action whatToDoRight)
    {
        choiseCanvas.SetActive(true);
        leftChosieCollider.SetActive(true);
        rightChoiseCollider.SetActive(true);

        choiseTxt.text = "";
        choiseLTxt.text = "";
        choiseRTxt.text = "";
        string currentText = "";

        Color endColor = new Color(choiseBG.color.r, choiseBG.color.g, choiseBG.color.b, choiseBG.color.a);
        Color stepColor = new Color(0, 0, 0, choiseBG.color.a / 10f);

        choiseBG.color = new Color(choiseBG.color.r, choiseBG.color.g, choiseBG.color.b, 0);
        choiseRBG.color = new Color(choiseBG.color.r, choiseBG.color.g, choiseBG.color.b, 0);
        choiseLBG.color = new Color(choiseBG.color.r, choiseBG.color.g, choiseBG.color.b, 0);

        for (int i = 0; i < 10; i++)
        {
            choiseBG.color += stepColor;
            choiseLBG.color += stepColor;
            choiseRBG.color += stepColor;
            yield return new WaitForSeconds(fadeSpeed / 10f);
        }
        choiseBG.color = endColor;

        for (int i = 0; i < text.Length; i++)
        {
            currentText += text[i];
            choiseTxt.text = currentText;

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                choiseTxt.text = text;
                break;
            }

            yield return new WaitForSeconds(textSpeed / 10f);
        }
        choiseLTxt.text = leftChoise;
        choiseRTxt.text = rightChoise;
        bool chooseLeft;
        while (true)
        {
            if (Click.IsClickingOn(leftChosieCollider)) { chooseLeft = true;break; }
            if (Click.IsClickingOn(rightChoiseCollider)) { chooseLeft = false; break; }
            yield return null;
        }
        choiseTxt.text = "";
        choiseLTxt.text = "";
        choiseRTxt.text = "";
        for (int i = 0; i < 10; i++)
        {
            choiseBG.color -= stepColor;
            choiseLBG.color -= stepColor;
            choiseRBG.color -= stepColor;
            yield return new WaitForSeconds(fadeSpeed / 10f);
        }
        isInChoise = false;
        choiseCanvas.SetActive(false);
        leftChosieCollider.SetActive(false);
        rightChoiseCollider.SetActive(false);
        choiseBG.color = endColor;
        if (chooseLeft) whatToDoLeft.Invoke();
        else whatToDoRight.Invoke();
    }
}
