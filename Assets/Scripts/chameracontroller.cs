using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chameracontroller : MonoBehaviour
{
    public GameObject character;
    public GameObject plartform;
    Vector3 psize;
    float offset;
    float cameraspeed;
    float charcamy;
    
    void Start()
    {
        charcamy = gameObject.transform.position.y - character.transform.position.y;
        offset = character.transform.position.z - transform.position.z;
        psize = plartform.GetComponent<Collider>().bounds.size;
        cameraspeed = 0.5f;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        FallowCharacter();
    }

    void ResetCamera()
    {
        //LEFT MOVE
        if (character.transform.position.x - transform.position.x <= 0)
        {
            transform.Translate(-cameraspeed / 2 * Time.deltaTime, 0, 0);
            if (transform.position.x <= character.transform.position.x)
            {
                transform.position = new Vector3(character.transform.position.x, character.transform.position.y + charcamy, character.transform.position.z - offset);
            }
        }
        //RIGHT MOVE
        else if (character.transform.position.x - transform.position.x >= 0)
        {
            transform.Translate(cameraspeed / 2 * Time.deltaTime, 0, 0);
            if (transform.position.x >= character.transform.position.x)
            {
                transform.position = new Vector3(character.transform.position.x, character.transform.position.y + charcamy, character.transform.position.z - offset);
            }
        }
    }

    void FallowCharacter()
    {
        transform.position = new Vector3(transform.position.x, character.transform.position.y + charcamy, character.transform.position.z - offset);
        if (character.GetComponent<charactercontroller>().isGround == true)
        {
            //LEFT MOVE
            if (character.transform.position.x <= plartform.transform.position.x - (psize.x / 10))
            {
                transform.Translate(-cameraspeed * Time.deltaTime, 0, 0);
                if (transform.position.x <= character.transform.position.x)
                {
                    transform.position = new Vector3(character.transform.position.x, character.transform.position.y + charcamy, character.transform.position.z - offset);
                }
            }
            //RIGHT MOVE
            else if (character.transform.position.x >= plartform.transform.position.x + (psize.x / 10))
            {
                transform.Translate(cameraspeed * Time.deltaTime, 0, 0);
                if (transform.position.x >= character.transform.position.x)
                {
                    transform.position = new Vector3(character.transform.position.x, character.transform.position.y + charcamy, character.transform.position.z - offset);
                }
            }
        }
        else
        {
            ResetCamera();
        }
        if (character.GetComponent<charactercontroller>().isGameFinish == true)
        {
            ResetCamera();
        }
    }
}
