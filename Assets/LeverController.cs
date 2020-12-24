using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{

    //private bool canActivateLever = false;
    private GameObject[] levers;
    //private GameObject nearbyLever;
    PlayerControls controls;
    // Start is called before the first frame update
    void Start()
    {
        levers = GameObject.FindGameObjectsWithTag("Lever");
        controls = gameObject.GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        bool requestActivateLever = Input.GetKeyDown(controls.activateKey);
        if(requestActivateLever)
        { 
            foreach (GameObject lever in levers)
            {
                //Debug.Log(Vector3.Distance(gameObject.transform.position, lever.transform.position));
            
                if (Vector3.Distance(gameObject.transform.position, lever.transform.position) < 1.7)
                {
                    
                    LeverThink leverThink = lever.GetComponent<LeverThink>();
                    leverThink.Activate();
                    
                }
            }
        }
    }
}
