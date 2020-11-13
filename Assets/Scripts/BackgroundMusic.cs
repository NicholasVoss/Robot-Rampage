using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //prevent the object from being destroyed when switching scenes
        DontDestroyOnLoad(gameObject);
    }

}
