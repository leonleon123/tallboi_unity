using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{ 
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Entered");
            EventListener.current.RoomTriggerEnter(id);
        }
    }

    // If we want to RenderOff
    /*
    private void OnTriggerExit(Collider other) {
        Debug.Log("Exited");
        DrawMinimap.current.OnTest(id);
    }
    */
}
