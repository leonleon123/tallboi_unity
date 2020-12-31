using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    private GameObject[] guards;
    public int activateDistance = 3;
    PlayerControls controls;
    // Start is called before the first frame update
    void Start()
    {
        guards = GameObject.FindGameObjectsWithTag("SecurityGuard");
        controls = gameObject.GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        bool requestDistract = Input.GetKeyDown(controls.activateKey);
        if (requestDistract)
        { 
            foreach (GameObject guard in guards)
            {
                //Debug.Log(Vector3.Distance(gameObject.transform.position, lever.transform.position));
                //Debug.Log(Vector3.Distance(gameObject.transform.position, guard.transform.position));
                if (Vector3.Distance(gameObject.transform.position, guard.transform.position) < activateDistance)
                {

                    //bool requestDistract = Input.GetKeyDown(controls.activateKey);
                    HatController hatController = gameObject.GetComponent<HatController>();
                    GuardThink guardThink = guard.GetComponent<GuardThink>();

                    if (hatController.hats.Count > 0 && !guardThink.gotHatted)
                    {
                    
                        guardThink.HatOn();
                    
                        hatController.removeHat();
                    }
                }
            }
        }
    }
}
