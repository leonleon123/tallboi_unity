using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardThink : MonoBehaviour
{
    // Start is called before the first frame update

    public float mRaycastRadius;  // width of our line of sight (x-axis and y-axis)
    public float mTargetDetectionDistance;  // depth of our line of sight (z-axis)

    private RaycastHit _mHitInfo;   // allocating memory for the raycasthit
    // to avoid Garbage
    private bool hasDetectedPlayer = false;   // tracking whether the player
    // is detected to change color in gizmos

    public bool moving = false;
    public float speed = 1.0f;

    private int index = 1;
    private List<GameObject> path = new List<GameObject>();
    bool ascending = true;
    private bool charging = false;
    private float chargeTime = 0;
    PlayerMovement playerMovement;
    [HideInInspector]
    public bool gotHatted = false;

    public void HatOn()
    {
        moving = false;
        gotHatted = true;
    }

    private void CheckForTargetInLineOfSight()
    {
        if (!hasDetectedPlayer && !gotHatted)
        {
            bool temp = Physics.SphereCast(transform.position, mRaycastRadius, transform.forward, out _mHitInfo, mTargetDetectionDistance);

            if (temp)
            {
                if (_mHitInfo.transform.CompareTag("Player"))
                {
                    Debug.Log("Detected Player");
                    hasDetectedPlayer = true;
                    moving = false;
                    charging = true;
                    chargeTime = 0;
                    playerMovement.Freeze();
                }
                else
                {
                    //Debug.Log("No Player detected");
                }

            }
            else
            {
            }
        }
    }
    void Start()
    {
        GameObject[] allpaths = GameObject.FindGameObjectsWithTag("Path");
        for(int i = 0; i < allpaths.Length;i++)
        {
            if(allpaths[i].transform.parent == gameObject.transform.parent)
                path.Add(allpaths[i]);
        }
        playerMovement = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForTargetInLineOfSight();
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
            Debug.Log(index);
            transform.LookAt(path[index].transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void OnDrawGizmos()
    {
        if (hasDetectedPlayer || gotHatted)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawCube(new Vector3(0f, 0f, mTargetDetectionDistance / 2f), new Vector3(mRaycastRadius, mRaycastRadius, mTargetDetectionDistance));
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
