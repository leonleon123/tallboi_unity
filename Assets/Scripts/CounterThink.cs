using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterThink : MonoBehaviour
{

    TMP_Text text;
    HatController hc;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        hc = GameObject.FindGameObjectWithTag("Player").GetComponent<HatController>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = hc.hats.Count.ToString() + "/3";
        if(hc.hats.Count >= 3)
        {
            text.color = Color.green;
        }
        else
        {
            text.color = Color.white;
        }

        if (hc.removedAllHats)
            transform.parent.gameObject.SetActive(false);
    }
}
