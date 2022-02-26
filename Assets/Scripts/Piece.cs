using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;

    private GameObject linkedPiece;
    void Start()
    {
        //Pour le moment le GameObject est dirrectement lié au script, on verra par la suite si on le déplace;
        linkedPiece = gameObject; 
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select stage
                if (hit.transform.Equals(leftDoor))
                {
                    //LeftDoor
                }
                if (hit.transform.Equals(rightDoor))
                {
                    //RightDoor
                }
            }
        }
    }

    public void DisplayPiece()
    {
        linkedPiece.SetActive(true);
    }



}
