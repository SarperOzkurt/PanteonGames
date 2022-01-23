using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public GameObject brush;
    public float BrushSize;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

           // LayerMask layerMask = 1 << 8;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData) && hitData.collider.tag == "Paintable")
            {
                Instantiate(brush, hitData.point + Vector3.back * 0.001f, brush.transform.rotation, transform);
            }
        }
    }
}
