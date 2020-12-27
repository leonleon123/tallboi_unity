using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;
public class DoorFrameLaserGen : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        DoorFrameConf doorFrameConf = GetComponentInParent<DoorFrameConf>();
        //transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
        CharacterController ch = player.GetComponent<CharacterController>();
        HatController hc = player.GetComponent<HatController>();

        transform.localPosition = new Vector3(
            0, 
            ch.height * player.transform.localScale.y + hc.hatOffset + doorFrameConf.size * hc.hatHeight - hc.hatHeight / 2 , 
            0
        );

    }
    void Update()
    {
        
    }
}
