using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;
public class DoorFrameLaserGen : MonoBehaviour
{
    void Start()
    {
        DoorFrameConf doorFrameConf = GetComponentInParent<DoorFrameConf>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CharacterController ch = player.GetComponent<CharacterController>();
        HatController hc = player.GetComponent<HatController>();

        if(doorFrameConf?.size != null)
        {
            transform.localPosition = new Vector3(
                transform.localPosition.x, 
                ch.height * player.transform.localScale.y + hc.hatOffset + doorFrameConf.size * hc.hatHeight - hc.hatHeight / 2 ,
                transform.localPosition.z
            );
        }

    }
    void Update()
    {
        
    }
}
