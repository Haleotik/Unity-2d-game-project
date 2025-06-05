using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawner_1;
    GameObject inst_cont;
    public GameObject copied_obj;
    // Start is called before the first frame update
    void Start()
    {
        inst_cont = Instantiate(copied_obj, spawner_1.transform.position, spawner_1.transform.rotation);
        inst_cont.transform.SetParent(spawner_1.transform, true);
        
        //spawner_1.


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
