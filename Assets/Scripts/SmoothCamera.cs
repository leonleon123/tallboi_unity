using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [Range(0, 100)]
    public float mouseAccelerationY = 0.5f;

    public GameObject cameraTarget;
    void Start()
    {
        
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        cameraTarget.transform.Rotate(Vector3.right * -mouseY * mouseAccelerationY * Time.deltaTime);

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraTarget.transform.position, 0.1f);
        Camera.main.transform.rotation = Quaternion.Euler(
            Vector3.Lerp(
                Camera.main.transform.rotation.eulerAngles, 
                cameraTarget.transform.rotation.eulerAngles, 
                0.1f
            )
        );
    }
}
