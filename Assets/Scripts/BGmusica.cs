using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusica : MonoBehaviour
{
    private static BGmusica backgroundMusic;

    void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }

        else
        {
            Destroy(gameObject);
        }


    }

    
    
}
