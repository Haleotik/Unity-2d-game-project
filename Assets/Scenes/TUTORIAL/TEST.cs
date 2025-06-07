using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TEST : MonoBehaviour, IPointerClickHandler //, IPointerExitHandler, IPointerEnterHandler
{
       
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }

    /*
    private void OnMouseOver()
    {
        Destroy(gameObject);
    }
    */
}
