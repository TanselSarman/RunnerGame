using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    static BackgroundMusic instance;

    private void Start()
    {

        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(this);

        }
        DontDestroyOnLoad(instance);
        
    }

    
}
