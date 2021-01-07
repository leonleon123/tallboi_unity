using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(string.Compare(SceneManager.GetActiveScene().name,"Vikings") == 0)
            GetComponent<AudioSource>().volume = HelperClass.volumeMusic / 100.0f / 4.0f;
        else
            GetComponent<AudioSource>().volume = HelperClass.volumeMusic / 100.0f;
        //Debug.Log(HelperClass.volumeMusic / 100.0f);
    }

    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
    }
}
