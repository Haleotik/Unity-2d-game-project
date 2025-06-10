using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;


public class Figure_scr : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] _slots;
    public bool _var1;
    public int _vid;
    public int _var2;
    public int _zapolnennost;
    public List<GameObject> _spisok;
    
    
    
    float rand_rot = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        _slots = GameObject.FindGameObjectsWithTag("_slot").OrderBy(go => go.name).ToArray();
        rand_rot = Random.Range(10f, 270f);
        transform.Rotate(0.0f, 0.0f, rand_rot, Space.Self);
        
        
        
        //mashtabirovanie
        if (_vid == 1)
        { _spisok = GameObject.Find("Canvas").GetComponent<Spawner>().na_bare_1; }
        else if (_vid == 2)
        { _spisok = GameObject.Find("Canvas").GetComponent<Spawner>().na_bare_2; }
        else if (_vid == 3)
        { _spisok = GameObject.Find("Canvas").GetComponent<Spawner>().na_bare_3; }
        else if (_vid == 4)
        { _spisok = GameObject.Find("Canvas").GetComponent<Spawner>().na_bare_4  ; }

        
    }

    // Update is called once per frame
    
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].GetComponent<Slot_scr>()._var == 0) // ne zanyat
            {
                transform.position = _slots[i].transform.position;
                transform.rotation = _slots[i].transform.rotation;
                _var1 = true;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                
                
                _slots[i].GetComponent<Slot_scr>()._var = _vid; // slot zanyat 
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
                { GameObject.Find("Canvas").GetComponent<Spawner>()._FinishScene(); }

                if (_spisok.Count == 3) // ubiranie obectov 
                {
                    if (GameObject.Find("Canvas").GetComponent<Spawner>().na_urovne.Count() == 0)
                    { GameObject.Find("Canvas").GetComponent<Spawner>()._CoolScene(); }
                    else
                    {
                        for (int ib = 0; ib < 3; ib++)
                        { Destroy(_spisok[ib]); }
                        _spisok.Clear();

                        for (int ibc = 0; ibc < _slots.Length; ibc++) // ochist slotov
                        {
                            if (_slots[ibc].GetComponent<Slot_scr>()._var == _vid)
                            { _slots[ibc].GetComponent<Slot_scr>()._var = 0; }
                        }
                    }
                    
                }

                break;
            }            
        }        
    }



}
