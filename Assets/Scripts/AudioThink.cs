using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioThink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Audio").Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = HelperClass.volumeMusic / 100.0f;
        //Debug.Log(HelperClass.volumeMusic / 100.0f);
    }

    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
    }
}
