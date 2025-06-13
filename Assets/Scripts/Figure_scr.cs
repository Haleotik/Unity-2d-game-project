using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;


public class Figure_scr : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] _slots;
    public int _vid;
    public int _zapolnennost;
    
    public List<GameObject> _spisok; // kto v slote
    public List<GameObject> _spisok2; // sovpadaushii

    float rand_rot = 0f;

    void Start()
    {
        _slots = GameObject.FindGameObjectsWithTag("_slot").OrderBy(go => go.name).ToArray();
        _spisok = GameObject.Find("Canvas").GetComponent<Spawner>()._spisok;
        _spisok2 = GameObject.Find("Canvas").GetComponent<Spawner>()._spisok2;

        rand_rot = Random.Range(10f, 270f);
        transform.Rotate(0.0f, 0.0f, rand_rot, Space.Self);

    }
        
        
        
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].GetComponent<Slot_scr>()._var == 0) // ne zanyat
            {
                _spisok.RemoveAll(s => s == null);
                _spisok2.Clear();
                
                transform.position = _slots[i].transform.position;
                transform.rotation = _slots[i].transform.rotation;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                                
                _slots[i].GetComponent<Slot_scr>()._var = _vid; // slot pomechaetsya kak zanyaty 
                GameObject.Find("Canvas").GetComponent<Spawner>().na_urovne.Remove(gameObject); 
                _spisok.Add(gameObject); 
                      
                
                
                for (int ib = 0; ib < _slots.Length; ib++) //proverka zapolnennost
                {
                    if (_slots[ib].GetComponent<Slot_scr>()._var != 0)
                    {
                        _zapolnennost += 1;
                    }                    
                }

                if (_zapolnennost == 7) // mashtabirovanie
                { GameObject.Find("Button").GetComponent<Scene_Manager_scr>()._FinishScene(); }


                for (int ib = 0; ib < _slots.Length; ib++)
                {
                    if (_spisok[ib].GetComponent<Figure_scr>()._vid == this._vid)
                    {   
                        _spisok2.Add(_spisok[ib]);
                        if (_spisok2.Count == 3) // ubiranie obectov 
                        { StartCoroutine(cust_coroutine3()); }
                    }
                }
                
                break;
            }            
        }        
    }

    IEnumerator cust_coroutine3()
    {
        yield return new WaitForSeconds(0.5f);
        if (GameObject.Find("Canvas").GetComponent<Spawner>().na_urovne.Count() == 0)
        { GameObject.Find("Button").GetComponent<Scene_Manager_scr>()._CoolScene(); }
        else
        {
            for (int ib = 0; ib < 3; ib++)
            {
                Destroy(_spisok2[ib]);
            }

            for (int ibc = 0; ibc < _slots.Length; ibc++) // ochist slotov
            {
                if (_slots[ibc].GetComponent<Slot_scr>()._var == _vid)
                { _slots[ibc].GetComponent<Slot_scr>()._var = 0; }
            }
        }
    }

}
