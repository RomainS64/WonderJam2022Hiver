using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public static bool IsClickingOn(GameObject MyObj)
    {
        if (Input.GetMouseButtonDown(0) && !Fade.isInFade)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == MyObj.transform.name)return true;
            }
        }
        return false;
    }
    public static GameObject IsClickingOn(GameObject[] MyObjs)
    {
        if (Input.GetMouseButtonDown(0) && !Fade.isInFade)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                foreach(GameObject obj in MyObjs)
                {
                    if (hit.transform.name == obj.transform.name) return obj;
                }
                
            }
        }
        return null;
    }
}
