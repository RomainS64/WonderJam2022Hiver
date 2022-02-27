using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonMove : MonoBehaviour
{
    
    [HideInInspector] public float speed;
    [HideInInspector] public float downTime, stopTime, upTime;
    public void StartPiston()
    {
        StartCoroutine(nameof(Move));
    }
    IEnumerator Move()
    {
        for (int i = 0; i < 15; i++)
        {
            //MoveDown
            transform.position += new Vector3(0, -speed *(downTime/15), 0);
            yield return new WaitForSeconds(downTime/15);
        }
        yield return new WaitForSeconds(stopTime);
        for (int i = 0; i < 15; i++)
        {
            //MoveUp
            transform.position += new Vector3(0,speed * (upTime/ 15), 0);
            yield return new WaitForSeconds(upTime/15);
        }
    }
}
