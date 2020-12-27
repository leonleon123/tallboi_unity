﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(0, 1)]
    public float hatHeight = 0.2f;
    [Range(0, 1)]
    public float hatOffset = 0.6f;

    [HideInInspector]
    public Stack<GameObject> hats;
    [HideInInspector]
    public List<GameObject> deactivatedPickups;
    public GameObject head;
    public GameObject hatObject;

    CharacterController controller;
    private PlayerControls controls;

    public void addHat()
    {
        Debug.Log("Adding hat...");
        GameObject hat = Instantiate(hatObject);
        hat.SetActive(true);
        hat.transform.SetParent(head.transform);
        hat.transform.localPosition = new Vector3(0, hatOffset + hats.Count * hatHeight, 0);
        hat.transform.localRotation = Quaternion.identity;
        hat.transform.localScale = new Vector3(1, hatHeight, 1);
        hats.Push(hat);
        resizePlayer(true);
    }

    private void resizePlayer(bool add)
    {
        Debug.Log(hatHeight);
        if(add)
        { 
            if(hats.Count == 1)
            {
                controller.height += hatOffset / transform.localScale.y;
            }
            controller.height += hatHeight / transform.localScale.y;
            controller.center += new Vector3(0, (hatHeight/2) / transform.localScale.y, 0);
        }
        else
        {
            if (hats.Count == 0)
            {
                controller.height -= hatOffset / transform.localScale.y;
            }
            controller.height -= hatHeight / transform.localScale.y;
            controller.center -= new Vector3(0, (hatHeight / 2) / transform.localScale.y, 0);
        }
    }

    public bool removeHat()
    {
        if(hats.Count > 0)
        { 
            Debug.Log("Removing hat");
            GameObject hat = hats.Pop();
            Destroy(hat);
            resizePlayer(false);
            return true;
        }
        return false;
    }

    public void removeAllHats()
    {
        while(hats.Count > 0)
        {
            removeHat();
        }
    }

    void Start()
    {
        hats = new Stack<GameObject>();
        controls = gameObject.GetComponent<PlayerControls>();
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(controls.Debug_addHat))
        {
            addHat();
        }
        else if (Input.GetKeyDown(controls.Debug_removeHat))
        {
            removeHat();
        }
    }
}