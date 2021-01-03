using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextboxController : MonoBehaviour
{
    private string goalText;
    private string currentText;
    private bool displayText;
    public GameObject textBox;
    private float timeAccumulator;
    public float drawTime;
    public TMP_Text tmp_text;
    private bool waitForInput = false;
    private int i = 0;
    private PlayerControls playerControls;
    private PlayerMovement pm;
    public GameObject PressFToClose;
    // Start is called before the first frame update
    void Start()
    {
        playerControls = gameObject.GetComponent<PlayerControls>();
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        bool pressedF = Input.GetKeyDown(playerControls.activateKey);
        if (displayText)
        {
            if(i >= goalText.Length && !waitForInput)
            {
                //Debug.Log("hello");
                waitForInput = true;
                PressFToClose.SetActive(true);
            }

            if(waitForInput && pressedF)
            {
                displayText = false;
                textBox.SetActive(false);
                pm.UnFreeze();
            }

            if(!waitForInput)
            { 
                if(pressedF)
                {
                    tmp_text.text = goalText;
                    i = 99999;
                    return;
                }
                timeAccumulator += Time.deltaTime;
                if(timeAccumulator > drawTime)
                {
                    timeAccumulator = 0;
                    currentText += goalText[i];
                    tmp_text.text = currentText;
                    i++;
                }
            }

        }
    }
    
    public void activateTextbox(string txt)
    {
        Debug.Log("activating text");
        goalText = txt;
        currentText = "";
        displayText = true;
        timeAccumulator = 0;
        textBox.SetActive(true);
        tmp_text.text = "";
        waitForInput = false;
        i = 0;
        pm.Freeze();
        PressFToClose.SetActive(false);
    }
}
