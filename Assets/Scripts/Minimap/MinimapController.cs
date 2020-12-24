﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{

    public int id;

    void Start()
    {
        EventListener.current.onRoomEntrance += RenderOn;
        //DrawMinimap.current.test += RenderOff;
    }

    private void RenderOn(int id) {
        if (id == this.id)
        {
            Debug.Log("Drawing");
            Renderer[] rs = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
                r.enabled = true;
        }
    }

    // if for some reason we want to renderOff
    /*
    private void RenderOff(int id)
    {
        if (id == this.id)
        {
            Debug.Log("Deleting");
            //transform.position = new Vector3(transform.position.x, 15, transform.position.z);
            Renderer[] rs = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
                r.enabled = false;
        }
    }
    */
}