using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndFade : MonoBehaviour
{
    [Space]
    [Header("-----[TOUCH]")]
    [Space]
    public string sceneToLoad;
    [SerializeField] private AudioSource endSound;
    [SerializeField] private float timeBeforeEndSound;
    [Space]
    [Header("-----[DON'T TOUCH]")]
    [Space]
    [SerializeField] private GameObject fadeCanvas;

    void Start()
    {
        fadeCanvas.SetActive(false);
        StartCoroutine(nameof(Fade));
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(4.8f);
        fadeCanvas.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        FindObjectOfType<MoveManager>().StopMove();

        yield return new WaitForSeconds(timeBeforeEndSound);
        endSound.Play();
        yield return new WaitForSeconds(3f-timeBeforeEndSound);
        SceneManager.LoadScene(sceneToLoad);
    }
}
