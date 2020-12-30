using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : Door
{

    public override void Open()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
