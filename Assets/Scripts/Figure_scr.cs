using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SocialPlatforms;
using Unity.VisualScripting;


public class Figure_scr : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] _slots;
    public int _vid;
    
    
    

    public Vector2 vecc;
    public Vector2 vecc2;
    public bool _gr;
    public int Spec_opt_f;
    Spawner Spawner_obj;
    public bool slotted;
    float rand_rot = 0f;

    void Start()
    {

        
        _slots = GameObject.FindGameObjectsWithTag("_slot").OrderBy(go => go.name).ToArray();
       
        Spawner_obj = GameObject.Find("Canvas").GetComponent<Spawner>();

        rand_rot = Random.Range(10f, 270f);
        transform.Rotate(0.0f, 0.0f, rand_rot, Space.Self);

    }
        
    void Update()
    {
        if (Spawner_obj.Spec_opt == 2)
        {
            if (_gr && Spec_opt_f != 2)
            {
                vecc = GameObject.Find("Circle").transform.position - gameObject.transform.position;
                vecc2 = vecc.normalized;

                GetComponent<ConstantForce2D>().force = vecc2 * 7;
            }

            else if (vecc2 != null && !_gr)
            {
                GetComponent<ConstantForce2D>().force = vecc2;
                vecc2 = Vector2.zero;
            }


            Debug.DrawRay(transform.position, vecc2 * 7, Color.red);

        }
        
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!slotted && Spec_opt_f != 4 && Spawner_obj._clickable)
        {
            slotted = true;
            Spawner_obj.coroutineT();
            Spawner_obj._zapolnennost += 1;
            if (Spec_opt_f == 2 && transform.Find("Circle").gameObject != null)
            {
                transform.Find("Circle").gameObject.SetActive(false);
                transform.Find("Circle").SetParent(GameObject.Find("Panel").transform);

            }

            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].GetComponent<Slot_scr>()._var == 0) // ne zanyat
                {
                    Spawner_obj._spisok.RemoveAll(s => s == null);
                    Spawner_obj._spisok2.Clear();

                    transform.position = _slots[i].transform.position;
                    transform.rotation = _slots[i].transform.rotation;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

                    _slots[i].GetComponent<Slot_scr>()._var = _vid; // slot pomechaetsya kak zanyaty 
                    Spawner_obj.na_urovne.Remove(gameObject);
                    Spawner_obj._spisok.Add(gameObject);

                    for (int ib = 0; ib < _slots.Length; ib++) // poisk pohoj figurok
                    {
                        if (Spawner_obj._spisok.Count > ib && Spawner_obj._spisok[ib].GetComponent<Figure_scr>()._vid == this._vid)
                        {
                            Spawner_obj._spisok2.Add(Spawner_obj._spisok[ib]);
                        }
                    }

                    if (Spec_opt_f != 3)
                    {
                        if (Spawner_obj._spisok2.Count == 3) // ubiranie obectov 
                        {
                            StartCoroutine(cust_coroutine3());
                        }
                        else if (Spawner_obj._zapolnennost == 7)
                        { GameObject.Find("Canvas").GetComponent<Scene_Manager_scr>()._FinishScene(); }
                    }
                    else
                    {
                        if (Spawner_obj._spisok2.Count > 1) // ubiranie obectov 
                        {
                            StartCoroutine(cust_coroutine3());
                        }
                        else if (Spawner_obj._zapolnennost == 7)
                        { GameObject.Find("Canvas").GetComponent<Scene_Manager_scr>()._FinishScene(); }
                    }

                    


                    break;
                }
            }
        }
                
    }

    IEnumerator cust_coroutine3()
    {
        yield return new WaitForSeconds(0.5f);
        
        
        if (Spawner_obj.na_urovne.Count() == 0)
        { GameObject.Find("Canvas").GetComponent<Scene_Manager_scr>()._CoolScene(); }
        else
        {
            for (int ib = 0; ib < 3; ib++) // ochist sovp object
            {
                if (Spawner_obj._spisok2.Count > ib)
                {
                    Spawner_obj.na_urovne_got.Add(Spawner_obj._spisok2[ib]);
                    Destroy(Spawner_obj._spisok2[ib]);
                    Spawner_obj._spisok2[ib].SetActive(false);
                    Spawner_obj._zapolnennost -= 1;
                    if (Spawner_obj.Spec_opt == 4) // _hol
                    {
                        Spawner_obj.spec3Pr();
                    }
                }
            }

            for (int ibc = 0; ibc < _slots.Length; ibc++) // ochist slotov
            {
                if (_slots.Length > ibc  && _slots[ibc].GetComponent<Slot_scr>()._var == _vid)
                {
                    _slots[ibc].GetComponent<Slot_scr>()._var = 0;
                }
            }
        }
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("_prityaj"))
        {
            _gr = true;
            
        }    
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("_prityaj"))
        {
            _gr = false;
        }
    }

}
