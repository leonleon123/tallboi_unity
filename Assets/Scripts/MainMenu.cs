using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public GameObject defaultGroup;
    public GameObject levelSelectGroup;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<HatController>().addHat();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && HelperClass.scene != null)
        {
            Cursor.lockState = CursorLockMode.Locked;
            HelperClass.scene.SetActive(true);
            HelperClass.mainMenu.SetActive(false);
        }
    }

    public void NewGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("Audio"));
        SceneManager.LoadScene("Rome", LoadSceneMode.Single);
    }

    public void Tutorial()
    {
        Destroy(GameObject.FindGameObjectWithTag("Audio"));
        HelperClass.pickedTexts.Clear();
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Destroy(GameObject.FindGameObjectWithTag("Audio"));
        Application.Quit();
    }

    public void Vikings()
    {
        Destroy(GameObject.FindGameObjectWithTag("Audio"));
        SceneManager.LoadScene("MatejTestScene", LoadSceneMode.Single);
    }

    public void Egypt()
    {
        Destroy(GameObject.FindGameObjectWithTag("Audio"));
        SceneManager.LoadScene("Egypt", LoadSceneMode.Single);
    }

    public void LevelSelect()
    {
        defaultGroup.SetActive(false);
        levelSelectGroup.SetActive(true);
    }

    public void Back()
    {
        defaultGroup.SetActive(true);
        levelSelectGroup.SetActive(false);
    }
}
