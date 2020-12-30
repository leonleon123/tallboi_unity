using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : Door
{
    public GameObject doorMoveTarget;
    public float maxMoveTime;

    private bool opening = false;
    private float moveTime = 0.0f;
    private Vector3 velocity = Vector3.zero;

    override public void Open()
    {
        opening = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            transform.position = Vector3.SmoothDamp(transform.position, doorMoveTarget.transform.position, ref velocity, maxMoveTime);
            moveTime += Time.deltaTime;
        }
    }
}
