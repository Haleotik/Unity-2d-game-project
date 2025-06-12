using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Spawner : MonoBehaviour
{
    public GameObject spawner_1;
    public float _timer;
    
    public GameObject copied_obj;

    //public GameObject[] GOArray;
    public int _chosen;
    public int _quantity = 1;
    public bool zap = false;
    public string _name;
    public int vid;

    float time;

    public Color[] _color;
    public GameObject[] _form;
    public Sprite[] _sprite;


    public List<GameObject> _spisok;
    public List<GameObject> _spisok2;


    public List<GameObject> na_urovne = new List<GameObject>();

   /* 
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
   */

    //

    //public List<Image> _form = new List<Image>();
    
    //                                                                                                 public List<int> _sprite = new List<int>();

    // Start is called before the first frame update
    void Start()
    {       
        StartCoroutine(cust_coroutine()); 
        time = Time.deltaTime;
    }
    

    IEnumerator cust_coroutine() //startovy spawn 
    {
        yield return new WaitForSeconds(0.1f);

        /*
        if (_chosen == GOArray.Length - 1)
        { _chosen = 0; }
        else
        { _chosen = _chosen + 1; }

        copied_obj = GOArray[_chosen];
        */


        
        for (int i = 0; i < _form.Length; i++) // gameobject
        {
            for (int ib = 0; ib < _color.Length; ib++)
            {
                for (int ibc = 0; ibc < _sprite.Length; ibc++)
                {
                    vid = vid + 1;
                    for (int exemplar = 0; exemplar < 3; exemplar++)
                    {
                        GameObject inst_cont = Instantiate(_form[i], spawner_1.transform); // spawning bazovy
                        inst_cont.SetActive(true);
                        inst_cont.transform.SetParent(gameObject.transform, true);
                        na_urovne.Add(inst_cont);

                        inst_cont.GetComponent<Image>().color = _color[ib];

                        
                        inst_cont.GetComponent<Figure_scr>()._vid = vid;

                        inst_cont.transform.Find("Img_animal").GetComponent<Image>().sprite = _sprite[ibc];
                        inst_cont.transform.Find("Img_animal").gameObject.SetActive(true);
                    }
                }

            }

        }
        

        


        /*
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
        */
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
