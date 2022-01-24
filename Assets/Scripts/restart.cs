using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{
    public GameObject cam;
    Vector3 campos;
    // Start is called before the first frame update
    void Start()
    {
        campos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(0, 0, 0.4f);
            cam.transform.position = campos;
        }
    }

}
