using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GreenLaserThink : MonoBehaviour
{

    public float timeToActivate = 1;
    public int minHats = 0; //hardcoded minimum of hats, should be 0 in most cases, because of smart detection (which prevents jump abuse)
    public float speed = 0.005f;
    public float moveDistance = 0;
    public bool takeHats = false;
    public GameObject door;
    public Material activatedMaterial;
    public GameObject minimapWall;


    bool charging = false;
    float chargeTime = 0;
    bool activated = false;

    HatController hatController;
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        hatController = players[0].GetComponent<HatController>();
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

    }

    void OpenDoor()
    {
        AudioSource audio = GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(audio.clip, transform.position, HelperClass.volumeSFX / 100.0f);
        Door d = door.GetComponent<Door>();
        d.Open();
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
        Destroy(gameObject);
        if (minimapWall != null) 
                minimapWall.SetActive(false);
        OpenDoor();
        if (takeHats)
            hatController.removeAllHats();
    }
}
