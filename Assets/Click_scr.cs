using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_scr : MonoBehaviour
{
    public GameObject cust_gameObject;
    int id;
    // Start is called before the first frame update
    void Start()
    {
        id = gameObject.GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(id);
        }

    }

   
}
