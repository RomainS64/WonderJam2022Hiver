using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pensees : MonoBehaviour
{
    static public bool isInPensee = false;
    [SerializeField] private float textSpeed,fadeSpeed;
    [SerializeField] private GameObject penseeCanvas;
    [SerializeField] private Image penseeBG;
    [SerializeField] private Text penseeTxt;
    private IEnumerator pensee;
    private string[] text;
    private Life life;
    private Mental mental;
    Action actionToCall = null;

    bool isClicked = false;

    private void Start()
    {
        life = FindObjectOfType<Life>();
        mental = FindObjectOfType<Mental>();
        penseeCanvas.SetActive(false);
        text = new string[1] { penseeTxt.text };
    }

    public void StartPensee(string txt = null, Action actionToCall = null)
    {
        if (actionToCall != null) this.actionToCall = actionToCall;
        if (txt != null) text = new string[1] { txt};
        if (pensee != null) StopCoroutine(pensee);
        isInPensee = true;
        pensee = PenseeRoutine();
        StartCoroutine(pensee);
    }
    public void StartPensee(string[] txts = null,Action actionToCall = null)
    {
        if (actionToCall != null) this.actionToCall = actionToCall;
        if (txts != null) text = txts;
        if (pensee != null) StopCoroutine(pensee);
        isInPensee = true;
        pensee = PenseeRoutine();
        StartCoroutine(pensee);
    }

    IEnumerator PenseeRoutine()
    {

        isClicked = false;

        yield return new WaitForSeconds(0.5f);
        penseeCanvas.SetActive(true);
        penseeTxt.text = "";
        string currentText = "";
        Color endColor =new Color(penseeBG.color.r, penseeBG.color.g, penseeBG.color.b,penseeBG.color.a);
        Color stepColor=new Color(0,0,0,penseeBG.color.a/50f);
        penseeBG.color =new Color(penseeBG.color.r, penseeBG.color.g, penseeBG.color.b,0);
        for (int i = 0; i < 50; i++)
        {
            penseeBG.color += stepColor;
            yield return new WaitForSeconds(fadeSpeed/10f);
        }
        for(int j = 0; j < text.Length; j++)
        {
            penseeTxt.text = "";
            currentText = "";
            penseeBG.color = endColor;
            for (int i = 0; i < text[j].Length; i++)
            {
                currentText += text[j][i];
                penseeTxt.text = currentText;
                yield return new WaitForSeconds(textSpeed / 10f);
            }
            while (!Input.anyKeyDown) yield return null;
        }

        penseeTxt.text = "";
        for (int i = 0; i < 50; i++)
        {
            penseeBG.color -= stepColor;
            yield return new WaitForSeconds(fadeSpeed/10f);
        }

        isInPensee = false;
        penseeCanvas.SetActive(false);
        penseeBG.color = endColor;
        if (actionToCall != null)actionToCall.Invoke();

    }
}
