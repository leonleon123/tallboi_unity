using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatPickup : MonoBehaviour
{

    public bool giveHat = true;
    public float rotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            HatController hatController = other.GetComponent<HatController>();
            if (giveHat)
            {
                hatController.addHat();
                hatController.deactivatedPickups.Add(gameObject);
                gameObject.SetActive(false);
            }
            else
            {
                if (hatController.removeHat())
                {
                    hatController.deactivatedPickups.Add(gameObject);
                    gameObject.SetActive(false);
                    
                }
            }
        }
    }
}
