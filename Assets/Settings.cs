using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Debug.Log("hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
