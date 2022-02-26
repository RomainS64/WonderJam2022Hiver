using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    [SerializeField] private Sprite spriteBoutonUtilise,spriteBoutonPossible;
    private SpriteRenderer spriteBouton;

    // Start is called before the first frame update
    void Start()
    {
        spriteBouton = gameObject.GetComponentInParent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        spriteBouton.sprite = spriteBoutonPossible;
    }

    public void ClickOnTheButton()
    {
        spriteBouton.sprite = spriteBoutonUtilise;
    }

}
