using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverThink : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.05f;
    public float moveDistance = 0;
    public GameObject door;

    [HideInInspector]
    public bool pulled
    {
        get; private set;
    }
    Animator anim;
    private Vector3 doorSpawnLoc;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        pulled = false;

    }

    // Update is called once per frame
    void Update()
    {

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
        Door d = door.GetComponent<Door>();
        d.Open();
    }

    public void ResetLever()
    {
        pulled = false;
        anim.Rebind();
        door.transform.position = doorSpawnLoc;
    }
}
