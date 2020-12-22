using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLaserThink : MonoBehaviour
{
    

    [Range(1, 10)]
    public float timeToActivate = 1;
    public Color activatedColor = Color.blue;
    public int minHats = 0; //hardcoded minimum of hats, should be 0 in most cases, because of smart detection (which prevents jump abuse)
    public float speed = 0.005f;
    public float moveDistance = 0;
    public bool takeHats = false;


    bool charging = false;
    float chargeTime = 0;
    bool activated = false;
    private GameObject door;
    private bool doorOpening = false;
    private float doorOffset = 0;
    private Vector3 doorSpawnLoc;

    HatController hatController;
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        hatController = players[0].GetComponent<HatController>();
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Transform child = transform.parent.GetChild(i);
            if (child.CompareTag("Door"))
            {
                door = child.gameObject;
                doorSpawnLoc = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
                if (moveDistance == 0)
                    moveDistance = door.transform.localScale.y;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (charging)
            chargeTime += Time.deltaTime;

        if(chargeTime >= timeToActivate)
        {
            charging = false;
            chargeTime = 0;
            Activate();
        }

        if (doorOpening)
        {
            doorOffset += speed;
            //Debug.Log(doorOffset);
            door.transform.Translate(0, speed, 0);
            if (doorOffset >= moveDistance)
            {
                //Debug.Log("Stopping door");
                doorOpening = false;
            }
        }
    }

    void OpenDoor()
    {
        doorOpening = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!activated && !charging && hatController.hats.Count >= minHats)
        { 
            if (other.CompareTag("Player") || other.CompareTag("Hat"))
            {

                charging = true;
                chargeTime = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!activated)
        {
            if (other.CompareTag("Player") || other.CompareTag("Hat"))
            {
                charging = false;
            }
        }
    }

    void Activate()
    {
        Debug.Log("Activating green laser");
        VolumetricLines.VolumetricLineBehavior script = gameObject.GetComponent<VolumetricLines.VolumetricLineBehavior>();
        script.LineColor = activatedColor;
        activated = true;
        OpenDoor();
        if (takeHats)
            hatController.removeAllHats();
    }
}
