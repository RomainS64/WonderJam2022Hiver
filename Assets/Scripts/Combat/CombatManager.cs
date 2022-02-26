using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private GameObject[] actionButtons;
    private GameObject buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buttonPressed = Click.IsClickingOn(actionButtons);
        if (buttonPressed != null)
        {
            ButtonBehaviour buttonBehaviour = buttonPressed.GetComponent<ButtonBehaviour>();
            if (buttonBehaviour.IsActive)
            {
                buttonBehaviour.DesactivateButton();
                Debug.Log(buttonPressed.name);
            }
        }
        
    }
}
