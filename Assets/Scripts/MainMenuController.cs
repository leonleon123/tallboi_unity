using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenu;
    public GameObject scene;
    PlayerControls playerControls;
    void Start()
    {
        playerControls = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playerControls.menuKey) && mainMenu != null && scene != null)
        {
            Cursor.lockState = CursorLockMode.None;
            HelperClass.mainMenu = mainMenu;
            HelperClass.scene = scene;
            mainMenu.SetActive(true);
            mainMenu.GetComponent<CanvasPointer>().canvas.GetComponent<MainMenu>().ingameSetup();
            //MainMenu mm = mainMenu.GetComponent<MainMenu>();
            //mm.ingameSetup();
            scene.SetActive(false);
        }
    }
}
