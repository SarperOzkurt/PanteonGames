using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donutscript : MonoBehaviour
{
    GameObject donut;
    GameObject stick;
    float donutrotatespeed;
    float stickspeed;
    Vector3 stickposition;
    [SerializeField] float pointr, pointl;
    // Start is called before the first frame update
    void Start()
    {
        donutrotatespeed = 300.0f;
        stickspeed = 0.12f;
        donut = this.gameObject.transform.GetChild(0).gameObject;
        stick = this.gameObject.transform.GetChild(0).gameObject;
        stickposition = stick.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RotateDonut();
        MoveStick();
       
    }
    
    void MoveStick()
    {
        stick.transform.Translate(-stickspeed * Time.deltaTime, 0, 0);
        if (stick.transform.position.x >= stickposition.x + pointr || stick.transform.position.x <= stickposition.x - pointl)
        {
            stickspeed *= -1;
        }
    }
    void RotateDonut()
    {
        donut.transform.Rotate(-donutrotatespeed * Time.deltaTime, 0.0f, 0.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.gameObject.transform.position = new Vector3(0, 0, 0.4f);
        }
        else if (collision.gameObject.tag == "opponent")
        {
            collision.collider.gameObject.transform.position = new Vector3(0, 0, 0.4f);
        }
    }

}
