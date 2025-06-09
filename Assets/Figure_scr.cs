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
    
    
    float rand_rot = 0f;

    public List<GameObject> na_bare = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       _slots = GameObject.FindGameObjectsWithTag("_slot").OrderBy(go => go.name).ToArray();
       rand_rot = Random.Range(10f, 270f);
       transform.Rotate(0.0f, 0.0f, rand_rot, Space.Self);
        

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
                gameObject.transform.SetParent(_slots[i], true);
                
                _slots[i].GetComponent<Slot_scr>()._var = _vid;
                GameObject.Find("Canvas").GetComponent<Spawner>().na_urovne.Remove(gameObject);

                for (int ib = 0; ib < _slots.Length; ib++)
                {
                    if (_slots[ib].GetComponent<Slot_scr>()._var == _vid)
                    {
                        _var2 += 1;
                        if (_var2 == 3)
                        {
                            Debug.Log("gotovo");
                            break;
                        }
                    }
                }

                    break;
            }            
        }
        
    }



}
