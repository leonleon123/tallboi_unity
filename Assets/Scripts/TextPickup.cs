using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPickup : MonoBehaviour
{
    public int id = 0;
    [TextArea]
    public string text = "I am Error";
    // Start is called before the first frame update
    void Start()
    {
        if(HelperClass.pickedTexts.Contains(id))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("picked up text");
            //HatController hatController = other.GetComponent<HatController>();
            TextboxController textboxController = other.GetComponent<TextboxController>();
            textboxController.activateTextbox(text);
            HelperClass.pickedTexts.Add(id);
            gameObject.SetActive(false);
        }
    }
}
