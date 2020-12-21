using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverThink : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public float speed = 0.05f;
    public float moveDistance = 0;
    [HideInInspector]
    public bool pulled
    {
        get; private set;
    }
    private GameObject door;
    private bool doorOpening = false;
    private float doorOffset = 0;
    private Vector3 doorSpawnLoc;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        pulled = false;

        for(int i = 0; i < transform.parent.childCount;i++)
        {
            Transform child = transform.parent.GetChild(i);
            if(child.CompareTag("Door"))
            {
                door = child.gameObject;
                doorSpawnLoc = new Vector3(door.transform.position.x,door.transform.position.y,door.transform.position.z);
                if (moveDistance == 0)
                    moveDistance = door.transform.localScale.y;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(doorOpening)
        {
            doorOffset += speed;
            door.transform.Translate(0, speed, 0);
            if(doorOffset > moveDistance)
            {
                doorOpening = false;
            }
        }
    }

    public void Activate()
    {
        if(!pulled)
        {
            //Debug.Log("Called activate");
            anim.Play("Pull");
            pulled = true;
            OpenDoor();
            
        }
    }

    void OpenDoor()
    {
        doorOpening = true;
        
    }

    public void ResetLever()
    {
        pulled = false;
        anim.Rebind();
        doorOffset = 0;
        doorOpening = false;
        door.transform.position = doorSpawnLoc;
    }
}
