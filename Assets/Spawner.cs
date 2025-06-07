using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
    public GameObject spawner_1;
    public float _timer;
    
    //GameObject inst_cont;    
    GameObject copied_obj;

    public GameObject[] GOArray;
    private int _chosen;
    public int _quantity = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        //inst_cont = Instantiate(copied_obj, spawner_1.transform.position, spawner_1.transform.rotation);
        
        //inst_cont.transform.SetParent(gameObject.transform, true);
        
        StartCoroutine(cust_coroutine());

        Debug.Log(GOArray.Length);
       
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator cust_coroutine()
    {
        yield return new WaitForSeconds(0.1f);
        if (_chosen == GOArray.Length - 1)
        {
            _chosen = 0;
        }
        else
        { _chosen = _chosen + 1; }

        copied_obj = GOArray[_chosen];
        GameObject inst_cont = Instantiate(copied_obj, spawner_1.transform);
        inst_cont.transform.SetParent(gameObject.transform, true);
        
        
        
        
        if (_quantity < 6)
        {
            StartCoroutine(cust_coroutine());
            _quantity += 1;
        }


        
    }

    

}
