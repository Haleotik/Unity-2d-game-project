using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    public GameObject spawner_1;
    public float _timer;
    
    GameObject copied_obj;

    public GameObject[] GOArray;
    public int _chosen;
    public int _quantity = 1;
    public bool zap = false;
    public string _name;


    public List<GameObject> na_urovne = new List<GameObject>();

    
    //mashtabirovanie
    public List<GameObject> na_bare_1 = new List<GameObject>();
    public List<GameObject> na_bare_2 = new List<GameObject>();
    public List<GameObject> na_bare_3 = new List<GameObject>();
    public List<GameObject> na_bare_4 = new List<GameObject>();
    public List<GameObject> na_bare_5 = new List<GameObject>();
    public List<GameObject> na_bare_6 = new List<GameObject>();
    public List<GameObject> na_bare_7 = new List<GameObject>();
    public List<GameObject> na_bare_8 = new List<GameObject>();
    public List<GameObject> na_bare_9 = new List<GameObject>();
    public List<GameObject> na_bare_10 = new List<GameObject>();
    public List<GameObject> na_bare_11 = new List<GameObject>();
    public List<GameObject> na_bare_12 = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {       
        StartCoroutine(cust_coroutine()); 
    }
    

    IEnumerator cust_coroutine() //startovy spawn 
    {
        yield return new WaitForSeconds(0.1f);

        if (_chosen == GOArray.Length - 1)
        { _chosen = 0; }
        else
        { _chosen = _chosen + 1; }

        copied_obj = GOArray[_chosen];
               
        GameObject inst_cont = Instantiate(copied_obj, spawner_1.transform); // spawning
        inst_cont.transform.SetParent(gameObject.transform, true);
        na_urovne.Add(inst_cont);

        if (_quantity < 36) //mashtabirovanie
        {
            StartCoroutine(cust_coroutine());
            _quantity += 1;
        }
        else 
        {
            _chosen = -1;
            zap = true;        
        }              
    }

    public void _button()
    {
        _chosen = -1;
        StartCoroutine(cust_coroutine2());        
    }

    IEnumerator cust_coroutine2()
    {
        yield return new WaitForSeconds(0.01f);

        _chosen = _chosen + 1; 
        na_urovne[_chosen].transform.position = spawner_1.transform.position;
        
        if (_chosen < na_urovne.Count)
        { StartCoroutine(cust_coroutine2()); }
    }



}
