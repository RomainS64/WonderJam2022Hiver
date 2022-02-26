using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite spriteBoutonUtilise;
    private bool isActive = true;
    public bool IsActive { get { return isActive; } set { isActive = value; } }
    private float actionValue;
    public float ActionValue { get { return actionValue; } set { actionValue = value; } }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActionButton()
    {

    }


    public void DesactivateButton()
    {
        SpriteRenderer spriteBouton;
        spriteBouton = gameObject.GetComponentInParent<SpriteRenderer>();
        spriteBouton.sprite = spriteBoutonUtilise;
        this.isActive = false;
    }
    
}
