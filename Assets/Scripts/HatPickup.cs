using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatPickup : MonoBehaviour
{

    public bool giveHat = true;
    public float rotationSpeed = 100.0f;
    public GameObject icon;

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
            Debug.Log("Hat Pickup Player Collided");
            AudioSource audio = GetComponent<AudioSource>();
            
            HatController hatController = other.GetComponent<HatController>();
            if (giveHat)
            {
                AudioSource.PlayClipAtPoint(audio.clip, transform.position, HelperClass.volumeSFX / 100.0f);
                hatController.addHat();
                hatController.deactivatedPickups.Add(gameObject);
                gameObject.SetActive(false);
                icon.SetActive(false);
            }
            else
            {
                if (hatController.removeHat())
                {
                    AudioSource.PlayClipAtPoint(audio.clip, transform.position, HelperClass.volumeSFX / 100.0f);
                    hatController.deactivatedPickups.Add(gameObject);
                    gameObject.SetActive(false);
                    
                }
            }
        }
    }
}
