using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




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

    public int Spec_opt;
    public int _rand;

    public TMP_Text _textMeshPro;

    
    public GameObject _circle;

    

    public List<GameObject> na_urovne = new List<GameObject>();

    void Start()
    {
        
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
        _button();
    }
    
    public void spec()
    {
        
        if (Spec_opt == 4)
        { Spec_opt = -1; }
        else
        { Spec_opt = Spec_opt + 1; }
        _textMeshPro = Spec_opt(ToString);

    }

    public void _button()
    {
        _rand = Random.Range(1, na_urovne.Count);
        for (int i = 0; i < na_urovne.Count; i++) // obnulyator
        {
            na_urovne[i].SetActive(false);
            na_urovne[_rand].GetComponent<Rigidbody2D>().gravityScale = 1;
            
            na_urovne[_rand].GetComponent<Figure_scr>().Spec_opt_f = 0;
            na_urovne[_rand].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }

        

        //Spec_opt = 2;
        
        
        _chosen = 0;
        StartCoroutine(cust_coroutine2());
       
    }

    IEnumerator cust_coroutine2()
    {
        yield return new WaitForSeconds(0.02f);

        na_urovne[_chosen].transform.position = spawner_1.transform.position;
        na_urovne[_chosen].SetActive(true);
        
        if (_chosen < na_urovne.Count-1)
        { 
            _chosen = _chosen + 1;
            StartCoroutine(cust_coroutine2()); 
        }

        else
        {
            if (Spec_opt == 1) // _tyaj
            {
                na_urovne[_rand].GetComponent<Rigidbody2D>().gravityScale = 100;
            }


            else if (Spec_opt == 2) // _prityaj
            {
                _circle.transform.position = na_urovne[_rand].transform.position;
                _circle.transform.SetParent(na_urovne[_rand].transform);

                na_urovne[_rand].GetComponent<Figure_scr>().Spec_opt_f = 2;
                na_urovne[_rand].GetComponent<Rigidbody2D>().gravityScale = 2f;
                _circle.SetActive(true);
            }


            else if (Spec_opt == 3) // _expl
            {
                na_urovne[_rand].GetComponent<Figure_scr>().Spec_opt_f = 3;
                na_urovne[_rand].AddComponent<ParticleSystem>();
            }

            else if (Spec_opt == 4 && na_urovne.Count > 15) // _hol
            {
                na_urovne[_rand].GetComponent<Figure_scr>().Spec_opt_f = 4;
                
                na_urovne[_rand].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }


        }
    }

    
}
