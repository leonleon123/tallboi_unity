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
        if (angle > 180 && angle < 320)
            angles.x = 320;
        else if (angle < 180 && angle > 60)
            angles.x = 60;

        transform.localEulerAngles = angles;
    }
}
