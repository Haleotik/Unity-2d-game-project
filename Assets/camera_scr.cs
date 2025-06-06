using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class camera_scr : MonoBehaviour
{
    private Ray ray; // The ray
    private RaycastHit hit; // What we hit

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Ray will be sent out from where your mouse is located	
        if (Physics.Raycast(ray, out hit, 1000.0f) && Input.GetMouseButtonDown(0)) // On left click we send down a ray
        {
            Destroy(hit.collider.gameObject); // Destroy what we hit
        }

    }
}
