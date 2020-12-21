using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(0, 1)]
    public float hatHeight = 0.2f;
    [Range(0, 1)]
    public float hatOffset = 0.6f;

    [HideInInspector]
    public Stack<GameObject> hats;
    [HideInInspector]
    public List<GameObject> deactivatedPickups;
    private PlayerControls controls;
    public void addHat()
    {
        Debug.Log("Adding hat...");
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.tag == "Hat")
            {
                
                GameObject hat = Instantiate(child.gameObject);
                hat.SetActive(true);
                hat.transform.SetParent(transform);
                hat.transform.localPosition = new Vector3(0, hatOffset + hats.Count * hatHeight, 0);
                hat.transform.localRotation = Quaternion.identity;
                hat.transform.localScale = new Vector3(1, hatHeight, 1);
                hats.Push(hat);
                resizePlayer();
                
                break;
            }
        }
    }

    private void resizePlayer()
    {
        CharacterController controller = GetComponent<CharacterController>();
        controller.height = 1 + hatHeight * hats.Count;
        controller.center = new Vector3(0, (hatHeight/2) * hats.Count, 0);
    }

    public bool removeHat()
    {
        if(hats.Count > 0)
        { 
            Debug.Log("Removing hat");
            GameObject hat = hats.Pop();
            Destroy(hat);
            resizePlayer();
            return true;
        }
        return false;
    }

    public void removeAllHats()
    {
        while(hats.Count > 0)
        {
            removeHat();
        }
    }

    void Start()
    {
        hats = new Stack<GameObject>();
        controls = gameObject.GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(controls.Debug_addHat))
        {
            addHat();
        }
        else if (Input.GetKeyDown(controls.Debug_removeHat))
        {
            removeHat();
        }
    }
}
