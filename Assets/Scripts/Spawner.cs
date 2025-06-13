using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



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

    public int _tyaj = 5;
    public int _prityaj = 20;

    //Vector2 gr_position;

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
            na_urovne[i].GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        
        
        _chosen = 0;
        StartCoroutine(cust_coroutine2());
       
    }

    IEnumerator cust_coroutine2()
    {
        yield return new WaitForSeconds(0.01f);

        na_urovne[_chosen].transform.position = spawner_1.transform.position;
        na_urovne[_chosen].SetActive(true);
        if (_chosen == _tyaj)
        {
            na_urovne[_tyaj].GetComponent<Rigidbody2D>().gravityScale = 50;
        }

        
        if (_chosen == _prityaj)
        {
            
           // na_urovne[_prityaj].tag = "_prityaj";
        }
        

        if (_chosen < na_urovne.Count)
        { 
            _chosen = _chosen + 1;
            StartCoroutine(cust_coroutine2()); 
        }
    }

    
}
