using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickScript : MonoBehaviour
{
    // Start is called before the first frame update
    float thrust = 100f;
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
            collision.rigidbody.AddForce(Vector3.back * thrust);
        }
        else if (collision.gameObject.tag == "opponent")
        {
            collision.rigidbody.AddForce(Vector3.back * thrust);
        }
    }
}
