using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardThink : MonoBehaviour
{
    public bool moving = false;
    public float speed = 1.0f;

    private int index = 1;
    private List<GameObject> path = new List<GameObject>();
    bool ascending = true;
    private bool charging = false;
    private float chargeTime = 0;
    PlayerMovement playerMovement;
    GameObject player;
    public GameObject alert;
    public GameObject hatObject;
    public GameObject head;
    public float fixY = 1.43f;
    [HideInInspector]
    public bool gotHatted = false;

    public void HatOn()
    {
        moving = false;
        gotHatted = true;
        Animator anim = gameObject.GetComponent<Animator>();
        //anim.Play("StopAll");

        GameObject hat = Instantiate(hatObject);
        hat.SetActive(true);
        hat.transform.SetParent(head.transform);
        hat.transform.localPosition = new Vector3(-0.006f, -0.01f, 0.013f);
        hat.transform.localEulerAngles = new Vector3(90, 0, 0);
        hat.transform.localScale = new Vector3(0.02f, 0.007f, 0.02f);
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+fixY, transform.localPosition.z);
    }

    public void PlayerNoticed()
    {
        if (!gotHatted)
        {
            moving = false;
            transform.LookAt(player.transform.position);
            charging = true;
            chargeTime = 0;
            playerMovement.Freeze();
            Animator anim = gameObject.GetComponent<Animator>();
            anim.Play("Stop");
            alert.SetActive(true);
        }
    }

    void Start()
    {
        if (!moving) {
            Animator anim = gameObject.GetComponent<Animator>();
            anim.Play("Stop");
        }
        GameObject[] allpaths = GameObject.FindGameObjectsWithTag("Path");
        for(int i = 0; i < allpaths.Length;i++)
        {
            if(allpaths[i].transform.parent == gameObject.transform.parent)
                path.Add(allpaths[i]);
        }
        playerMovement = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        alert.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //CheckForTargetInLineOfSight();
        Move();

        if (charging)
            chargeTime += Time.deltaTime;
        if(chargeTime >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Move()
    {
        if(moving)
        {
            //Debug.Log(index);
            transform.LookAt(path[index].transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Path"))
        {
            if(ascending)
            {
                index++;
                if(index >= path.Count)
                {
                    ascending = false;
                    index -= 2;
                }
            }
            else
            {
                index--;
                if(index < 0)
                {
                    ascending = true;
                    index += 2;
                }
            }
            

        }
    }
}
