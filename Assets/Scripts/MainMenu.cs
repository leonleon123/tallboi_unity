using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required when Using UI elements.


public class MainMenu : MonoBehaviour
{

    public GameObject defaultGroup;
    public GameObject levelSelectGroup;
    public GameObject settingsGroup;
    public GameObject ingameGroup;
    public Slider musicSlider;
    public Slider sfxSlider;
    bool fromMain = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<HatController>().addHat();
        musicSlider.onValueChanged.AddListener(delegate { MusicValueChangeCheck(); });
        sfxSlider.onValueChanged.AddListener(delegate { SFXValueChangeCheck(); });
        //HelperClass.volumeMusic = musicSlider.value;
        //HelperClass.volumeSFX = sfxSlider.value;
        musicSlider.value = HelperClass.volumeMusic;
        sfxSlider.value = HelperClass.volumeSFX;
    }

    public void ingameSetup()
    {
        ingameGroup.SetActive(true);
        defaultGroup.SetActive(false);
    }

    void MusicValueChangeCheck()
    {
        HelperClass.volumeMusic = musicSlider.value;
    }

    void SFXValueChangeCheck()
    {
        HelperClass.volumeSFX = sfxSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Continue();
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

    public void QuitToMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("Audio"));
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Vikings()
    {
        Destroy(GameObject.FindGameObjectWithTag("Audio"));
        SceneManager.LoadScene("Vikings", LoadSceneMode.Single);
    }

    public void Egypt()
    {
        Destroy(GameObject.FindGameObjectWithTag("Audio"));
        SceneManager.LoadScene("Egypt", LoadSceneMode.Single);
    }

    public void LevelSelect()
    {
        if (defaultGroup.activeSelf)
            fromMain = true;
        else
            fromMain = false;
        defaultGroup.SetActive(false);
        levelSelectGroup.SetActive(true);
    }

    public void Back()
    {
        if (fromMain)
            defaultGroup.SetActive(true);
        else
            ingameGroup.SetActive(true);
        settingsGroup.SetActive(false);
        levelSelectGroup.SetActive(false);
    }

    public void Settings()
    {
        if (defaultGroup.activeSelf)
            fromMain = true;
        else
            fromMain = false;
        settingsGroup.SetActive(true);
        defaultGroup.SetActive(false);
        ingameGroup.SetActive(false);
    }

    public void Continue()
    {
        if(HelperClass.scene != null)
        { 
            Cursor.lockState = CursorLockMode.Locked;
            if (fromMain)
                defaultGroup.SetActive(true);
            else
                ingameGroup.SetActive(true);
            settingsGroup.SetActive(false);
            levelSelectGroup.SetActive(false);
            HelperClass.scene.SetActive(true);
            HelperClass.mainMenu.SetActive(false);
        }
    }
}
