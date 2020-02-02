using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicForeverScript : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }       
}
