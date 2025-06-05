using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure_scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0.0f, 50.0f, 0.0f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(35.0f, 0.0f, 0.0f, Space.Self);
    }
}
