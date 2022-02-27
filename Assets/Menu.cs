using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject start, quit;
    void Update()
    {
        if (Click.IsClickingOn(start))
        {
            StartGame();
        }
        if (Click.IsClickingOn(quit))
        {
            Application.Quit();
        }
    }
    void StartGame()
    {
        FindObjectOfType<Fade>().StartFade(0, 1, 1, -1);
        Invoke(nameof(StartGameDelay), 1.5f);
    }
    void StartGameDelay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    private void Quit()
    {
        Application.Quit();
    }
}
