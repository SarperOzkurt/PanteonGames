using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public Animator charanim;
    float hmove;
    float cspeed;
    float cspeedX;
    bool goright;
    bool goleft;
    public bool isGround;
    public bool isGameFinish;
    // Start is called before the first frame update
    void Start()
    {
        isGameFinish = false;
        isGround = false;
        goright = false;
        goleft = false;
        charanim = GetComponent<Animator>();
        charanim.SetBool("isGameStart", true);
        cspeed = 0.35f;
        cspeedX = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        hmove = Input.GetAxis("Horizontal");
        transform.Translate(hmove * cspeedX * Time.deltaTime, 0, cspeed * Time.deltaTime);
        if (!isGround)
        {
            if (goright)
            {
                transform.Translate(cspeedX * Time.deltaTime / 2, 0, 0);
            }
            else if (goleft)
            {
                transform.Translate(-cspeedX * Time.deltaTime / 2, 0, 0);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "rightrotator")
        {
            goright = true;
        }
        if (collision.gameObject.tag == "leftrotator")
        {
            goleft = true;
        }
        if (collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BoundFinish")
        {
            isGameFinish = true;
            charanim.SetBool("isGameStart", false);
            cspeed = 0.0f;
            cspeedX = 0.0f;
            other.gameObject.transform.Translate(0, 0, -0.25f);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "rightrotator")
        {
            goright = false;
        }
        if (collision.gameObject.tag == "leftrotator")
        {
            goleft = false;
        }
        if (collision.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }

}
