using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour { 

    public static EventListener current;

    private void Awake() {
        current = this;
    }

    public event Action<int> onRoomEntrance;
    public void RoomTriggerEnter(int id) {

        if (onRoomEntrance != null) onRoomEntrance(id);

    }

    // if for some reason we want to renderOff
    /*
    public event Action<int> test;
    public void OnTest(int id) {
        if (test != null) test(id);
    }
    */

}
