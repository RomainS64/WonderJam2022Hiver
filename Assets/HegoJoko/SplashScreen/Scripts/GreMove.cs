using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreMove : MonoBehaviour
{
    [SerializeField] private int switchRound;
    [SerializeField] private GameObject robot, chair;

    [HideInInspector] public float moveTime,stopTime; 
    [HideInInspector] public float speed; 
    [HideInInspector] public bool isReady = true;
    [HideInInspector] public bool isReadyToBeAtomized = false;
    public void StartGreMove()
    {
        StartCoroutine(nameof(Move));
    }
    IEnumerator Move()
    {
        isReady = false;
        for(int i=0;i<15;i++)
        {
            transform.position += new Vector3(-speed*(moveTime/15), 0, 0);
            yield return new WaitForSeconds(moveTime / 15);
        }
        isReadyToBeAtomized = true;
        yield return new WaitForSeconds(stopTime/2);
        switchRound--;
        if(switchRound == 0)
        {
            robot.SetActive(false);
            chair.SetActive(true);
        }
        yield return new WaitForSeconds(stopTime/2);
        isReady = true;
    }

}
