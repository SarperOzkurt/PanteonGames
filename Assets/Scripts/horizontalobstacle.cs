using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalobstacle : MonoBehaviour
{
    [SerializeField] float movespeed = 0.5f;
    [SerializeField] float turnspeed = 5.0f;
    GameObject childstick;
    public GameObject girl;
    Vector3 girlpos;
    // Start is called before the first frame update
    void Start()
    {
        childstick = this.gameObject.transform.GetChild(0).gameObject; ;
        girlpos = new Vector3(0, 0, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(movespeed * Time.deltaTime, 0, 0);
        childstick.transform.Rotate(0, turnspeed * Time.deltaTime, 0);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bound")
        {
            movespeed = -movespeed;
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.gameObject.transform.position = new Vector3(0, 0, 0.4f);
        }
        if (collision.gameObject.tag == "opponent")
        {
            collision.collider.gameObject.transform.position = new Vector3(0, 0, -0.4f);
        }
    }
}
