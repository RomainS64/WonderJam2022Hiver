using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public static bool isInFade = false;
    [SerializeField] private Image image;
    private IEnumerator fade;
    /*
     * @fromAlpha: 0=transparant 1= black
     * @toAlpha: 0=transparant 1= black
     * @time: fade duration
     * @timeBeforeDesactive: time while fade Image stay active
     */
    public void StartFade(float fromAlpha,float toAlpha,float time,float timeBeforeDesactive)
   {
        if (fade != null) StopCoroutine(fade);
        fade = FadeCoroutine(fromAlpha, toAlpha, time, timeBeforeDesactive);
        StartCoroutine(fade);
   }
    public void DesactiveFade()
    {
        isInFade = false;
        if (fade != null) StopCoroutine(fade);
        image.gameObject.SetActive(false);
    }
    IEnumerator FadeCoroutine(float fromAlpha, float toAlpha, float time, float timeBeforeDesactive)
    {
        isInFade = true;
        image.color = new Color(image.color.r, image.color.g, image.color.b, fromAlpha);
        image.gameObject.SetActive(true);
        Color colorStep = new Color(0, 0, 0, (toAlpha - fromAlpha) / 100);
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(time / 100f);
            image.color += colorStep;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, toAlpha);
        isInFade = false;
        if (timeBeforeDesactive >= 0)
        {
            yield return new WaitForSeconds(timeBeforeDesactive);
            image.gameObject.SetActive(false);
        }
    }
}
