using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.gameObject.transform.position = new Vector3(0, 0, 0.4f);
        }
        if (collision.gameObject.tag == "opponent")
        {
            collision.collider.gameObject.transform.position = new Vector3(0, 0, 0.4f);
        }
    }
}
