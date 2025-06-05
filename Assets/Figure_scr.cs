using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure_scr : MonoBehaviour
{
    float rand_rot = 0f;
    // Start is called before the first frame update
    void Start()
    {
       rand_rot = Random.Range(10f, 270f);
       transform.Rotate(0.0f, 0.0f, rand_rot, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(35.0f, 0.0f, 0.0f, Space.Self);
    }
}
