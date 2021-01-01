using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPickup : MonoBehaviour
{
    [TextArea]
    public string text = "I am Error";
    // Start is called before the first frame update
    void Start()
    {
        
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
            gameObject.SetActive(false);
        }
    }
}
