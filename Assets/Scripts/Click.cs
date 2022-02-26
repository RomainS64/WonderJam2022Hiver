using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    static bool IsClickingOn(GameObject MyObj)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.Equals(MyObj))return true;
            }
        }
        return false;
    }
    static bool IsClickingOn(GameObject[] MyObjs)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                foreach(GameObject obj in MyObjs)
                {
                    if (hit.transform.Equals(obj)) return true;
                }
                
            }
        }
        return false;
    }
}
