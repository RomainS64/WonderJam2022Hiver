using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcamera;
    [SerializeField] Transform center;
    IEnumerator zoom;
    private void Start()
    {
        vcamera.Follow = center;
    }
    public void StartZoom(float from,float to,float time, Transform center=null)
    {
        if (zoom != null) StopCoroutine(zoom);
        zoom = CameraZoom(from, to, time,center==null?this.center:center);
        StartCoroutine(zoom);
    }
    IEnumerator CameraZoom(float from, float to, float time,Transform center)
    {
        vcamera.Follow = center;
        vcamera.m_Lens.OrthographicSize = from;
        float displacement = (to - from) / 100;
        for (int i = 0; i < 100; i++)
        {
            vcamera.m_Lens.OrthographicSize += displacement;
            yield return new WaitForSeconds(time / 100f);
        }
        vcamera.Follow = this.center;

    }
}
