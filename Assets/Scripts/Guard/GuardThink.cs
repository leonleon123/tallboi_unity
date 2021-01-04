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
    public AudioClip oof;

    public void HatOn()
    {
        moving = false;
        gotHatted = true;
        Animator anim = gameObject.GetComponent<Animator>();
        anim.Play("Stop");

        GetComponent<AudioSource>().clip = oof;
        AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position, HelperClass.volumeSFX / 100.0f);

        GameObject hat = Instantiate(hatObject);
        hat.SetActive(true);
        hat.transform.SetParent(head.transform);
        hat.transform.localPosition = new Vector3(-0.0007837286f, 0.003250502f, -0.0001185059f);
        hat.transform.localEulerAngles = new Vector3(244.938f, 0.4379883f, -0.6339722f);
        hat.transform.localScale = new Vector3(0.017f, 0.006999999f, 0.017f);
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+fixY, transform.localPosition.z);
    }

    public void PlayerNoticed()
    {
        if (!gotHatted)
        {
            
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position,HelperClass.volumeSFX/100.0f);
            moving = false;
            transform.LookAt(player.transform.position);
            var angles = transform.localEulerAngles;
            angles.x = 0;
            angles.z = 0;
            transform.localEulerAngles = angles;
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
