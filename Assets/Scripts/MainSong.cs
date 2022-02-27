using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSong : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
