using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knopka_scr : MonoBehaviour
{
    GameObject[] na_urovne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cust_knopka_()
    {
        na_urovne = GameObject.FindGameObjectsWithTag("chast");

    }
}
