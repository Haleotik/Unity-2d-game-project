using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure_scr : MonoBehaviour
{

    public GameObject _GO_pref;
    float rand_rot = 0f;
    public GameObject _camera;
    // Start is called before the first frame update
    void Start()
    {
       rand_rot = Random.Range(10f, 270f);
       transform.Rotate(0.0f, 0.0f, rand_rot, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        if (Input.GetMouseButton(0))
        {
            Destroy(this.gameObject);
        }
        */
    }


   
}
