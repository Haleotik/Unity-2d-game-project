using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Figure_scr : MonoBehaviour, IPointerClickHandler
{
    GameObject[] _slots;

    
    float rand_rot = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
       _slots = GameObject.FindGameObjectsWithTag("_slot");
       rand_rot = Random.Range(10f, 270f);
       transform.Rotate(0.0f, 0.0f, rand_rot, Space.Self);
    }

    // Update is called once per frame
    
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].GetComponent<Slot_scr>()._var == false)
            {
                transform.position = _slots[i].transform.position;
                _slots[i].GetComponent<Slot_scr>()._var = true;
                break;
            }
            
        }
        //Destroy(_slots[1]);
    }



}
