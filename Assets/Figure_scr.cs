using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Figure_scr : MonoBehaviour, IPointerClickHandler
{
    GameObject[] _slots;
    public bool _var1;
    public GameObject knopka1;
    
    float rand_rot = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
       _slots = GameObject.FindGameObjectsWithTag("_slot");
       rand_rot = Random.Range(10f, 270f);
       transform.Rotate(0.0f, 0.0f, rand_rot, Space.Self);
        knopka1.GetComponent<knopka_scr>().na_urovne


    }

    // Update is called once per frame
    
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].GetComponent<Slot_scr>()._var == false)
            {
                transform.position = _slots[i].transform.position;
                transform.rotation = _slots[i].transform.rotation;
                _var1 = true;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                
                _slots[i].GetComponent<Slot_scr>()._var = true;
                break;
            }            
        }
        
    }



}
