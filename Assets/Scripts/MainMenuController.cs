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
        if (Input.GetKeyDown(playerControls.menuKey))
        {
            Cursor.lockState = CursorLockMode.None;
            HelperClass.mainMenu = mainMenu;
            HelperClass.scene = scene;
            mainMenu.SetActive(true);
            scene.SetActive(false);
        }
    }
}
