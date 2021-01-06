using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : Door
{

    public float timeToExit = 0f;
    public string nextLevel;
    public GameObject exitDoor;

    private float time = 0f;
    private bool opening = false;

    public override void Open()
    {
        opening = true;
        if(exitDoor != null)
        {
            exitDoor.GetComponent<Door>().Open();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            time += Time.deltaTime;
        }
        if(time >= timeToExit)
        {
            Cursor.lockState = CursorLockMode.None;
            Destroy(GameObject.FindGameObjectWithTag("Audio"));
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        }
    }
}
