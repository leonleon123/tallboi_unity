using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlarmLaserThink : MonoBehaviour
{
    // Start is called before the first frame update

    public float triggerDelay = 1.0f;
    bool triggered = false;
    float triggerCounter = 0;
    bool charging = false;
    float chargeTime = 0;
    bool activated = false;
    public float timeToActivate = 0.02f;
    PlayerMovement playerMovement;
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        playerMovement = players[0].GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (charging)
            chargeTime += Time.deltaTime;

        if (chargeTime >= timeToActivate)
        {
            charging = false;
            chargeTime = 0;
            Activate();
        }

        if (triggered)
            triggerCounter += Time.deltaTime;

        if(triggerCounter >= triggerDelay)
        {
            Trigger();
        }
        
    }

    private void Trigger()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Activate()
    {
        triggered = true;
        activated = true;
        playerMovement.Freeze();
        //todo: lock camera, maybe display a text, etc...
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (!activated && !charging)
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
}
