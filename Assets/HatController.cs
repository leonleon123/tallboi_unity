using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    // Start is called before the first frame update

    private int numHats = 0;

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
                hat.transform.localPosition = new Vector3(0, 0.6f + numHats * 0.2f, 0);
                hat.transform.localRotation = Quaternion.identity;
                hat.transform.localScale = new Vector3(1, 0.2f, 1);
                CharacterController controller = GetComponent<CharacterController>();
                numHats++;
                controller.height = 1 + 0.2f * numHats;
                controller.center = new Vector3(0, 0.1f * numHats, 0);
                break;
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
