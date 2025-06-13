using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Spawner : MonoBehaviour
{
    public GameObject spawner_1;
    
    public int _chosen;
    public int vid;

    public Color[] _color;
    public GameObject[] _form;
    public Sprite[] _sprite;


    public List<GameObject> _spisok;
    public List<GameObject> _spisok2;


    public List<GameObject> na_urovne = new List<GameObject>();

    void Start()
    {
        _button();
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
    }
    

    public void _button()
    {
        for (int i = 0; i < na_urovne.Count; i++)
        {
            na_urovne[i].SetActive(false);
        }
        _chosen = -1;
        StartCoroutine(cust_coroutine2());        
    }

    IEnumerator cust_coroutine2()
    {
        yield return new WaitForSeconds(0.01f);

        _chosen = _chosen + 1; 
        na_urovne[_chosen].transform.position = spawner_1.transform.position;
        na_urovne[_chosen].SetActive(true);

        if (_chosen < na_urovne.Count)
        { StartCoroutine(cust_coroutine2()); }
    }

}
