using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        PlayerMovement mov = gameObject.GetComponentInParent<PlayerMovement>();
        transform.Rotate(Vector3.right * mouseY * mov.mouseSensitivity * Time.deltaTime * -1);
        var angles = transform.localEulerAngles;
        angles.z = 0;
        var angle = transform.localEulerAngles.x;
        //Debug.Log(angle);
        if (angle > 60 && angle < 180)
            angles.x = 60;
        else if (angle < 345 && angle > 180)
            angles.x = 345;
        angles.y = 0;
        angles.z = 0;

        transform.localEulerAngles = angles;
    }
}
